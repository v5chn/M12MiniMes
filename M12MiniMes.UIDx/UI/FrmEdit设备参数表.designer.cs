namespace M12MiniMes.UI
{
    partial class FrmEdit设备参数表
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEdit设备参数表));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt设备名称 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt位置序号 = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt启用状态 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt生产状态 = new DevExpress.XtraEditors.TextEdit();
            this.layoutItemGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt设备名称.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt位置序号.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt启用状态.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt生产状态.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.ImageOptions.Image")));
            this.btnOK.Location = new System.Drawing.Point(430, 387);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Location = new System.Drawing.Point(530, 387);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.Location = new System.Drawing.Point(330, 387);
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 391);
            this.dataNavigator1.Size = new System.Drawing.Size(191, 30);
            // 
            // picPrint
            // 
            this.picPrint.Location = new System.Drawing.Point(202, 391);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Controls.Add(this.txt设备名称);
            this.layoutControl1.Controls.Add(this.txt位置序号);
            this.layoutControl1.Controls.Add(this.txt启用状态);
            this.layoutControl1.Controls.Add(this.txt生产状态);
            this.layoutControl1.Location = new System.Drawing.Point(12, 8);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(605, 363);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutItemGrid});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(605, 363);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt设备名称;
            this.layoutControlItem1.CustomizationFormText = "设备名称";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(585, 28);
            this.layoutControlItem1.Text = "设备名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 18);
            // 
            // txt设备名称
            // 
            this.txt设备名称.Location = new System.Drawing.Point(75, 12);
            this.txt设备名称.Name = "txt设备名称";
            this.txt设备名称.Size = new System.Drawing.Size(518, 24);
            this.txt设备名称.StyleController = this.layoutControl1;
            this.txt设备名称.TabIndex = 1;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt位置序号;
            this.layoutControlItem2.CustomizationFormText = "位置序号";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(585, 28);
            this.layoutControlItem2.Text = "位置序号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 18);
            // 
            // txt位置序号
            // 
            this.txt位置序号.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt位置序号.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txt位置序号.Location = new System.Drawing.Point(75, 40);
            this.txt位置序号.Name = "txt位置序号";
            this.txt位置序号.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txt位置序号.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txt位置序号.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txt位置序号.Size = new System.Drawing.Size(518, 24);
            this.txt位置序号.StyleController = this.layoutControl1;
            this.txt位置序号.TabIndex = 2;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt启用状态;
            this.layoutControlItem3.CustomizationFormText = "启用状态";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(585, 28);
            this.layoutControlItem3.Text = "启用状态";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 18);
            // 
            // txt启用状态
            // 
            this.txt启用状态.Location = new System.Drawing.Point(75, 68);
            this.txt启用状态.Name = "txt启用状态";
            this.txt启用状态.Size = new System.Drawing.Size(518, 24);
            this.txt启用状态.StyleController = this.layoutControl1;
            this.txt启用状态.TabIndex = 3;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt生产状态;
            this.layoutControlItem4.CustomizationFormText = "生产状态";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 84);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(585, 28);
            this.layoutControlItem4.Text = "生产状态";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 18);
            // 
            // txt生产状态
            // 
            this.txt生产状态.Location = new System.Drawing.Point(75, 96);
            this.txt生产状态.Name = "txt生产状态";
            this.txt生产状态.Size = new System.Drawing.Size(518, 24);
            this.txt生产状态.StyleController = this.layoutControl1;
            this.txt生产状态.TabIndex = 4;
            // 
            // layoutItemGrid
            // 
            this.layoutItemGrid.Control = this.groupControl1;
            this.layoutItemGrid.Location = new System.Drawing.Point(0, 112);
            this.layoutItemGrid.Name = "layoutItemGrid";
            this.layoutItemGrid.Size = new System.Drawing.Size(585, 231);
            this.layoutItemGrid.TextSize = new System.Drawing.Size(0, 0);
            this.layoutItemGrid.TextVisible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 124);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(581, 227);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "明细清单";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 27);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(577, 198);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ViewCaption = "报销明细";
            this.gridView1.ViewCaptionHeight = 100;
            // 
            // FrmEdit设备表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 427);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmEdit设备表";
            this.Text = "设备参数表";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.dataNavigator1, 0);
            this.Controls.SetChildIndex(this.picPrint, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt设备名称.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt位置序号.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt启用状态.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt生产状态.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemGrid;

        private DevExpress.XtraEditors.TextEdit txt设备名称;
          private DevExpress.XtraEditors.SpinEdit txt位置序号;
          private DevExpress.XtraEditors.TextEdit txt启用状态;
          private DevExpress.XtraEditors.TextEdit txt生产状态;
  
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
 
    }
}