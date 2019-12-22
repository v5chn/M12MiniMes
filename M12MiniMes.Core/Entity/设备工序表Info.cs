using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using WHC.Framework.ControlUtil;

namespace M12MiniMes.Entity
{
    /// <summary>
    /// 设备工序表Info
    /// </summary>
    [DataContract]
    [Serializable]
    public class 设备工序表Info : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public 设备工序表Info()
		{
            this.工序id= 0;
              this.设备id= 0;
   
		}

        #region Property Members
        
        /// <summary>
        /// 工序ID
        /// </summary>
		[DataMember]
        public virtual int 工序id { get; set; }

        /// <summary>
        /// 工序名称
        /// </summary>
		[DataMember]
        public virtual string 工序名称 { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
		[DataMember]
        public virtual int 设备id { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
		[DataMember]
        public virtual string 设备名称 { get; set; }


        #endregion

    }
}