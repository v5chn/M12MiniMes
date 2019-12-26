namespace M12MiniMes.UI
{
    partial class FrmEdit设备表
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEdit设备表));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();                

            this.txt设备名称 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
             this.txtIp = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
             this.txt位置序号 = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
             this.txt启用状态 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
             this.txt生产状态 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
             
            ((System.ComponentModel.ISupportInitialize)(this.picPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();

            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();            
            ((System.ComponentModel.ISupportInitialize)(this.txt设备名称.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.txtIp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.txt位置序号.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.txt启用状态.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.txt生产状态.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
             
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(330, 387);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(430, 387);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(530, 387);
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(12, 391);
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
            this.layoutControl1.Location = new System.Drawing.Point(12, 8);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(605, 363);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";

            this.layoutControl1.Controls.Add(this.txt设备名称);
             this.layoutControl1.Controls.Add(this.txtIp);
             this.layoutControl1.Controls.Add(this.txt位置序号);
             this.layoutControl1.Controls.Add(this.txt启用状态);
             this.layoutControl1.Controls.Add(this.txt生产状态);
 
            // 
            // txt设备名称
            // 
            this.txt设备名称.Location = new System.Drawing.Point(112, 12);
            this.txt设备名称.Name = "txt设备名称";
            this.txt设备名称.Size = new System.Drawing.Size(481, 20);
            this.txt设备名称.StyleController = this.layoutControl1;
            this.txt设备名称.TabIndex = 1;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt设备名称;
            this.layoutControlItem1.CustomizationFormText = "设备名称";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem1.Text = "设备名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(96, 14);  

             // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(112, 36);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(481, 20);
            this.txtIp.StyleController = this.layoutControl1;
            this.txtIp.TabIndex = 2;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtIp;
            this.layoutControlItem2.CustomizationFormText = "IP";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem2.Text = "IP";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(96, 14);  

             this.txt位置序号.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt位置序号.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txt位置序号.Location = new System.Drawing.Point(112, 60);
            this.txt位置序号.Name = "txt位置序号";
            this.txt位置序号.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txt位置序号.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txt位置序号.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txt位置序号.Size = new System.Drawing.Size(120, 20);
            this.txt位置序号.StyleController = this.layoutControl1;
            this.txt位置序号.TabIndex = 3;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt位置序号;
            this.layoutControlItem3.CustomizationFormText = "位置序号";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem3.Text = "位置序号";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(96, 14);  

             // 
            // txt启用状态
            // 
            this.txt启用状态.Location = new System.Drawing.Point(112, 84);
            this.txt启用状态.Name = "txt启用状态";
            this.txt启用状态.Size = new System.Drawing.Size(481, 20);
            this.txt启用状态.StyleController = this.layoutControl1;
            this.txt启用状态.TabIndex = 4;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt启用状态;
            this.layoutControlItem4.CustomizationFormText = "启用状态";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem4.Text = "启用状态";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(96, 14);  

             // 
            // txt生产状态
            // 
            this.txt生产状态.Location = new System.Drawing.Point(112, 108);
            this.txt生产状态.Name = "txt生产状态";
            this.txt生产状态.Size = new System.Drawing.Size(481, 20);
            this.txt生产状态.StyleController = this.layoutControl1;
            this.txt生产状态.TabIndex = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txt生产状态;
            this.layoutControlItem5.CustomizationFormText = "生产状态";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(585, 24);
            this.layoutControlItem5.Text = "生产状态";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(96, 14);  

 
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
	        this.layoutControlItem1
	 	       ,this.layoutControlItem2
	 	       ,this.layoutControlItem3
	 	       ,this.layoutControlItem4
	 	       ,this.layoutControlItem5
	        });
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(605, 363);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;          

            // 
            // FrmEdit设备表
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 427);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FrmEdit设备表";
            this.Text = "设备表";
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

            ((System.ComponentModel.ISupportInitialize)(this.txt设备名称.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();            
             ((System.ComponentModel.ISupportInitialize)(this.txtIp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();            
             ((System.ComponentModel.ISupportInitialize)(this.txt位置序号.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();            
             ((System.ComponentModel.ISupportInitialize)(this.txt启用状态.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();            
             ((System.ComponentModel.ISupportInitialize)(this.txt生产状态.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();            
 
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;

        private DevExpress.XtraEditors.TextEdit txt设备名称;
          private DevExpress.XtraEditors.TextEdit txtIp;
          private DevExpress.XtraEditors.SpinEdit txt位置序号;
          private DevExpress.XtraEditors.TextEdit txt启用状态;
          private DevExpress.XtraEditors.TextEdit txt生产状态;
  
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
         private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
 
    }
}