using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using WHC.Framework.ControlUtil;

namespace M12MiniMes.Entity
{
    /// <summary>
    /// Ng记录表Info
    /// </summary>
    [DataContract]
    [Serializable]
    public class Ng记录表Info : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Ng记录表Info()
		{
            this.Ng记录id= 0;
                  this.治具孔号= 0;
             this.设备id= 0;
   
		}

        #region Property Members
        
        /// <summary>
        /// NG记录ID
        /// </summary>
		[DataMember]
        public virtual int Ng记录id { get; set; }

        /// <summary>
        /// NG发生时间
        /// </summary>
		[DataMember]
        public virtual DateTime Ng发生时间 { get; set; }

        /// <summary>
        /// 生产批次号
        /// </summary>
		[DataMember]
        public virtual string 生产批次号 { get; set; }

        /// <summary>
        /// 物料GUID
        /// </summary>
		[DataMember]
        public virtual string 物料guid { get; set; }

        /// <summary>
        /// 治具GUID
        /// </summary>
		[DataMember]
        public virtual string 治具guid { get; set; }

        /// <summary>
        /// 治具RFID
        /// </summary>
		[DataMember]
        public virtual string 治具rfid { get; set; }

        /// <summary>
        /// 治具孔号
        /// </summary>
		[DataMember]
        public virtual int 治具孔号 { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
		[DataMember]
        public virtual int 设备id { get; set; }

        /// <summary>
        /// 工位号
        /// </summary>
		[DataMember]
        public virtual string 工位号 { get; set; }


        #endregion

    }
}