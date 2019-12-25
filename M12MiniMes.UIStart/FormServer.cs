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
using Faster.Core;
using CommunicateCenter;

namespace M12MiniMes.UIStart
{
    public partial class FormServer : DevExpress.XtraEditors.XtraForm
    {
        public AsyncTcpServer Server;
        public frmTcpServer frmTcpServer;

        public FormServer(frmTcpServer serverForm , AsyncTcpServer Server)
        {
            InitializeComponent();

            this.Server = Server;
            this.frmTcpServer = serverForm;
            this.frmTcpServer.FormBorderStyle = FormBorderStyle.None;
            this.frmTcpServer.Dock = DockStyle.Fill;
            this.frmTcpServer.TopLevel = false;
            this.frmTcpServer.Parent = this.splitContainer1.Panel2;
        }

        private void FormServer_Load(object sender, EventArgs e)
        {

        }
    }
}