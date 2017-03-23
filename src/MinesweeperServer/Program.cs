using Jakkes.WebSockets.Server;
using System;

namespace MinesweeperServer
{
    public class Program
    {

        static int PORT = 8081;

        public static void Main(string[] args)
        {
            WebSocketServer srv = new WebSocketServer(PORT);
            srv.ClientConnected += Srv_ClientConnected;

            srv.Start();
            Console.WriteLine("Started server on port " + PORT);
	    Console.ReadLine();
        }

        private static void Srv_ClientConnected(WebSocketServer source, Connection conn)
        {
            throw new NotImplementedException();
        }
    }
}
