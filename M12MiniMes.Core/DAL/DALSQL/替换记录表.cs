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
    /// 替换记录表
    /// </summary>
	public class 替换记录表 : BaseDALSQL<替换记录表Info>, I替换记录表
	{
		#region 对象实例及构造函数

		public static 替换记录表 Instance
		{
			get
			{
				return new 替换记录表();
			}
		}
		public 替换记录表() : base("替换记录表","替换记录ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override 替换记录表Info DataReaderToEntity(IDataReader dataReader)
		{
			替换记录表Info info = new 替换记录表Info();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.替换记录id = reader.GetInt32("替换记录ID");
			info.替换时间 = reader.GetDateTime("替换时间");
			info.生产批次号 = reader.GetString("生产批次号");
			info.物料guid = reader.GetString("物料GUID");
			info.替换前治具guid = reader.GetString("替换前治具GUID");
			info.替换前治具rfid = reader.GetString("替换前治具RFID");
			info.替换前治具孔号 = reader.GetInt32("替换前治具孔号");
			info.替换后治具guid = reader.GetString("替换后治具GUID");
			info.替换后治具rfid = reader.GetString("替换后治具RFID");
			info.替换后治具孔号 = reader.GetInt32("替换后治具孔号");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(替换记录表Info obj)
		{
		    替换记录表Info info = obj as 替换记录表Info;
			Hashtable hash = new Hashtable(); 
			
 			hash.Add("替换时间", info.替换时间);
 			hash.Add("生产批次号", info.生产批次号);
 			hash.Add("物料GUID", info.物料guid);
 			hash.Add("替换前治具GUID", info.替换前治具guid);
 			hash.Add("替换前治具RFID", info.替换前治具rfid);
 			hash.Add("替换前治具孔号", info.替换前治具孔号);
 			hash.Add("替换后治具GUID", info.替换后治具guid);
 			hash.Add("替换后治具RFID", info.替换后治具rfid);
 			hash.Add("替换后治具孔号", info.替换后治具孔号);
 				
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
             dict.Add("替换时间", "替换时间");
             dict.Add("生产批次号", "生产批次号");
             dict.Add("物料guid", "物料GUID");
             dict.Add("替换前治具guid", "替换前治具GUID");
             dict.Add("替换前治具rfid", "替换前治具RFID");
             dict.Add("替换前治具孔号", "替换前治具孔号");
             dict.Add("替换后治具guid", "替换后治具GUID");
             dict.Add("替换后治具rfid", "替换后治具RFID");
             dict.Add("替换后治具孔号", "替换后治具孔号");
             #endregion

            return dict;
        }
		
        /// <summary>
        /// 指定具体的列表显示字段
        /// </summary>
        /// <returns></returns>
        public override string GetDisplayColumns()
        {
            return "替换记录ID,替换时间,生产批次号,物料GUID,替换前治具GUID,替换前治具RFID,替换前治具孔号,替换后治具GUID,替换后治具RFID,替换后治具孔号";
        }
    }
}