using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using Faster.Core;
using M12MiniMes.UI;
using CommunicateCenter;

namespace M12MiniMes.UIStart
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            Application.Run(new FormItemsView());
        }
    }


    public class ServerView : AbstractView
    {
        AsyncTcpServer Server;
        FormServer frmServer;

        public override Control Control => frmServer;

        public override string InsertPath => $@"Mes服务器";

        public override Func<IBar, bool> FuncInitialize => p =>
        {
            bool b1 = Load();
            bool b2 = this.Server.Init("");

            frmServer = new FormServer(new frmTcpServer(this.Server), this.Server);

            return b1;
        };

        public override Func<IView, bool> FuncSave => p =>
        {
            return Save();
        };

        public bool Save()
        {
            CommonSerializer.SaveObjAsBinaryFile(this, $@".\Server.xml", out bool bSaveOK, out Exception ex);
            return bSaveOK;
        }

        public bool Load()
        {
            this.Server = CommonSerializer.LoadObjFormBinaryFile<AsyncTcpServer>($@".\Server.xml", out bool bLoadOK, out Exception ex);
            return bLoadOK;
        }
    }

    public class ItemsView : LazyAbstractView<FormItemsView>
    {
        public override Func<IBar, bool> FuncInitialize => p =>
        {
            bool b = ItemManager.Instance.Load();
            return b;
        };

        public override Func<IView, bool> FuncSave => p =>
        {
            bool b = ItemManager.Instance.Save();
            MessageBox.Show("ItemManager保存结果" + b.ToString());
            return b;
        };

        public override string InsertPath => $@"生产内存数据";
    }

    public class View设备工序表 : LazyAbstractView<FrmMaster设备工序表>
    {
        public override string InsertPath => $@"设备工序表";
    }
    public class View生产批次生成表 : LazyAbstractView<Frm生产批次生成表>
    {
        public override string InsertPath => $@"生产批次生成表";
    }
    public class View生产数据表 : LazyAbstractView<Frm生产数据表>
    {
        public override string InsertPath => $@"生产数据表";
    }
    public class View物料NG替换记录表 : LazyAbstractView<Frm物料ng替换记录表>
    {
        public override string InsertPath => $@"物料NG替换记录表";
    }
}
