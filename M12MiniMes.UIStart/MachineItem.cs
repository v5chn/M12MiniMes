using M12MiniMes.BLL;
using M12MiniMes.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WHC.Framework.ControlUtil;

namespace M12MiniMes.UIStart
{
    /// <summary>
    /// 设备Item
    /// </summary>
    [Serializable]
    public class MachineItem
    {
        #region Property Members  :设备表Info

        /// <summary>
        /// 设备ID
        /// </summary>
        //[field: NonSerialized]
        public int 设备id { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        //[field: NonSerialized]
        public string 设备名称 { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        //[field: NonSerialized]
        public string Ip { get; set; }

        #endregion

        /// <summary>
        /// 内存储存当前在产的该设备上的所有治具信息
        /// </summary>
        public List<FixtureItem> CurrentFixtureItems { get; set; } = new List<FixtureItem>();

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

        /// <summary>
        /// 指定治具FixtureItem插入到指定设备MachineItem中
        /// </summary>
        /// <param name="fItem"></param>
        /// <returns></returns>
        public bool InsertFixtureItem(FixtureItem fItem)
        {
            if (fItem != null && fItem.RFID != null)
            {
                //找出相同RFID的治具
                var var = ItemManager.Instance.AllCurrentFixtureItems.Where(p => p.RFID.Equals(fItem.RFID));
                if (var.Count() > 1)
                {
                    MessageBox.Show($@"已具有相同RFID[{fItem.RFID}]的治具！");
                    return false ;
                }
            }
            if (!this.CurrentFixtureItems.Contains(fItem)) //如果不包含
            {
                //fItem.SetMachineItem(null);
                //fItem.SetMachineItem(this);
                ////不管三七二十一，先把所有设备删掉该治具fItem再说
                //foreach (MachineItem item in ItemManager.Instance.MachineItems)
                //{
                //    item.RemoveFixtureItem(fItem);
                //}

                this.CurrentFixtureItems.Add(fItem);
                return true;
            }
            return false;
        }

        public bool RemoveFixtureItem(FixtureItem fItem)
        {
            if (this.CurrentFixtureItems.Contains(fItem))
            {
                this.CurrentFixtureItems.Remove(fItem);
                return true;
            }
            return false;
        }
    }
}
