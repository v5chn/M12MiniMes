using M12MiniMes.BLL;
using M12MiniMes.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHC.Framework.ControlUtil;

namespace M12MiniMes.UIStart
{
    /// <summary>
    /// 设备Item
    /// </summary>
    [Serializable]
    public class MachineItem : 设备表Info
    {
        /// <summary>
        /// 内存储存当前在产的该设备上的所有治具信息
        /// </summary>
        public BindingList<FixtureItem> CurrentFixtureItems { get; set; } = new BindingList<FixtureItem>();

        /// <summary>
        /// 内存储存当前在产的设备的所有治具的所有物料数据汇总
        /// </summary>
        public List<MaterialItem> CurrentMaterialItems
        {
            get
            {
                List<MaterialItem> items = new List<MaterialItem>();
                foreach (var p in this.CurrentFixtureItems)
                {
                    if (p.MaterialItems != null && p.MaterialItems.Count > 0)
                    {
                        items = items.Union(p.MaterialItems).ToList();
                    }
                }
                return items;
            }
        }

        public bool InsertFixtureItem(FixtureItem fItem)
        {
            if (!this.CurrentFixtureItems.Contains(fItem))
            {
                this.CurrentFixtureItems.Add(fItem);
                fItem.SetMachineItem(this);
                return true;
            }
            return false;
        }

        public bool RemoveFixtureItem(FixtureItem fItem)
        {
            if (this.CurrentFixtureItems.Contains(fItem))
            {
                this.CurrentFixtureItems.Remove(fItem);
                fItem.SetMachineItem(null);
                return true;
            }
            return false;
        }

        public List<设备工序表Info> Get设备工序列表()
        {
            string condition = $@" (设备id = {this.设备id})";
            List<设备工序表Info> list = BLLFactory<设备工序表>.Instance.Find(condition);
            return list;
        }
    }
}
