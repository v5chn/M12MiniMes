namespace M12MiniMes.UIStart
{
    partial class FormItemsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormItemsView));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_设备ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_设备名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_位置序号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_启用状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_生产状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn_IP地址 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.FixedLineWidth = 3;
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.IndicatorWidth = 60;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView2_InvalidRowException);
            this.gridView2.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView2_ValidateRow);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.First.Enabled = false;
            this.gridControl1.EmbeddedNavigator.Buttons.First.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.NextPage.Enabled = false;
            this.gridControl1.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.PrevPage.Enabled = false;
            this.gridControl1.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode2.LevelTemplate = this.gridView3;
            gridLevelNode2.RelationName = "MaterialItems";
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            gridLevelNode1.RelationName = "CurrentFixtureItems";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1258, 804);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView3,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_设备ID,
            this.gridColumn_设备名称,
            this.gridColumn_位置序号,
            this.gridColumn_启用状态,
            this.gridColumn_生产状态,
            this.gridColumn_IP地址});
            this.gridView1.FixedLineWidth = 3;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 60;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Classic;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // gridColumn_设备ID
            // 
            this.gridColumn_设备ID.Caption = "设备ID";
            this.gridColumn_设备ID.FieldName = "设备id";
            this.gridColumn_设备ID.MinWidth = 25;
            this.gridColumn_设备ID.Name = "gridColumn_设备ID";
            this.gridColumn_设备ID.OptionsColumn.ReadOnly = true;
            this.gridColumn_设备ID.Visible = true;
            this.gridColumn_设备ID.VisibleIndex = 0;
            this.gridColumn_设备ID.Width = 94;
            // 
            // gridColumn_设备名称
            // 
            this.gridColumn_设备名称.Caption = "设备名称";
            this.gridColumn_设备名称.FieldName = "设备名称";
            this.gridColumn_设备名称.MinWidth = 25;
            this.gridColumn_设备名称.Name = "gridColumn_设备名称";
            this.gridColumn_设备名称.OptionsColumn.ReadOnly = true;
            this.gridColumn_设备名称.Visible = true;
            this.gridColumn_设备名称.VisibleIndex = 1;
            this.gridColumn_设备名称.Width = 94;
            // 
            // gridColumn_位置序号
            // 
            this.gridColumn_位置序号.Caption = "位置序号";
            this.gridColumn_位置序号.FieldName = "位置序号";
            this.gridColumn_位置序号.MinWidth = 25;
            this.gridColumn_位置序号.Name = "gridColumn_位置序号";
            this.gridColumn_位置序号.OptionsColumn.ReadOnly = true;
            this.gridColumn_位置序号.Visible = true;
            this.gridColumn_位置序号.VisibleIndex = 2;
            this.gridColumn_位置序号.Width = 94;
            // 
            // gridColumn_启用状态
            // 
            this.gridColumn_启用状态.Caption = "启用状态";
            this.gridColumn_启用状态.FieldName = "启用状态";
            this.gridColumn_启用状态.MinWidth = 25;
            this.gridColumn_启用状态.Name = "gridColumn_启用状态";
            this.gridColumn_启用状态.OptionsColumn.ReadOnly = true;
            this.gridColumn_启用状态.Visible = true;
            this.gridColumn_启用状态.VisibleIndex = 3;
            this.gridColumn_启用状态.Width = 94;
            // 
            // gridColumn_生产状态
            // 
            this.gridColumn_生产状态.Caption = "生产状态";
            this.gridColumn_生产状态.FieldName = "生产状态";
            this.gridColumn_生产状态.MinWidth = 25;
            this.gridColumn_生产状态.Name = "gridColumn_生产状态";
            this.gridColumn_生产状态.OptionsColumn.ReadOnly = true;
            this.gridColumn_生产状态.Visible = true;
            this.gridColumn_生产状态.VisibleIndex = 4;
            this.gridColumn_生产状态.Width = 94;
            // 
            // gridColumn_IP地址
            // 
            this.gridColumn_IP地址.Caption = "IP";
            this.gridColumn_IP地址.FieldName = "Ip";
            this.gridColumn_IP地址.MinWidth = 25;
            this.gridColumn_IP地址.Name = "gridColumn_IP地址";
            this.gridColumn_IP地址.OptionsColumn.ReadOnly = true;
            this.gridColumn_IP地址.Visible = true;
            this.gridColumn_IP地址.VisibleIndex = 5;
            this.gridColumn_IP地址.Width = 94;
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridControl1;
            this.gridView3.IndicatorWidth = 60;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            // 
            // FormItemsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1258, 804);
            this.Controls.Add(this.gridControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormItemsView";
            this.Text = "生产内存数据总览";
            this.Load += new System.EventHandler(this.FormClassDynamicCreater_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_设备ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_设备名称;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_位置序号;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_启用状态;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_生产状态;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_IP地址;
    }
}