using CommunicateCenter;
using Faster.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M12MiniMes.UIStart
{
    public static class TcpServer
    {
        public static AsyncTcpServer Server;

        public static bool Save() 
        {
            CommonSerializer.SaveObjAsBinaryFile(Server, $@".\Server.xml", out bool bSaveOK, out Exception ex);
            return bSaveOK;
        }

        public static bool Load() 
        {
            Server = CommonSerializer.LoadObjFormBinaryFile<AsyncTcpServer>($@".\Server.xml", out bool bLoadOK, out Exception ex);
            bool b = Server.Init("");
            return bLoadOK;
        }
    }
}
