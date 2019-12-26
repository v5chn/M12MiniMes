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
        FormServer frmServer;

        public override Control Control => frmServer;

        public override string InsertPath => $@"Mes服务器";

        public override Func<IBar, bool> FuncInitialize => p =>
        {
            bool b1 = TcpServer.Load();

            frmServer = new FormServer(new frmTcpServer(TcpServer.Server));

            return b1;
        };

        public override Func<IView, bool> FuncSave => p =>
        {
            return TcpServer.Save();
        };
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
            return b;
        };

        public override string InsertPath => $@"生产内存数据";
    }

    public class View设备工序表 : LazyAbstractView<Frm设备表>
    {
        public override string InsertPath => $@"设备表";
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
