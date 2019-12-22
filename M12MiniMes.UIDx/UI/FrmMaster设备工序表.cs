using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

using WHC.Pager.Entity;
using WHC.Dictionary;
using WHC.Framework.BaseUI;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;

using M12MiniMes.BLL;
using M12MiniMes.Entity;

namespace M12MiniMes.UI
{
    /// <summary>
    /// 设备表    
    /// </summary>	
    public partial class FrmMaster设备工序表 : BaseDock
    {
        public FrmMaster设备工序表()
        {
            InitializeComponent();

            InitDictItem();

			//主表列表信息
            this.winGridViewPager1.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            this.winGridViewPager1.OnStartExport += new EventHandler(winGridViewPager1_OnStartExport);
            this.winGridViewPager1.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);

             this.winGridViewPager1.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
             this.winGridViewPager1.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);

            this.winGridViewPager1.OnDeleteSelected += new EventHandler(winGridViewPager1_OnDeleteSelected);
            this.winGridViewPager1.AppendedMenu = this.contextMenuStrip1;
            this.winGridViewPager1.ShowLineNumber = true;
            this.winGridViewPager1.BestFitColumnWith = false;//是否设置为自动调整宽度，false为不设置
			this.winGridViewPager1.gridView1.DataSourceChanged +=new EventHandler(gridView1_DataSourceChanged);
            this.winGridViewPager1.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.winGridViewPager1.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);
            this.winGridViewPager1.gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;

			//从表明细信息
            this.winGridView2.OnRefresh += new EventHandler(winGridView2_OnRefresh);
            this.winGridView2.ShowLineNumber = true;
            this.winGridView2.BestFitColumnWith = false;;//是否设置为自动调整宽度，false为不设置
            this.winGridView2.gridView1.DataSourceChanged += new EventHandler(gridView2_DataSourceChanged);
            this.winGridView2.gridView1.CustomColumnDisplayText +=new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView2_CustomColumnDisplayText);
			
            this.chkTableDirection.CheckedChanged += new System.EventHandler(this.chkTableDirection_CheckedChanged);
			this.btnAddNew.Visible = true ; //如果需要显示，请设置为true，并打开相关注释代码

            //关联回车键进行查询
            foreach (Control control in this.layoutControl1.Controls)
            {
                control.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchControl_KeyUp);
            }
        }
		
        /// <summary>
        /// 编写初始化窗体的实现，可以用于刷新
        /// </summary>
        public override void  FormOnLoad()
        {   
            BindData();
        } 
        
        /// <summary>
        /// 初始化字典列表内容
        /// </summary>
        private void InitDictItem()
        {
			//初始化代码
			//this.txtCategory.BindDictItems("报销类型");
        }
		
        #region 主表列表信息
        /// <summary>
        /// 添加数据
        /// </summary>		
        private void AddData()
        {
            FrmEdit设备工序表 dlg = new FrmEdit设备工序表();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息
            
            if (DialogResult.OK == dlg.ShowDialog())
            {
                BindData();
            }
        }
        /// <summary>
        /// 编辑列表数据
        /// </summary>
        private void EditData()
        {
            string ID = this.winGridViewPager1.gridView1.GetFocusedRowCellDisplayText("设备id");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.winGridViewPager1.gridView1.RowCount; i++)
            {
                string strTemp = this.winGridViewPager1.GridView1.GetRowCellDisplayText(i, "设备id");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmEdit设备工序表 dlg = new FrmEdit设备工序表();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
                dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息
                
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    BindData();
                }
            }			
		}
		
        /// <summary>
        /// 删除选中列表数据
        /// </summary>		
        private void DeleteData()
        {
            if (MessageDxUtil.ShowYesNoAndTips("您确定删除选定的记录么？") == DialogResult.No)
            {
                return;
            }

            int[] rowSelected = this.winGridViewPager1.GridView1.GetSelectedRows();
            foreach (int iRow in rowSelected)
            {
                string ID = this.winGridViewPager1.GridView1.GetRowCellDisplayText(iRow, "设备id");
                BLLFactory<设备表>.Instance.Delete(ID);
            }
             
            BindData();			
		}		

        void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (e.Column.FieldName == "OrderStatus")
            //{
            //    string status = this.winGridViewPager1.gridView1.GetRowCellValue(e.RowHandle, "OrderStatus").ToString();
            //    Color color = Color.White;
            //    if (status == "已审核")
            //    {
            //        e.Appearance.BackColor = Color.Red;
            //        e.Appearance.BackColor2 = Color.LightCyan;
            //    }
            //}
        }
        void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
        	string columnName = e.Column.FieldName;
            if (e.Column.ColumnType == typeof(DateTime))
            {   
                if (e.Value != null)
                {
                    if (e.Value == DBNull.Value || Convert.ToDateTime(e.Value) <= Convert.ToDateTime("1900-1-1"))
                    {
                        e.DisplayText = "";
                    }
                    else
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd HH:mm");//yyyy-MM-dd
                    }
                }
            }
            //else if (fieldName == "Operator" || fieldName == "Editor" || fieldName == "Creator")
            //{
            //    if (e.Value != null)
            //    {
            //        e.DisplayText = SecurityHelper.GetFullNameByID(e.Value.ToString());
            //    }
            //}
            //else if (columnName == "Age")
            //{
            //    e.DisplayText = string.Format("{0}岁", e.Value);
            //}
            //else if (columnName == "ReceivedMoney")
            //{
            //    if (e.Value != null)
            //    {
            //        e.DisplayText = e.Value.ToString().ToDecimal().ToString("C");
            //    }
            //}
        }
        
        /// <summary>
        /// 绑定数据后，分配各列的宽度
        /// </summary>
        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.winGridViewPager1.gridView1.Columns.Count > 0 && this.winGridViewPager1.gridView1.RowCount > 0)
            {
                //统一设置100宽度
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.winGridViewPager1.gridView1.Columns)
                {
                    column.Width = 100;
                }

				GridView gridView = this.winGridViewPager1.gridView1;
                if (gridView != null)
                {
					//设备id,设备名称,位置序号,启用状态,生产状态
					//gridView.SetGridColumWidth("Note", 200);
                }
            }
        }

        /// <summary>
        /// 主表列表选择或者移动行焦点的触发事件操作
        /// </summary>
        void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //获取主表表头ID
            string headerID = this.winGridViewPager1.gridView1.GetFocusedRowCellDisplayText("设备id");
            BindDetail(headerID);
        }

        /// <summary>
        /// 分页控件刷新操作
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// 分页控件删除操作
        /// </summary>
        private void winGridViewPager1_OnDeleteSelected(object sender, EventArgs e)
        {
			DeleteData();
        }
        
        /// <summary>
        /// 分页控件编辑项操作
        /// </summary>
        private void winGridViewPager1_OnEditSelected(object sender, EventArgs e)
        {
						EditData();
			        }        
        
        void dlg_OnDataSaved(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// 分页控件新增操作
        /// </summary>        
        private void winGridViewPager1_OnAddNew(object sender, EventArgs e)
        {
            AddData();
        }
        
        /// <summary>
        /// 分页控件全部导出操作前的操作
        /// </summary> 
        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            string where = GetConditionSql();
            this.winGridViewPager1.AllToExport = BLLFactory<设备表>.Instance.FindToDataTable(where);
         }

        /// <summary>
        /// 分页控件翻页的操作
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }
 
        #endregion

        #region 从表明细列表

        void winGridView2_OnRefresh(object sender, EventArgs e)
        {
            //获取消费表头ID
            string headerID = this.winGridViewPager1.gridView1.GetFocusedRowCellDisplayText("设备id");
            BindDetail(headerID);
        }

        /// <summary>
        /// 绑定主表明细列表数据
        /// </summary>
        private void BindDetail(string headerID)
        {
        	//entity
            this.winGridView2.DisplayColumns = "工序id,工序名称,设备id,设备名称";
            this.winGridView2.ColumnNameAlias = BLLFactory<设备工序表>.Instance.GetColumnNameAlias();//字段列显示名称转义

            #region 添加别名解析

            //this.winGridView2.AddColumnAlias("工序id", "工序ID");
            //this.winGridView2.AddColumnAlias("工序名称", "工序名称");
            //this.winGridView2.AddColumnAlias("设备id", "设备ID");
            //this.winGridView2.AddColumnAlias("设备名称", "设备名称");

            #endregion

            string where = string.Format("设备ID ='{0}'", headerID);
	            List<设备工序表Info> list = BLLFactory<设备工序表>.Instance.Find(where);
            this.winGridView2.DataSource = list;//new WHC.Pager.WinControl.SortableBindingList<工序表Info>(list);
                this.winGridView2.PrintTitle = "工序表报表";
 

             CreateSummary();// 明细增加汇总信息
        }

        /// <summary>
        /// 明细增加汇总信息
        /// </summary>
        private void CreateSummary()
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView1 = this.winGridView2.gridView1;
            if (gridView1 != null && gridView1.Columns.Count > 0)
            {
                gridView1.GroupSummary.Clear();

                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
                gridView1.OptionsView.ShowFooter = true;
                gridView1.OptionsView.ShowGroupedColumns = true;
                gridView1.OptionsView.ShowGroupPanel = false;

                DevExpress.XtraGrid.Columns.GridColumn 工序idColumn = gridView1.Columns["工序id"];
                工序idColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "工序id", "工序ID：{0}")});
                DevExpress.XtraGrid.Columns.GridColumn 工序名称Column = gridView1.Columns["工序名称"];
                工序名称Column.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "工序名称", "工序名称：{0}")});
                DevExpress.XtraGrid.Columns.GridColumn 设备idColumn = gridView1.Columns["设备id"];
                设备idColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "设备id", "设备ID：{0}")});
                DevExpress.XtraGrid.Columns.GridColumn 设备名称Column = gridView1.Columns["设备名称"];
                设备名称Column.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                    new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "设备名称", "设备名称：{0}")});

            }
        }

        /// <summary>
        /// 绑定数据后，分配各列的宽度
        /// </summary>
        private void gridView2_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.winGridView2.gridView1.Columns.Count > 0 && this.winGridView2.gridView1.RowCount > 0)
            {
                //统一设置100宽度
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.winGridView2.gridView1.Columns)
                {
                    column.Width = 80;
                }
				GridView gridView1 = this.winGridView2.gridView1;
                if (gridView1 != null)
                {
                //gridView1.SetGridColumWidth("工序id", 120);
                //gridView1.SetGridColumWidth("工序名称", 120);
                //gridView1.SetGridColumWidth("设备id", 120);
                //gridView1.SetGridColumWidth("设备名称", 120);
                gridView1.SetGridColumWidth("工序id", 150);
                gridView1.SetGridColumWidth("工序名称", 150);
                gridView1.SetGridColumWidth("设备id", 150);
                gridView1.SetGridColumWidth("设备名称", 150);
                }
            }
        }

        /// <summary>
        /// 表格显示内容转义
        /// </summary>
        void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            string fieldName = e.Column.FieldName;
            if (fieldName == "SalePrice" || fieldName == "Price" || fieldName == "Amount")
            {
                if (e.Value != null)
                {
                    e.DisplayText = e.Value.ToString().ToDecimal().ToString("C2");
                }
            }
        }
        
        #endregion

       
        
        /// <summary>
        /// 高级查询条件语句对象
        /// </summary>
        private SearchCondition advanceCondition;
        
        /// <summary>
        /// 根据查询条件构造查询语句
        /// </summary> 
        private string GetConditionSql()
        {
            //如果存在高级查询对象信息，则使用高级查询条件，否则使用主表条件查询
            SearchCondition condition = advanceCondition;
            if (condition == null)
            {
                condition = new SearchCondition();
                condition.AddCondition("设备名称", this.txt设备名称.Text.Trim(), SqlOperator.Like);
                condition.AddNumericCondition("位置序号", this.txt位置序号1, this.txt位置序号2); //数值类型
                condition.AddCondition("启用状态", this.txt启用状态.Text.Trim(), SqlOperator.Like);
                condition.AddCondition("生产状态", this.txt生产状态.Text.Trim(), SqlOperator.Like);
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }
        
        /// <summary>
        /// 绑定列表数据
        /// </summary>
        private void BindData()
        {
        	//entity
            this.winGridViewPager1.DisplayColumns = "设备id,设备名称,位置序号,启用状态,生产状态";
            this.winGridViewPager1.ColumnNameAlias = BLLFactory<设备表>.Instance.GetColumnNameAlias();//字段列显示名称转义

            #region 添加别名解析

            //this.winGridViewPager1.AddColumnAlias("设备id", "设备ID");
            //this.winGridViewPager1.AddColumnAlias("设备名称", "设备名称");
            //this.winGridViewPager1.AddColumnAlias("位置序号", "位置序号");
            //this.winGridViewPager1.AddColumnAlias("启用状态", "启用状态");
            //this.winGridViewPager1.AddColumnAlias("生产状态", "生产状态");

            #endregion

            string where = GetConditionSql();
	            List<设备表Info> list = BLLFactory<设备表>.Instance.FindWithPager(where, this.winGridViewPager1.PagerInfo);
            this.winGridViewPager1.DataSource = list;//new WHC.Pager.WinControl.SortableBindingList<设备表Info>(list);
                this.winGridViewPager1.PrintTitle = "设备表报表";
         }
        
        /// <summary>
        /// 查询数据操作
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
        	advanceCondition = null;//必须重置查询条件，否则可能会使用高级查询条件了
            BindData();
        }
        
        /// <summary>
        /// 提供给控件回车执行查询的操作
        /// </summary>
        private void SearchControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }    
		     
        /// <summary>
        /// 新增数据操作
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddData();
        }  

 		 		 		 		 
        private string moduleName = "设备表";
        /// <summary>
        /// 导入Excel的操作
        /// </summary>          
        private void btnImport_Click(object sender, EventArgs e)
        {
            string templateFile = string.Format("{0}-模板.xls", moduleName);
            FrmImportExcelData dlg = new FrmImportExcelData();
            dlg.SetTemplate(templateFile, System.IO.Path.Combine(Application.StartupPath, templateFile));
            dlg.OnDataSave += new FrmImportExcelData.SaveDataHandler(ExcelData_OnDataSave);
            dlg.OnRefreshData += new EventHandler(ExcelData_OnRefreshData);
            dlg.ShowDialog();
        }

        void ExcelData_OnRefreshData(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 如果字段存在，则获取对应的值，否则返回默认空
        /// </summary>
        /// <param name="row">DataRow对象</param>
        /// <param name="columnName">字段列名</param>
        /// <returns></returns>
        private string GetRowData(DataRow row, string columnName)
        {
            string result = "";
            if (row.Table.Columns.Contains(columnName))
            {
                result = row[columnName].ToString();
            }
            return result;
        }
        
        bool ExcelData_OnDataSave(DataRow dr)
        {
            bool success = false;
            bool converted = false;
            DateTime dtDefault = Convert.ToDateTime("1900-01-01");
            DateTime dt;
            设备表Info info = new 设备表Info();
             info.设备名称 = GetRowData(dr, "设备名称");
              info.位置序号 = GetRowData(dr, "位置序号").ToInt32();
              info.启用状态 = GetRowData(dr, "启用状态").ToBoolean();
              info.生产状态 = GetRowData(dr, "生产状态");
  
            success = BLLFactory<设备表>.Instance.Insert(info);
             return success;
        }

        /// <summary>
        /// 导出Excel的操作
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string file = FileDialogHelper.SaveExcel(string.Format("{0}.xls", moduleName));
            if (!string.IsNullOrEmpty(file))
            {
                string where = GetConditionSql();
                List<设备表Info> list = BLLFactory<设备表>.Instance.Find(where);
                 DataTable dtNew = DataTableHelper.CreateTable("序号|int,设备名称,位置序号,启用状态,生产状态");
                DataRow dr;
                int j = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = dtNew.NewRow();
                    dr["序号"] = j++;
                     dr["设备名称"] = list[i].设备名称;
                     dr["位置序号"] = list[i].位置序号;
                     dr["启用状态"] = list[i].启用状态;
                     dr["生产状态"] = list[i].生产状态;
                     dtNew.Rows.Add(dr);
                }

                try
                {
                    string error = "";
                    AsposeExcelTools.DataTableToExcel2(dtNew, file, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageDxUtil.ShowError(string.Format("导出Excel出现错误：{0}", error));
                    }
                    else
                    {
                        if (MessageDxUtil.ShowYesNoAndTips("导出成功，是否打开文件？") == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(file);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
         }
         
        private FrmAdvanceSearch dlg;
        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            if (dlg == null)
            {
                dlg = new FrmAdvanceSearch();
                dlg.FieldTypeTable = BLLFactory<设备表>.Instance.GetFieldTypeList();
                dlg.ColumnNameAlias = BLLFactory<设备表>.Instance.GetColumnNameAlias();                
                 dlg.DisplayColumns = "设备名称,位置序号,启用状态,生产状态";

                #region 下拉列表数据

                //dlg.AddColumnListItem("UserType", Portal.gc.GetDictData("人员类型"));//字典列表
                //dlg.AddColumnListItem("Sex", "男,女");//固定列表
                //dlg.AddColumnListItem("Credit", BLLFactory<设备表>.Instance.GetFieldList("Credit"));//动态列表

                #endregion

                dlg.ConditionChanged += new FrmAdvanceSearch.ConditionChangedEventHandler(dlg_ConditionChanged);
            }
            dlg.ShowDialog();
        }

        void dlg_ConditionChanged(SearchCondition condition)
        {
            advanceCondition = condition;
            BindData();
        }
		
        private void chkTableDirection_CheckedChanged(object sender, EventArgs e)
        {
            this.splitContainer1.Horizontal = !this.chkTableDirection.Checked;
        }
    }
}
