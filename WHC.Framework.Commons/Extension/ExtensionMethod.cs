﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WHC.Framework.Commons
{
    /// <summary>
    /// 扩展函数封装
    /// </summary>
    public static class ExtensionMethod
    {
        #region 日期操作

        /// <summary>
        /// 设置时间格式有效显示，如果大于默认时间，赋值给控件；否则不赋值
        /// </summary>
        /// <param name="control">DateEdit控件对象</param>
        /// <param name="dateTime">日期对象</param>
        public static void SetDateTime(this DateTimePicker control, DateTime dateTime)
        {
            if (dateTime > Convert.ToDateTime("1900-1-1"))
            {
                control.Value = dateTime;
            }
            else
            {
                control.Text = "";
            }
        }
        /// <summary>
        /// 设置时间格式有效显示，如果大于默认时间，赋值给控件；否则不赋值
        /// </summary>
        /// <param name="control">DateEdit控件对象</param>
        /// <param name="dateTime">日期对象</param>
        public static void SetDateTime(this DateTimePicker control, DateTime? dateTime)
        {
            if (dateTime.HasValue && dateTime > Convert.ToDateTime("1900-1-1"))
            {
                control.Value = dateTime.Value;
            }
            else
            {
                control.Text = "";
            }
        }
        /// <summary>
        /// 获取时间的显示内容，如果小于默认时间（1900-1-1），则为空
        /// </summary>
        /// <param name="dateTime">时间对象</param>
        /// <param name="formatString">默认格式为yyyy-MM-dd</param>
        /// <returns></returns>
        public static string GetDateTimeString(this DateTime dateTime, string formatString = "yyyy-MM-dd")
        {
            string result = "";
            if (dateTime > Convert.ToDateTime("1900-1-1"))
            {
                result = dateTime.ToString(formatString);
            }
            return result;
        }
        /// <summary>
        /// 获取时间的显示内容，如果小于默认时间（1900-1-1），则为空
        /// </summary>
        /// <param name="dateTime">时间对象</param>
        /// <param name="formatString">默认格式为yyyy-MM-dd</param>
        /// <returns></returns>
        public static string GetDateTimeString(this DateTime? dateTime, string formatString = "yyyy-MM-dd")
        {
            string result = "";
            if (dateTime.HasValue && dateTime > Convert.ToDateTime("1900-1-1"))
            {
                result = dateTime.Value.ToString(formatString);
            }
            return result;
        }

        /// <summary>
        /// 获取指定日期，在一年中为第几周
        /// </summary>
        /// <param name="dateTime">指定时间</param>
        /// <reutrn>返回第几周</reutrn>
        public static int GetWeekOfYear(this DateTime dateTime, DayOfWeek week = DayOfWeek.Monday)
        {
            GregorianCalendar gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, week);
            return weekOfYear;
        }

        /// <summary>
        /// 扩展时间接口，可以返回整形数值
        /// </summary>
        /// <param name="time">指定时间</param>
        /// <returns></returns>
        public static int DateTimeToInt(this DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 扩展时间接口，可以返回整形数值
        /// </summary>
        /// <param name="time">指定时间</param>
        /// <returns></returns>
        public static int DateTimeToInt(this DateTime? time)
        {
            if (time.HasValue)
            {
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
                return (int)(time.Value - startTime).TotalSeconds;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换微信的整形数值到系统时间
        /// </summary>
        /// <param name="longTicks">int类型的时间</param>
        /// <returns></returns>
        public static DateTime IntToDateTime(this int longTicks)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(longTicks.ToString() + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// 转换微信的整形数值到系统时间
        /// </summary>
        /// <param name="longTicks">int类型的时间</param>
        /// <returns></returns>
        public static DateTime IntToDateTime(this long longTicks)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(longTicks.ToString() + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        #endregion

        #region 查询控件扩展函数
        /// <summary>
        /// 添加开始日期和结束日期的查询操作
        /// </summary>
        /// <param name="condition">SearchCondition对象</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="startCtrl">开始日期控件</param>
        /// <param name="endCtrl">结束日期控件</param>
        /// <returns></returns>
        public static SearchCondition AddDateCondition(this SearchCondition condition, string fieldName, DateTimePicker startCtrl, DateTimePicker endCtrl)
        {
            if (startCtrl.Text.Length > 0)
            {
                condition.AddCondition(fieldName, startCtrl.Value, SqlOperator.MoreThanOrEqual);
            }
            if (endCtrl.Text.Length > 0)
            {
                condition.AddCondition(fieldName, endCtrl.Value.AddDays(1), SqlOperator.LessThan);
            }
            return condition;
        }

        /// <summary>
        /// 添加开始日期和结束日期的查询操作
        /// </summary>
        /// <param name="condition">SearchCondition对象</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public static SearchCondition AddDateCondition(this SearchCondition condition, string fieldName, string startDate, string endDate)
        {
            DateTime date;
            if (!string.IsNullOrEmpty(startDate) && DateTime.TryParse(startDate, out date))
            {
                condition.AddCondition(fieldName, date, SqlOperator.MoreThanOrEqual);
            }

            if (!string.IsNullOrEmpty(endDate) && DateTime.TryParse(endDate, out date))
            {
                condition.AddCondition(fieldName, date.AddDays(1), SqlOperator.LessThan);
            }
            return condition;
        }

        /// <summary>
        /// 添加开始日期和结束日期的查询操作
        /// </summary>
        /// <param name="condition">SearchCondition对象</param>
        /// <param name="fieldName">字段名称</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public static SearchCondition AddDateCondition(this SearchCondition condition, string fieldName, DateTime? startDate, DateTime? endDate)
        {
            if (startDate.HasValue)
            {
                condition.AddCondition(fieldName, startDate.Value, SqlOperator.MoreThanOrEqual);
            }
            if (endDate.HasValue)
            {
                condition.AddCondition(fieldName, endDate.Value.AddDays(1), SqlOperator.LessThan);
            }
            return condition;
        }
        #endregion

        #region ComboBox控件

        /// <summary>
        /// 获取下拉列表的值
        /// </summary>
        /// <param name="combo">下拉列表</param>
        /// <returns></returns>
        public static string GetComboBoxValue(this ComboBox combo)
        {
            CListItem item = combo.SelectedItem as CListItem;
            if (item != null)
            {
                return item.Value;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 设置下拉列表选中指定的值
        /// </summary>
        /// <param name="combo">下拉列表</param>
        /// <param name="value">指定的CListItem中的值</param>
        public static int SetDropDownValue(this ComboBox combo, string value)
        {
            int result = -1;
            for (int i = 0; i < combo.Items.Count; i++)
            {
                if (combo.Items[i].ToString() == value)
                {
                    combo.SelectedIndex = i;
                    result = i;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 设置下拉列表选中指定的值
        /// </summary>
        /// <param name="combo">下拉列表</param>
        /// <param name="value">指定的CListItem中的值</param>
        public static void SetComboBoxItem(this ComboBox combo, string value)
        {
            for (int i = 0; i < combo.Items.Count; i++)
            {
                CListItem item = combo.Items[i] as CListItem;
                if (item != null && item.Value == value)
                {
                    combo.SelectedIndex = i;
                }
            }
        }

        /// <summary>
        /// 绑定下拉列表控件为指定的数据字典列表
        /// </summary>
        /// <param name="combo">下拉列表控件</param>
        /// <param name="dict">数据字典</param>
        public static void BindDictItems(this ComboBox combo, Dictionary<string, string> dict)
        {
            combo.Items.Clear();
            foreach (string key in dict.Keys)
            {
                combo.Items.Add(new CListItem(key, dict[key]));
            }
        }

        /// <summary>
        /// 绑定下拉列表控件为指定的数据字典列表
        /// </summary>
        /// <param name="combo">下拉列表控件</param>
        /// <param name="itemList">数据字典列表</param>
        public static void BindDictItems(this ComboBox combo, List<CListItem> itemList)
        {
            BindDictItems(combo, itemList, null);
        }

        /// <summary>
        /// 绑定下拉列表控件为指定的数据字典列表
        /// </summary>
        /// <param name="combo">下拉列表控件</param>
        /// <param name="itemList">数据字典列表</param>
        /// <param name="defaultValue">控件默认值</param>
        public static void BindDictItems(this ComboBox combo, List<CListItem> itemList, string defaultValue)
        {
            combo.BeginUpdate();//可以加快
            combo.Items.Clear();
            combo.Items.AddRange(itemList.ToArray());

            if (!string.IsNullOrEmpty(defaultValue))
            {
                combo.SetComboBoxItem(defaultValue);
            }

            combo.EndUpdate();//可以加快
        }
        
        /// <summary>
        /// 绑定枚举类型
        /// </summary>
        /// <param name="combo">下拉列表控件</param>
        public static void BindDictItems<T>(this ComboBox combo)
        {
            Dictionary<string, object> dict = EnumHelper.GetMemberKeyValue<T>();
            combo.BeginUpdate();//可以加快
            combo.Items.Clear();
            foreach (string key in dict.Keys)
            {
                combo.Items.Add(new CListItem(key, dict[key].ToString()));
            }
            combo.EndUpdate();//可以加快
        }

        #endregion

        #region CheckedListBox
        /// <summary>
        /// 设置下拉列表选中指定的值
        /// </summary>
        /// <param name="combo">下拉列表</param>
        /// <param name="value">指定的CListItem中的值</param>
        public static void SetComboBoxItem(this CheckedListBox combo, string value)
        {
            combo.SelectedValue = value;
        }

        /// <summary>
        /// 绑定下拉列表控件为指定的数据字典列表
        /// </summary>
        /// <param name="combo">下拉列表控件</param>
        /// <param name="itemList">数据字典列表</param>
        public static void BindDictItems(this CheckedListBox combo, List<CListItem> itemList)
        {
            BindDictItems(combo, itemList, null);
        }

        /// <summary>
        /// 绑定下拉列表控件为指定的数据字典列表
        /// </summary>
        /// <param name="combo">下拉列表控件</param>
        /// <param name="itemList">数据字典列表</param>
        /// <param name="defaultValue">默认值</param>
        public static void BindDictItems(this CheckedListBox combo, List<CListItem> itemList, string defaultValue)
        {
            combo.BeginUpdate();//可以加快
            combo.Items.Clear();
            combo.Items.AddRange(itemList.ToArray());//可以加快

            if (!string.IsNullOrEmpty(defaultValue))
            {
                combo.SetComboBoxItem(defaultValue);
            }

            combo.EndUpdate();//可以加快
        }

        #endregion

        #region DataGrid表格控件

        /// <summary>
        /// 设置表格的宽度
        /// </summary>
        /// <param name="gridView">表格控件</param>
        /// <param name="columnName">列名称</param>
        /// <param name="width">宽度</param>
        public static void SetGridColumWidth(this DataGridView gridView, string columnName, int width)
        {
            System.Windows.Forms.DataGridViewColumn column = null;
            if (gridView.Columns.Contains(columnName))
            {
                column = gridView.Columns[columnName];
                if (column != null)
                {
                    column.Width = width;
                }
            }
            else if (gridView.Columns.Contains(columnName.ToUpper()))
            {
                column = gridView.Columns[columnName.ToUpper()];
                if (column != null)
                {
                    column.Width = width;
                }
            }
        } 
        #endregion

        #region 控件设计状态判断

        /// <summary>
        /// 判断控件是否在设计模式下
        /// </summary>
        public static bool IsInDesignMode(this System.Windows.Forms.Control control)
        {
            return ResolveDesignMode(control);
        }

        /// <summary>
        /// 检查控件或者它的父控件是否在设计模式
        /// </summary>
        /// <param name="control">控件对象</param>
        /// <returns>如果是设计模式，返回true，否则为false</returns>
        private static bool ResolveDesignMode(this System.Windows.Forms.Control control)
        {
            System.Reflection.PropertyInfo designModeProperty;
            bool designMode;

            designModeProperty = control.GetType().GetProperty("DesignMode", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            designMode = (bool)designModeProperty.GetValue(control, null);

            if (control.Parent != null)
            {
                designMode |= ResolveDesignMode(control.Parent);
            }
            return designMode;
        }
        #endregion
    }
}
