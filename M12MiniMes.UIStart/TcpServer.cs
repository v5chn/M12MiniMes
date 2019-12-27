using CommunicateCenter;
using Faster.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using M12MiniMes.Entity;
using WHC.Framework.ControlUtil;
using M12MiniMes.BLL;

namespace M12MiniMes.UIStart
{
    public static class TcpServer
    {
        public static AsyncTcpServer Server;

        public static bool Save() 
        {
            CommonSerializer.SaveObjAsBinaryFile(Server, $@".\Server.xml", out bool bSaveOK, out Exception ex);
            return bSaveOK;
        }

        public static bool Load() 
        {
            Server = CommonSerializer.LoadObjFormBinaryFile<AsyncTcpServer>($@".\Server.xml", out bool bLoadOK, out Exception ex);
            bool b = Server.Init("");
            StartMasterLogic();
            return bLoadOK;
        }

        //主逻辑处理
        public static void StartMasterLogic() 
        {
            Server.DataReceived += Server_DataReceived;
        }

        private static void Server_DataReceived(FastInterface.ITcpServer listener, Socket client, byte[] data, int length)
        {
            string mes = Encoding.UTF8.GetString(data, 0, length);  //客户端发送过来的数据
            if (string.IsNullOrEmpty(mes))
            {
                return;
            }
            string[] mess = mes.Split(',');
            if (mess.Count() <= 1)  //无效信息，不在定义的通讯协议之内
            {
                var var = Encoding.UTF8.GetBytes("invalid data!");
                listener.SendMesAsyncToClient(client, var);
                return;
            }
            string strHeader = mess[0]; //行头
            if (!Enum.GetNames(typeof(Header)).Contains(strHeader)) //不在定义的行头
            {
                //未定义的通讯格式！;
                var var = Encoding.UTF8.GetBytes("Undefined Header!");
                listener.SendMesAsyncToClient(client, var);
                return;
            }

            IPAddress ip = ((IPEndPoint)client.RemoteEndPoint).Address;
            string strIP = ip.ToString();
            //找到该地址对应的设备信息
            MachineItem machineItem = ItemManager.Instance.GetMachineItemByIP(strIP);
            if (machineItem == null)
            {
                throw new Exception($@"设备信息无该记录IP {strIP} ，请先进行同步！");
            }

            Header header = (Header)Enum.Parse(typeof(Header), strHeader);
            string[] parameters = mess.Skip(1).ToArray();
            string strInMachineID = ""; //当前流入设备ID
            string strInMachineName = ""; //当前流入设备名称
            MachineItem InMachineItem = null; //当前流入设备Item
            string strCMachineID = ""; //被查询设备ID
            string strCMachineName = ""; //被查询设备名称
            MachineItem CMachineItem = null; //被查询设备Item
            string rfid = "";
            FixtureItem fixtureItem = null; //当前治具
            byte[] dataSend = null;

            switch (header)
            {
                case Header.CX:  //查询生产数据
                    strInMachineID = parameters[0];
                    InMachineItem = ItemManager.Instance.GetMachineItemByID(strInMachineID);
                    strInMachineName = InMachineItem.设备名称;
                    strCMachineID = parameters[1]; 
                    rfid = parameters[2];
                    fixtureItem = ItemManager.Instance.GetFixtureItem(rfid, strInMachineID);
                    if (fixtureItem == null) //找不到该RFID治具的内存信息  不允许新治具跳过线头设备流入生产线（即要求新治具必须从线头开始流入）
                    {
                        var var = Encoding.UTF8.GetBytes($@"get the fixture failed which rfid is {rfid} !");
                        listener.SendMesAsyncToClient(client, var);
                        return;
                    }
                    InMachineItem.InsertFixtureItem(fixtureItem);
                    string strData = $@"CX,{strCMachineID},{rfid},{fixtureItem.治具生产批次号},";
                    foreach (var item in fixtureItem.MaterialItems)
                    {
                        if (item == null)
                        {
                            strData += "null,";
                            continue;
                        }
                        var var = item.生产数据.Where(p => p.设备id.ToString() == strCMachineID);
                        if (var == null)
                        {
                            strData += "null,";
                            continue;
                        }
                        //找出物料指定设备ID的工序数据
                        var var2 = var.Select(p => p.工序数据).FirstOrDefault() ?? "null";
                        strData += $@"{var2},";
                    }
                    dataSend = Encoding.UTF8.GetBytes(strData);
                    listener.SendMesAsyncToClient(client, dataSend);
                    break;
                case Header.XR: //写入生产数据
                    rfid = parameters[0];
                    strInMachineID = parameters[1];
                    InMachineItem = ItemManager.Instance.GetMachineItemByID(strInMachineID);
                    fixtureItem = ItemManager.Instance.GetFixtureItem(rfid, strInMachineID);
                    if (fixtureItem == null) //找不到该RFID治具的内存信息
                    {
                        var var = Encoding.UTF8.GetBytes($@"get the fixture failed which rfid is {rfid} !");
                        listener.SendMesAsyncToClient(client, var);
                        return;
                    }
                    InMachineItem.InsertFixtureItem(fixtureItem);
                    int index = 2; //parameters解析索引
                    int numbers = 12; //一般是写入12个物料信息
                    int k = parameters.Skip(2).Count() / 2;
                    numbers = Math.Min(k, 12);
                    for (int i = 0; i < numbers; i++)   //写入数据格式：值1,是否ok1，值2,是否ok2，……值12,是否ok12
                    {
                        MaterialItem materialItem = null;
                        if (fixtureItem.MaterialItems.Count < i+1) //如果治具无记录任何物料信息则插入多少个物料信息
                        {
                            materialItem = new MaterialItem(fixtureItem);
                            fixtureItem.InsertMaterialItem(i, materialItem);
                        }
                        materialItem = fixtureItem.MaterialItems[i];

                        string 物料guid = materialItem.MaterialGuid.ToString();
                        string 治具guid = materialItem.Fixture.FixtureGuid.ToString();
                        int 设备id = int.Parse(strInMachineID);

                        //检测是第一次写入还是再次写入刷新生产数据 最好规定下位机只允许写入一次
                        生产数据表Info scData = materialItem.生产数据.FirstOrDefault(p => 
                            p.物料guid.Equals(物料guid)
                            && p.治具guid.Equals(治具guid)
                            && p.设备id.Equals(设备id)
                            );

                        bool firstWrite = false;  //是否第一次写入
                        if (scData == null)  //是第一次写入
                        {
                            scData = new 生产数据表Info();
                            firstWrite = true;
                        }
                        scData.生产时间 = DateTime.Now;
                        scData.物料生产批次号 = materialItem.物料生产批次号;
                        scData.治具生产批次号 = materialItem.Fixture.治具生产批次号;
                        scData.物料guid = 物料guid;
                        scData.治具guid = 治具guid;
                        scData.治具rfid = rfid;
                        scData.治具孔号 = materialItem.GetHoleIndexInFixture();
                        scData.设备id = 设备id;
                        scData.设备名称 = strInMachineName;
                        scData.工位号 = "";
                        scData.工序数据 = parameters[index];
                        scData.结果ok = bool.Parse(parameters[index + 1]);
                        if (firstWrite)
                        {
                            BLLFactory<生产数据表>.Instance.Insert(scData);  //写入一条数据到数据库中
                        }
                        else
                        {
                            BLLFactory<生产数据表>.Instance.Update(scData, scData.生产数据id);  //更新一条数据到数据库中
                        }
                        materialItem.生产数据.Add(scData);
                        index += 2;
                    }
                    dataSend = Encoding.UTF8.GetBytes("XR Done"); //返回下位机"写入完成"
                    listener.SendMesAsyncToClient(client, dataSend);
                    break;
                case Header.NGTH:  //NG替换
                    //1、把一个NG物料从治具上取出并丢弃后，腾出位置
                    //2、从暂存位的治具上取一个好物料出来，放到上述腾出位置
                    string preRFID = parameters[0];
                    string preHoleIndex = parameters[1];
                    string nowRFID = parameters[2];
                    string nowHoleIndex = parameters[3];
                    strInMachineID = parameters[4];
                    string stationID = parameters[5];

                    InMachineItem = ItemManager.Instance.GetMachineItemByID(strInMachineID);
                    strInMachineName = InMachineItem.设备名称;
                    FixtureItem preFixture = ItemManager.Instance.GetFixtureItem(preRFID, strInMachineID); //替换前治具
                    FixtureItem nowFixture = ItemManager.Instance.GetFixtureItem(nowRFID, strInMachineID); //替换后治具
                    MaterialItem thMaterialItem = preFixture[preHoleIndex]; //替换的物料
                    MaterialItem ngMaterialItem = nowFixture[nowHoleIndex];

                    物料ng替换记录表Info ngInfo = new 物料ng替换记录表Info();
                    ngInfo.Ng替换时间 = DateTime.Now;
                    ngInfo.物料生产批次号 = ngMaterialItem.物料生产批次号;
                    ngInfo.设备id = int.Parse(strInMachineID);
                    ngInfo.设备名称 = strInMachineName;
                    ngInfo.工位号 = stationID;
                    ngInfo.物料guid = ngMaterialItem.MaterialGuid.ToString();
                    ngInfo.替换前治具guid = preFixture.FixtureGuid.ToString();
                    ngInfo.替换前治具rfid = preRFID;
                    ngInfo.替换前治具孔号 = int.Parse(preHoleIndex);
                    ngInfo.前治具生产批次号 = preFixture.治具生产批次号;
                    ngInfo.替换后治具guid = nowFixture.FixtureGuid.ToString();
                    ngInfo.替换后治具rfid = nowRFID;
                    int iIndex = int.Parse(nowHoleIndex);
                    ngInfo.替换后治具孔号 = iIndex;
                    ngInfo.后治具生产批次号 = nowFixture.治具生产批次号;
                    BLLFactory<物料ng替换记录表>.Instance.Insert(ngInfo);  //写入一条数据到数据库中

                    preFixture.RemoveMaterialItem(thMaterialItem);
                    nowFixture.RemoveMaterialItem(ngMaterialItem);
                    nowFixture.InsertMaterialItem(iIndex, thMaterialItem);

                    dataSend = Encoding.UTF8.GetBytes("NGTH Done"); //返回下位机"NG替换完成"
                    listener.SendMesAsyncToClient(client, dataSend);
                    break;
                case Header.XT:

                    break;
            }

            ItemManager.Instance.Save(); //每通讯一次就保存一次内存数据
        }
    }

    //定义协议头
    public enum Header  
    {
        CX,
        XR,
        NGTH,
        XT
    }
}
