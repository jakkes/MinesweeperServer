using Jakkes.WebSockets.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperServer
{
    public class Client
    {
        private Connection _conn;
        public Client(Connection conn)
        {
            conn = _conn;
            conn.MessageReceived += Conn_MessageReceived;
        }

        private void Conn_MessageReceived(Connection source, string data)
        {
            
        }
    }
}
