using CommunicateCenter;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace M12MiniMes.UIStart
{
    public partial class FormServer : DevExpress.XtraEditors.XtraForm
    {
        private TableLayoutPanel layoutPanel = new TableLayoutPanel();
        private List<SimpleButton> Buttons = new List<SimpleButton>();  //用button来指示客户端在线情况

        public frmTcpServer frmTcpServer;

        public FormServer(frmTcpServer serverForm)
        {
            InitializeComponent();

            this.frmTcpServer = serverForm;
            this.frmTcpServer.FormBorderStyle = FormBorderStyle.None;
            this.frmTcpServer.Dock = DockStyle.Fill;
            this.frmTcpServer.TopLevel = false;
            this.frmTcpServer.Parent = this.splitContainer1.Panel2;
            this.frmTcpServer.Show();
        }

        private void FormServer_Load(object sender, EventArgs e)
        {
            bt刷新_Click(null, null);

            foreach (var item in TcpServer.Server.AliveClients)
            {
                SimpleButton button = FindButtonByIP(item.RemoteEndPoint);
                if (button != null)
                {
                    //表示在线
                    button.BackColor = Color.DeepSkyBlue;
                }
            }

            //注册客户端连上与断开事件
            TcpServer.Server.NewClientAccepted += Server_NewClientAccepted;
            TcpServer.Server.ClientDropped += Server_ClientDropped;
            TcpServer.Server.Stopped += Server_Stopped;
        }

        private SimpleButton FindButtonByIP(EndPoint endPoint)
        {
            IPAddress ip = ((IPEndPoint)endPoint).Address;
            //找到对应button指示
            SimpleButton button = this.Buttons.FirstOrDefault(p => p.Text.Contains(ip.ToString()));
            //MachineItem machineItem = button?.Tag as MachineItem;
            return button;
        }

        private void Server_NewClientAccepted(FastInterface.ITcpServer listener, System.Net.Sockets.Socket client, object state)
        {
            SimpleButton button = FindButtonByIP(client.RemoteEndPoint);
            if (button != null)
            {
                //表示在线
                this.Invoke(new Action(() =>
                {
                    button.Appearance.BackColor = Color.DeepSkyBlue;
                }));
            }
        }

        private void Server_ClientDropped(FastInterface.ITcpServer listener, System.Net.Sockets.Socket client)
        {
            SimpleButton button = FindButtonByIP(client.RemoteEndPoint);
            if (button != null)
            {
                //表示离线
                this.Invoke(new Action(() =>
                {
                    button.Appearance.BackColor = Color.Silver;
                }));
            }
        }

        private void Server_Stopped(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                this.Buttons.ForEach(p =>
                {
                    p.Appearance.BackColor = Color.Silver;
                });
            }));
        }

        private void bt刷新_Click(object sender, EventArgs e)
        {
            this.Buttons.Clear();
            this.splitContainer2.Panel2.Controls.Clear();
            this.layoutPanel.Controls.Clear();
            this.layoutPanel = new TableLayoutPanel();

            layoutPanel.Dock = DockStyle.Fill;
            layoutPanel.Parent = this.splitContainer2.Panel2;
            layoutPanel.ColumnCount = 1;
            int machineItems = ItemManager.Instance.MachineItems.Count;
            layoutPanel.RowCount = machineItems;
            for (int i = 0; i < machineItems; i++)
            {
                SimpleButton button = new SimpleButton();
                MachineItem machineItem = ItemManager.Instance.MachineItems[i];
                button.Tag = machineItem;
                button.Text = $"[ID:{machineItem.设备id}]-[Name:{machineItem.设备名称}]\r\n[IP:{machineItem.Ip}]";
                button.Dock = DockStyle.Fill;
                button.Enabled = false;
                button.Font = new Font("微软雅黑", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                layoutPanel.RowStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                layoutPanel.Controls.Add(button, 0, i);
                this.Buttons.Add(button);
            }
            this.Update();
        }
    }
}