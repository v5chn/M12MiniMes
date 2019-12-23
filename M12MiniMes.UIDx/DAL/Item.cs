using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<MaterialItem> MaterialItems { get; private set; } = new List<MaterialItem>(12);

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


}
