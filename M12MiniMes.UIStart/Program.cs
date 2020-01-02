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
using System.Drawing;
using FastInterface;
using System.Net.Sockets;
using System.Net;

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


    public class ServerView : LazyAbstractView2<frmTcpServer>
    {
        public override Func<frmTcpServer> valueFactory => ()=> new frmTcpServer(TcpServer.Server);

        public override string InsertPath => $@"Mes服务器";

        public override Func<IBar, bool> FuncInitialize => p =>
        {
            bool b1 = ItemManager.Instance.Load();
            foreach (var item in ItemManager.Instance.MachineItems)
            {
                //在底部状态栏显示各设备客户端连接状态
                bool ba = IBarManager.Instance.CreateBar(item.设备名称,null,null,pp=> 
                {
                    //pp.BarStatus = new BarStatus() { BackColor = Color.Tomato };
                    pp.BarStatus = new BarStatus() { IsEnable = false };
                    return true; 
                },BarType.Check); 
            }

            bool b2 = TcpServer.Load();

            //注册客户端连上与断开事件
            TcpServer.Server.NewClientAccepted += Server_NewClientAccepted;
            TcpServer.Server.ClientDropped += Server_ClientDropped;
            TcpServer.Server.Stopped += Server_Stopped;

            bool b3 = TcpServer.Server.Init("");
            TcpServer.StartMasterLogic();

            return b1;
        };
        private MachineItem FindMachineItemByMachineIP(string machineIP) 
        {
            return ItemManager.Instance.MachineItems.FirstOrDefault(p => p.Ip.Equals(machineIP));
        }
        private IBar FindBottomStatusIbarByMachineName(string machineName)
        {
            return IBarManager.Instance.createdBars.FirstOrDefault(p => p.InsertPath.Equals(machineName));
        }
        private void Server_NewClientAccepted(ITcpServer listener,Socket client, object state)
        {
            IPAddress ip = ((IPEndPoint)client.RemoteEndPoint).Address;
            MachineItem mItem = FindMachineItemByMachineIP(ip.ToString());
            if (mItem != null)
            {
                IBar bar = FindBottomStatusIbarByMachineName(mItem.设备名称);
                if (bar != null)
                {
                    bar.BarStatus = new BarStatus() { BackColor = Color.DeepSkyBlue };
                }
            }
        }
        private void Server_Stopped(object sender, EventArgs e)
        {
            foreach (var item in ItemManager.Instance.MachineItems)
            {
                IBar bar = FindBottomStatusIbarByMachineName(item.设备名称);
                if (bar != null)
                {
                    bar.BarStatus = new BarStatus() { BackColor = Color.Tomato };
                }
            }
        }

        private void Server_ClientDropped(ITcpServer listener, Socket client)
        {
            IPAddress ip = ((IPEndPoint)client.RemoteEndPoint).Address;
            MachineItem mItem = FindMachineItemByMachineIP(ip.ToString());
            if (mItem != null)
            {
                IBar bar = FindBottomStatusIbarByMachineName(mItem.设备名称);
                if (bar != null)
                {
                    bar.BarStatus = new BarStatus() { BackColor = Color.Tomato };
                }
            }
        }

        public override Func<IView, bool> FuncSave => p =>
        {
            return TcpServer.Save();
        };
    }

    public class ItemsView : LazyAbstractView<FormItemsView>
    {
        public override Func<IView, bool> FuncSave => p =>
        {
            bool b = ItemManager.Instance.Save();
            return b;
        };

        public override string InsertPath => $@"生产内存数据";

        public override Action<IView> ActShowView => p =>
        {
            this.LazyControl.Value.ExpandAllRow();
        };
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
