using Jakkes.WebSockets.Server;
using MinesweeperServer.Models;
using Newtonsoft.Json;

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
            RequestModel m = JsonConvert.DeserializeObject<RequestModel>(data);
            switch(m.Action){
                case "NewGame":
                    StartNewGame(JsonConvert.DeserializeObject<NewGameRequestModel>(data));
                    break;
            }
        }
        private  void StartNewGame(NewGameRequestModel model){

        }
    }
}
