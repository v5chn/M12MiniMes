using Faster.Core;
using M12MiniMes.BLL;
using M12MiniMes.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHC.Framework.ControlUtil;
using Faster.Core;

namespace M12MiniMes.UIStart
{

    [Serializable]
    public class ItemManager
    {
        private static ItemManager instance;
        public static ItemManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemManager();
                }
                return instance;
            }
        }
        private ItemManager()
        {
        }
        public bool Save()
        {
            CommonSerializer.SaveObjAsBinaryFile(this.MachineItems, $@".\MachineItems.xml", out bool bSaveOK, out Exception ex);
            return bSaveOK;
        }

        public bool Load()
        {
            this.MachineItems = CommonSerializer.LoadObjFormBinaryFile<BindingList<MachineItem>>($@".\MachineItems.xml", out bool bLoadOK, out Exception ex);
            return bLoadOK;
        }

        public List<生产批次生成表Info> Get当前在产批次列表()
        {
            string condition = $@" (计划投入数 > 0) and (计划投入数 > 上线数)";
            List<生产批次生成表Info> list = BLLFactory<生产批次生成表>.Instance.Find(condition);
            return list;
        }

        /// <summary>
        /// 从数据库设备表中同步
        /// </summary>
        public void GetMachineItems() 
        {
            List<设备表Info> list = BLLFactory<设备表>.Instance.GetAll();
            var var = list.Select(p => new MachineItem() 
            {
                设备id = p.设备id,
                设备名称 = p.设备名称,
                Ip = p.Ip
            }).ToList();
            this.MachineItems = new BindingList<MachineItem>(var);
        }

        /// <summary>
        /// 内存储存当前在产的所有设备数据
        /// </summary>
        public BindingList<MachineItem> MachineItems { get; private set; }

        /// <summary>
        /// 内存储存当前在产的所有设备的所有治具的数据汇总
        /// </summary>
        public List<FixtureItem> AllCurrentFixtureItems
        {
            get
            {
                List<FixtureItem> items = new List<FixtureItem>();
                foreach (var p in this.MachineItems)
                {
                    if (p.CurrentFixtureItems != null && p.CurrentFixtureItems.Count > 0)
                    {
                        items = items.Union(p.CurrentFixtureItems).ToList();
                    }
                }
                return items;
            }
        }

        /// <summary>
        /// 内存储存当前在产的所有设备的所有治具的所有物料数据汇总
        /// </summary>
        public List<MaterialItem> AllCurrentMaterialItems
        {
            get
            {
                List<MaterialItem> items = new List<MaterialItem>();
                this.AllCurrentFixtureItems?.ForEach(p =>
                {
                    if (p.MaterialItems != null && p.MaterialItems.Count > 0)
                    {
                        items = items.Union(p.MaterialItems).ToList();
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
        public FixtureItem GetCurrentFixtureItemByRFID(string RFID)
        {
            if (string.IsNullOrEmpty(RFID))
            {
                throw new Exception("RFID为空！");
            }
            return this.AllCurrentFixtureItems?.FirstOrDefault(p => p.RFID.Equals(RFID));
        }

        /// <summary>
        /// 通过设备ID获取该设备信息Item
        /// </summary>
        /// <param name="machineID"></param>
        /// <returns></returns>
        public MachineItem GetMachineItemByID(string machineID)
        {
            MachineItem tempMachineItem = this.MachineItems?.FirstOrDefault(p => p.设备id.ToString().Equals(machineID));
            if (tempMachineItem == null)
            {
                throw new Exception($@"ID为[{machineID}]的设备不存在！");
            }
            return tempMachineItem;
        }

        /// <summary>
        /// 通过设备IP地址获取该设备信息Item
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public MachineItem GetMachineItemByIP(string ip)
        {
            MachineItem tempMachineItem = this.MachineItems?.FirstOrDefault(p => p.Ip.Equals(ip));
            if (tempMachineItem == null)
            {
                LogService.Error($@"IP为[{ip}]的设备不存在！");
                throw new Exception($@"IP为[{ip}]的设备不存在！");
            }
            return tempMachineItem;
        }

        /// <summary>
        /// 根据治具RFID和流入设备ID查询当前在产的治具信息
        /// </summary>
        /// <param name="RFID"></param>
        /// <returns></returns>
        public FixtureItem GetFixtureItem(string RFID, string machineID)
        {
            MachineItem tempMachineItem = GetMachineItemByID(machineID);
            FixtureItem tempFixtureItem = GetCurrentFixtureItemByRFID(RFID);
            if (tempFixtureItem == null || machineID == "0") //找不到该RFID的治具时就赋予一个新的，或是在线头设备表示治具回流或流入新治具
            {
                tempFixtureItem?.Dispose();  //清空治具原携带信息
                tempFixtureItem = new FixtureItem();
                tempFixtureItem.RFID = RFID;
                //添加12个null物料信息
                for (int i = 0; i < 12; i++)
                {
                    tempFixtureItem.MaterialItems.Add(null);
                }
            }
            tempMachineItem.InsertFixtureItem(tempFixtureItem); //更新治具所在设备
            return tempFixtureItem;
        }

        /// <summary>
        /// 写入生产数据
        /// </summary>
        /// <param name="RFID"></param>
        /// <param name="machineID"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool XR(string RFID, string machineID, string data)
        {
            try
            {
                var var = GetFixtureItem(RFID, machineID);
                if (var != null)
                {
                    //查询该设备工序ID
                    var varm = GetMachineItemByID(machineID);
                    string machineName = varm.设备名称;
                    string condition = $@"设备ID = {machineID}";

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
        public bool TL(string machineID, string pc, string type, string numbers)
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
    }
}
