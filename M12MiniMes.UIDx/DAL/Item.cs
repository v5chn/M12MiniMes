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
    [Serializable]
    public class FixtureItem :IDisposable
    {
        /// <summary>
        /// 治具上RFID扫描出
        /// </summary>
        public string RFID;

        /// <summary>
        /// 治具有12个孔位，记录12个物料信息
        /// </summary>
        public List<MaterialItem> MaterialItems { get; set; } = new List<MaterialItem>(12);

        /// <summary>
        /// 当前治具所在的设备信息，可以为null
        /// </summary>
        public MachineItem MachineItem { get; private set; }
        
        /// <summary>
        /// 治具GUID
        /// </summary>
        public Guid FixtureGuid { get; private set; }

        public string 治具生产批次号 { get; set; }

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
            this.FixtureGuid = Guid.NewGuid();
        }

        /// <summary>
        /// 设置当前治具所在设备
        /// </summary>
        /// <param name="fixture"></param>
        public void SetMachineItem(MachineItem machine)
        {
            this.MachineItem = machine;
        }

        public bool InsertMaterialItem(int index ,MaterialItem mItem) 
        {
            try
            {
                if (index >=12)
                {
                    throw new Exception("孔号索引不能超过12（正常范围0-11）！");
                }
                if (!this.MaterialItems.Contains(mItem))
                {
                    this.MaterialItems.Insert(index, mItem);
                    mItem.SetFixtureItem(this);
                    return true;
                }
                MaterialItem mpItem = this.MaterialItems[index];
                if (mpItem != null)
                {
                    throw new Exception("插入位置已存在一个物料！");
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveMaterialItem(MaterialItem mItem)
        {
            if (this.MaterialItems.Contains(mItem))
            {
                this.MaterialItems.Remove(mItem);
                mItem.SetFixtureItem(null);
                return true;
            }
            return false;
        }

        public bool RemoveMaterialItemByIndex(int index)
        {
            try
            {
                MaterialItem mItem = this.MaterialItems[index];
                if (mItem != null)
                {
                    mItem.SetFixtureItem(null);
                    this.MaterialItems.RemoveAt(index); //删除旧值
                    this.MaterialItems.Insert(index, null); //插入新值，保持List为12个
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Clear() 
        {
            this.Dispose();
        }

        #region IDisposable 成员

        public void Dispose()
        {
            this.MaterialItems.Clear();
            this.MaterialItems = null;
            this.RFID = null;
            this.FixtureGuid = Guid.Empty;
            this.治具生产批次号 = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect(0);
        }
        #endregion
    }

    /// <summary>
    /// 物料Item
    /// </summary>
    [Serializable]
    public class MaterialItem
    {
        /// <summary>
        /// 记忆当前物料所在的治具信息，可以为null表示不处于任何治具之中
        /// </summary>
        public FixtureItem Fixture { get; private set; }

        /// <summary>
        /// 物料GUID
        /// </summary>
        public Guid MaterialGuid { get; }

        public string 物料生产批次号 { get; set; }

        public MaterialItem() 
        {
            this.MaterialGuid = Guid.NewGuid();
        }

        public MaterialItem(FixtureItem fixture) 
        {
            this.Fixture = fixture;
            this.MaterialGuid = Guid.NewGuid();
            this.物料生产批次号 = fixture?.治具生产批次号;
        }

        /// <summary>
        /// 设置当前物料所在治具
        /// </summary>
        /// <param name="fixture"></param>
        public void SetFixtureItem(FixtureItem fixture) 
        {
            this.Fixture = fixture;
        }

        /// <summary>
        /// 获取所在治具上所处孔位索引（0-11），若不在任何治具上则返回-1
        /// </summary>
        /// <returns></returns>
        public int GetHoleIndexInFixture() 
        {
            return this.Fixture?[this] ?? -1;
        }
    }

    /// <summary>
    /// 设备Item
    /// </summary>
    [Serializable]
    public class MachineItem: 设备表Info
    {
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
                this.CurrentFixtureItems?.ForEach(p =>
                {
                    if (p.MaterialItems != null && p.MaterialItems.Count > 0)
                    {
                        items = items.Union(p.MaterialItems).ToList();
                    }
                });
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
