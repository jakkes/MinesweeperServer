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

            try{
            srv.Start();
            Console.WriteLine("Started server on port " + PORT);
	        Console.ReadLine();
            }
            catch (Exception){
                Console.WriteLine("Failed to start server.");
            }
        }

        private static void Srv_ClientConnected(WebSocketServer source, Connection conn)
        {
            new Client(conn);
        }
    }
}
