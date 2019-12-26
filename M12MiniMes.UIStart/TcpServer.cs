using CommunicateCenter;
using Faster.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

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
                return;
            }
            string strHeader = mess[0]; //行头
            if (!Enum.GetNames(typeof(Header)).Contains(strHeader)) //不在定义的行头
            {
                //未定义的通讯格式！;
                return;
            }

            IPAddress ip = ((IPEndPoint)client.RemoteEndPoint).Address;
            string strIP = ip.ToString();
            //找到该地址对应的设备信息
            MachineItem machineItem = ItemManager.Instance.MachineItems.FirstOrDefault(p => p.Ip == strIP);
            if (machineItem == null)
            {
                throw new Exception($@"设备信息无该记录IP {strIP} ，请先进行同步！");
            }

            Header header = (Header)Enum.Parse(typeof(Header), strHeader);
            string[] parameters = mess.Skip(1).ToArray();
            string strInMachineID = ""; //当前设备ID
            string strCMachineID = ""; //被查询设备ID
            string rfid = "";
            FixtureItem fixtureItem = null; //当前治具
            byte[] dataSend = null;
            switch (header)
            {
                case Header.CX:
                    strInMachineID = parameters[0];  
                    strCMachineID = parameters[1]; 
                    rfid = parameters[2];
                    fixtureItem = ItemManager.Instance.GetFixtureItem(rfid, strInMachineID);
                    if (fixtureItem == null) //找不到该RFID治具的内存信息
                    {

                    }
                    string strData = $@"CX,{strCMachineID},{rfid},{fixtureItem.治具生产批次号},";
                    foreach (var item in fixtureItem.MaterialItems)
                    {
                        var var = item.生产数据.Where(p => p.设备id.ToString() == strCMachineID);
                        var var2 = var.Select(p => p.工序数据).ToList();
                        foreach (var item2 in var2)
                        {
                            strData += $@"{item2},";
                        }
                    }
                    dataSend = Encoding.UTF8.GetBytes(strData);
                    listener.SendMesAsyncToClient(client, dataSend);
                    break;
                case Header.XR:
                    rfid = parameters[0];
                    strInMachineID = parameters[1];
                    fixtureItem = ItemManager.Instance.GetFixtureItem(rfid, strInMachineID);
                    if (fixtureItem == null) //找不到该RFID治具的内存信息
                    {

                    }

                    break;
                case Header.NGTH:

                    break;
                case Header.XT:

                    break;
            }
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
