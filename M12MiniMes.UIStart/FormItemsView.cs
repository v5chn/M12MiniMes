using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using Faster.Core;
using System.IO;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;


namespace M12MiniMes.UIStart
{
    public partial class FormItemsView : DevExpress.XtraEditors.XtraForm
    {
        public FormItemsView()
        {
            InitializeComponent();

            //每个gridview显示行序号
            this.gridView1.CustomDrawRowIndicator += showRowIndex;
            this.gridView2.CustomDrawRowIndicator += showRowIndex;
            this.gridView3.CustomDrawRowIndicator += showRowIndex;
        }

        private void showRowIndex(object sender, RowIndicatorCustomDrawEventArgs e) 
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void FormClassDynamicCreater_Load(object sender, EventArgs e)
        {
            FixtureItem fixtureItem = new FixtureItem();
            fixtureItem.InsertMaterialItem(0, new MaterialItem());
            MachineItem machineItem = new MachineItem() { CurrentFixtureItems = new BindingList<FixtureItem>() { fixtureItem } };
            ItemManager.Instance.AllCurrentMachineItems.Add(machineItem);

            this.gridControl1.DataSource = ItemManager.Instance.AllCurrentMachineItems;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //如果e.Valid等于false就会触发InvalidRowException事件
            
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ErrorText = $@"不允许存在重复名称！只能为字母开头！请检查 (按ESC键可取消编辑并退出)";
        }

        private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            int i = this.gridView1.FocusedRowHandle;
            if (i >= 0)
            {
                //如果e.Valid等于false就会触发InvalidRowException事件
                
            }
        }

        private void gridView2_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ErrorText = $@"不允许存在重复名称！只能为字母开头！请检查 (按ESC键可取消编辑并退出)";
        }

        private void test(object sender, EventArgs e)  //展开子级从表视图
        {
            //展开
            //this.gridView1.ExpandGroupLevel(1);

            int rowHandle = this.gridView1.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                if (this.gridView1.GetMasterRowExpanded(rowHandle))
                {
                    this.gridView1.CollapseMasterRow(rowHandle);
                }
                else
                {
                    this.gridView1.ExpandMasterRow(rowHandle);
                }
            }
        }
    }
}