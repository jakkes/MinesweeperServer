using System;
using Jakkes.WebSockets.Server;
using MinesweeperServer.Models;
using Newtonsoft.Json;

namespace MinesweeperServer
{
    public class Client
    {
        private Connection _conn;
        private Game _game;
        public Client(Connection conn)
        {
            _conn = conn;
            _conn.MessageReceived += Conn_MessageReceived;
        }

        private void Conn_MessageReceived(Connection source, string data)
        {
            RequestModel m = JsonConvert.DeserializeObject<RequestModel>(data);
            switch(m.Action){
                case "NewGame":
                    StartNewGame(JsonConvert.DeserializeObject<NewGameRequestModel>(data));
                    break;
                case "Reveal":
                    Reveal(JsonConvert.DeserializeObject<RevealRequest>(data));
                    break;
            }
        }
        private  void StartNewGame(NewGameRequestModel model){
            if(model.Mode == "Custom")
                _game = new Game(model.Config);
            else {
                switch (model.Mode){
                    case "Easy":
                        _game = new Game(Settings.Easy());
                        break;
                    case "Medium":
                        _game = new Game(Settings.Medium());
                        break;
                    case "Hard":
                        _game = new Game(Settings.Hard());
                        break;
                    case "Extreme":
                        _game = new Game(Settings.Extreme());
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            _game.ClearNodesRevealed += ClearNodesRevealed;
            _game.GameOver += GameOver;
            _game.NodeRevealed += NodeRevealed;
        }

        private void Reveal(RevealRequest model){
            _game?.Reveal(model.Node.X,model.Node.Y);
        }
        private void NodeRevealed(Game source, Node node){
            try{
                _conn.Send(JsonConvert.SerializeObject(new NodeRevealed(node)));
            } catch (ConnectionBusyException){throw new NotImplementedException();}
        }
        private void GameOver(Game source, Node[][] board){
            try{
                _conn.Send(JsonConvert.SerializeObject(new GameOverModel(board)));
            } catch (ConnectionBusyException){throw new NotImplementedException(); }
        }
        private void ClearNodesRevealed(Game source, Position[] e){
            try {
            _conn.Send(JsonConvert.SerializeObject(new ClearNodesRevealedModel(e)));
            } catch (ConnectionBusyException){throw new NotImplementedException(); }
        }
    }
}