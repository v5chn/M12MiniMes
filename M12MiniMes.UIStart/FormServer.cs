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
            this.frmTcpServer.Parent = this;
            this.frmTcpServer.Show();
        }
    }
}