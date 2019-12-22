using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using WHC.Pager.Entity;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using Microsoft.Practices.EnterpriseLibrary.Data;
using M12MiniMes.Entity;
using M12MiniMes.IDAL;

namespace M12MiniMes.DALSQL
{
    /// <summary>
    /// 设备工序表
    /// </summary>
	public class 设备工序表 : BaseDALSQL<设备工序表Info>, I设备工序表
	{
		#region 对象实例及构造函数

		public static 设备工序表 Instance
		{
			get
			{
				return new 设备工序表();
			}
		}
		public 设备工序表() : base("设备工序表","工序ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override 设备工序表Info DataReaderToEntity(IDataReader dataReader)
		{
			设备工序表Info info = new 设备工序表Info();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.工序id = reader.GetInt32("工序ID");
			info.工序名称 = reader.GetString("工序名称");
			info.设备id = reader.GetInt32("设备ID");
			info.设备名称 = reader.GetString("设备名称");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(设备工序表Info obj)
		{
		    设备工序表Info info = obj as 设备工序表Info;
			Hashtable hash = new Hashtable(); 
			
 			hash.Add("工序名称", info.工序名称);
 			hash.Add("设备ID", info.设备id);
 			hash.Add("设备名称", info.设备名称);
 				
			return hash;
		}

        /// <summary>
        /// 获取字段中文别名（用于界面显示）的字典集合
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            #region 添加别名解析
            //dict.Add("ID", "编号");
             dict.Add("工序名称", "工序名称");
             dict.Add("设备id", "设备ID");
             dict.Add("设备名称", "设备名称");
             #endregion

            return dict;
        }
		
        /// <summary>
        /// 指定具体的列表显示字段
        /// </summary>
        /// <returns></returns>
        public override string GetDisplayColumns()
        {
            return "工序ID,工序名称,设备ID,设备名称";
        }
    }
}