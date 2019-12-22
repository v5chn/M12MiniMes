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
    /// Ng记录表
    /// </summary>
	public class Ng记录表 : BaseDALSQL<Ng记录表Info>, INg记录表
	{
		#region 对象实例及构造函数

		public static Ng记录表 Instance
		{
			get
			{
				return new Ng记录表();
			}
		}
		public Ng记录表() : base("NG记录表","NG记录ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Ng记录表Info DataReaderToEntity(IDataReader dataReader)
		{
			Ng记录表Info info = new Ng记录表Info();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.Ng记录id = reader.GetInt32("NG记录ID");
			info.Ng发生时间 = reader.GetDateTime("NG发生时间");
			info.生产批次号 = reader.GetString("生产批次号");
			info.物料guid = reader.GetString("物料GUID");
			info.治具guid = reader.GetString("治具GUID");
			info.治具rfid = reader.GetString("治具RFID");
			info.治具孔号 = reader.GetInt32("治具孔号");
			info.设备id = reader.GetInt32("设备ID");
			info.工位号 = reader.GetString("工位号");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Ng记录表Info obj)
		{
		    Ng记录表Info info = obj as Ng记录表Info;
			Hashtable hash = new Hashtable(); 
			
 			hash.Add("NG发生时间", info.Ng发生时间);
 			hash.Add("生产批次号", info.生产批次号);
 			hash.Add("物料GUID", info.物料guid);
 			hash.Add("治具GUID", info.治具guid);
 			hash.Add("治具RFID", info.治具rfid);
 			hash.Add("治具孔号", info.治具孔号);
 			hash.Add("设备ID", info.设备id);
 			hash.Add("工位号", info.工位号);
 				
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
             dict.Add("Ng发生时间", "NG发生时间");
             dict.Add("生产批次号", "生产批次号");
             dict.Add("物料guid", "物料GUID");
             dict.Add("治具guid", "治具GUID");
             dict.Add("治具rfid", "治具RFID");
             dict.Add("治具孔号", "治具孔号");
             dict.Add("设备id", "设备ID");
             dict.Add("工位号", "工位号");
             #endregion

            return dict;
        }
		
        /// <summary>
        /// 指定具体的列表显示字段
        /// </summary>
        /// <returns></returns>
        public override string GetDisplayColumns()
        {
            return "NG记录ID,NG发生时间,生产批次号,物料GUID,治具GUID,治具RFID,治具孔号,设备ID,工位号";
        }
    }
}