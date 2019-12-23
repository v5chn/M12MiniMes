using M12MiniMes;
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
    /// <summary>
    /// 治具Item
    /// </summary>
    public class FixtureItem
    {
        /// <summary>
        /// 治具上RFID扫描出
        /// </summary>
        public string RFID;

        /// <summary>
        /// 治具有12个孔位，记录12个物料信息
        /// </summary>
        public List<MaterialItem> MaterialItems { get; set; } = new List<MaterialItem>();

        /// <summary>
        /// 所在设备信息
        /// </summary>
        public MachineItem MachineItem { get; set; }

        public Guid Guid { get; }

        public string 生产批次号 { get; set; }

        /// <summary>
        /// 根据物料获取孔号iHoleIndex（0至11），若该治具不携带该物料则返回-1.
        /// </summary>
        public int this[MaterialItem materialItem]
        {
            get
            {
                return MaterialItems?.IndexOf(materialItem) ?? -1;
            }
        }

        public FixtureItem() 
        {
            this.Guid = Guid.NewGuid();
        }
    }

    /// <summary>
    /// 物料Item
    /// </summary>
    public class MaterialItem
    {
        public FixtureItem fixture { get; }

        public Guid Guid { get; }

        public MaterialItem() 
        {
            this.Guid = Guid.NewGuid();
        }

        public MaterialItem(FixtureItem fixture) 
        {
            this.fixture = fixture;
            this.Guid = Guid.NewGuid();
        }
    }

    /// <summary>
    /// 设备Item
    /// </summary>
    public class MachineItem: 设备表Info
    {
        /// <summary>
        /// 该设备上的所有治具
        /// </summary>
        public List<FixtureItem> FixtureItems { get; private set; } = new List<FixtureItem>();
    }

    public static class ItemManager 
    {
        public static List<生产批次生成表Info> Get当前在产批次列表() 
        {
            string condition = $@" (计划投入数 >= 下线数)";
            List<生产批次生成表Info>  list = BLLFactory<生产批次生成表>.Instance.Find(condition);
            return list;
        }

        /// <summary>
        /// 所有设备数据
        /// </summary>
        public static List<MachineItem> AllMachineItems { get; } = new List<MachineItem>();

        /// <summary>
        /// 所有设备的所有治具的汇总
        /// </summary>
        public static List<FixtureItem> AllFixtureItems 
        {
            get 
            {
                List<FixtureItem> items = new List<FixtureItem>();
                AllMachineItems?.ForEach(p =>
                {
                    if (p.FixtureItems != null && p.FixtureItems.Count >0)
                    {
                        items = items.Union(p.FixtureItems).ToList();
                    }
                });
                return items;
            }
        }

        /// <summary>
        /// 所有设备的所有治具的所有物料汇总
        /// </summary>
        public static List<MaterialItem> AllMaterialItems
        {
            get
            {
                List<MaterialItem> items = new List<MaterialItem>();
                AllFixtureItems?.ForEach(p =>
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
