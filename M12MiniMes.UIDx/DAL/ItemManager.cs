using M12MiniMes.BLL;
using M12MiniMes.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHC.Framework.ControlUtil;

namespace M12MiniMes.UI.DAL
{

    public static class ItemManager
    {
        public static List<生产批次生成表Info> Get当前在产批次列表()
        {
            string condition = $@" (镜框投料数 > 上线数)";
            List<生产批次生成表Info> list = BLLFactory<生产批次生成表>.Instance.Find(condition);
            return list;
        }

        /// <summary>
        /// 内存储存当前在产的所有设备数据
        /// </summary>
        public static List<MachineItem> AllCurrentMachineItems { get; private set; } = new List<MachineItem>();

        /// <summary>
        /// 内存储存当前在产的所有设备的所有治具的数据汇总
        /// </summary>
        public static List<FixtureItem> AllCurrentFixtureItems
        {
            get
            {
                List<FixtureItem> items = new List<FixtureItem>();
                AllCurrentMachineItems?.ForEach(p =>
                {
                    if (p.CurrentFixtureItems != null && p.CurrentFixtureItems.Count > 0)
                    {
                        items = items.Union(p.CurrentFixtureItems).ToList();
                    }
                });
                return items;
            }
        }

        /// <summary>
        /// 通过RFID获取当前在产的治具
        /// </summary>
        /// <param name="RFID"></param>
        /// <returns></returns>
        public static FixtureItem GetCurrentFixtureItemByRFID(string RFID)
        {
            if (string.IsNullOrEmpty(RFID))
            {
                throw new Exception("RFID为空！");
            }
            return AllCurrentFixtureItems?.FirstOrDefault(p => p.RFID.Equals(RFID));
        }

        /// <summary>
        /// 通过设备ID获取该设备信息Item
        /// </summary>
        /// <param name="machineID"></param>
        /// <returns></returns>
        public static MachineItem GetCurrentMachineItem(string machineID)
        {
            MachineItem tempMachineItem = AllCurrentMachineItems?.FirstOrDefault(p => p.设备id.Equals(machineID));
            if (tempMachineItem == null)
            {
                throw new Exception($@"ID为[{machineID}]的设备不存在！");
            }
            return tempMachineItem;
        }

        /// <summary>
        /// 根据治具RFID和流入设备ID查询当前在产的治具信息
        /// </summary>
        /// <param name="RFID"></param>
        /// <returns></returns>
        public static FixtureItem GetFixtureItem(string RFID, string machineID)
        {
            MachineItem tempMachineItem = GetCurrentMachineItem(machineID);
            FixtureItem tempFixtureItem = GetCurrentFixtureItemByRFID(RFID);
            if (tempFixtureItem != null) //已存在 则表示回流  清空治具原携带信息
            {
                if (machineID == "0") //1#线头设备
                {
                    //检测到治具回流  清空治具原携带信息
                    tempFixtureItem.Dispose();
                    tempFixtureItem = new FixtureItem();
                }
            }
            tempFixtureItem.SetMachineItem(tempMachineItem); //更新治具所在设备
            return tempFixtureItem;
        }

        /// <summary>
        /// 写入生产数据
        /// </summary>
        /// <param name="RFID"></param>
        /// <param name="machineID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool XR(string RFID, string machineID, string data)
        {
            try
            {
                var var = GetFixtureItem(RFID, machineID);
                if (var != null)
                {
                    //查询该设备工序ID和工序名称
                    var varm = GetCurrentMachineItem(machineID);
                    string machineName = varm.设备名称;
                    string condition = $@"设备ID = {machineID}";
                    var varl = BLLFactory<设备工序表>.Instance.Find(condition);
                    var vari = varl.First();
                    if (vari == null)
                    {
                        throw new Exception("该设备无工序!");
                    }
                    string[] datas = data.Split(',');
                    foreach (var item in datas)
                    {
                        生产数据表Info info = new 生产数据表Info();
                        info.治具rfid = RFID;
                        BLLFactory<生产数据表>.Instance.Insert(info);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 写入投料数据
        /// </summary>
        /// <param name="machineID">设备ID</param>
        /// <param name="pc">生产批次号</param>
        /// <param name="type">投料类型 "镜框投料数"\"隔圈投料数"\"镜片投料数"</param>
        /// <returns></returns>
        public static bool TL(string machineID, string pc, string type, string numbers)
        {
            try
            {
                var var = Get当前在产批次列表();
                var var2 = var.FirstOrDefault(p => p.生产批次号.Equals(pc));
                if (var2 == null)
                {
                    return false;
                }
                else
                {
                    int number = int.Parse(numbers);
                    switch (type)
                    {
                        case "镜框投料数":
                            var2.镜框投料数 = number;
                            break;
                        case "隔圈投料数":
                            var2.隔圈投料数 = number;
                            break;
                        case "镜片投料数":
                            var2.镜片投料数 = number;
                            break;
                        default:
                            throw new Exception($@"不支持的投料类型[{type}]！");
                            break;
                    }
                    bool b = BLLFactory<生产批次生成表>.Instance.Update(var2, var2.生产批次id);
                    return b;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 内存储存当前在产的所有设备的所有治具的所有物料数据汇总
        /// </summary>
        public static List<MaterialItem> AllCurrentMaterialItems
        {
            get
            {
                List<MaterialItem> items = new List<MaterialItem>();
                AllCurrentFixtureItems?.ForEach(p =>
                {
                    if (p.MaterialItems != null && p.MaterialItems.Count > 0)
                    {
                        items = items.Union(p.MaterialItems).ToList();
                    }
                });
                return items;
            }
        }
    }
}
