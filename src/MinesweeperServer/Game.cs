using MinesweeperServer.Models;
using System;
using System.Collections.Generic;

namespace MinesweeperServer
{
    public class Game
    {

        public delegate void GameOverEventHandler(Game source, Node[][] Board);
        public delegate void ClearNodesRevealedEventHandler(Game source, Position[] nodes);
        public delegate void NodeRevealedEventHandler(Game source, Node node);
            

        public int Width { get { return _settings.Width; } }
        public int Height { get { return _settings.Height; } }

        public event GameOverEventHandler GameOver;
        public event ClearNodesRevealedEventHandler ClearNodesRevealed;
        public event NodeRevealedEventHandler NodeRevealed;

        private Settings _settings;
        private Node[][] _board;
        private HashSet<Node> _bombs;
        private Random _r = new Random();
        public Game(Settings settings)
        {
            if (settings.Bombs > settings.Width * settings.Height)
                throw new ArgumentException("Too many bombs.");
            _settings = settings;
            _populateBoard();
        }
        public void Reveal(int X, int Y)
        {
            if (X > Width || Y > Height || X < 0 || Y < 0)
                throw new ArgumentException();
            _board[X][Y].Status = Node.StatusType.Revealed;

            if (_board[X][Y].Type == Node.NodeType.Bomb)
                _gameOver(_board[X][Y]);
            else if(_board[X][Y].Type == Node.NodeType.Empty)
                _revealEmptyNodes(_board[X][Y]);
            else
                NodeRevealed?.Invoke(this, _board[X][Y]);
        }
        private void _revealEmptyNodes(Node node)
        {
            List<Position> cleared = new List<Position>();
            HashSet<Node> visited = new HashSet<Node>();
            Queue<Node> _nodesToCheck = new Queue<Node>();
            visited.Add(node);
            cleared.Add(node);
            while(_nodesToCheck.Count > 0)
            {
                var n = _nodesToCheck.Dequeue();
                visited.Add(n);
                if(n.Type == Node.NodeType.Empty)
                {
                    n.Status = Node.StatusType.Revealed;
                    cleared.Add(n);
                    if (n.X - 1 >= 0 && !visited.Contains(_board[n.X + 1][n.Y + 1]))
                        _nodesToCheck.Enqueue(_board[n.X + 1][n.Y + 1]);
                    if (n.X + 1 < Width && !visited.Contains(_board[n.X + 1][n.Y]))
                        _nodesToCheck.Enqueue(_board[n.X + 1][n.Y]);
                    if (n.Y + 1 < Height && !visited.Contains(_board[n.X][n.Y + 1]))
                        _nodesToCheck.Enqueue(_board[n.X][n.Y + 1]);
                    if (n.Y - 1 >= 0 && !visited.Contains(_board[n.X][n.Y - 1]))
                        _nodesToCheck.Enqueue(_board[n.X][n.Y - 1]);
                }
            }
            ClearNodesRevealed?.Invoke(this, cleared.ToArray());
        }
        private void _gameOver(Node node)
        {

        }
        private void _populateBoard()
        {
            List<Position> freeLocations = new List<Position>(_settings.Width * _settings.Height);
            _board = new Node[_settings.Width][];
            for(int i = 0; i < _board.Length;i++){
                _board[i] = new Node[_settings.Height];
                for(int j = 0; j < _settings.Height; j++)
                    freeLocations.Add(new Position(i,j));
            }
            _bombs = new HashSet<Node>();
            while (_bombs.Count<_settings.Bombs){
                int i = _r.Next(freeLocations.Count);
                Position pos = freeLocations[i];
                freeLocations.RemoveAt(i);
                Node bomb = new Node(pos,Node.NodeType.Bomb);
                _board[pos.X][pos.Y] = bomb;
                _bombs.Add(bomb);
            }
            foreach(var pos in freeLocations){
                _board[pos.X][pos.Y] = new Node(pos,Node.NodeType.Empty);
            }
            foreach(var bomb in _bombs){

                if(bomb.X > 0){
                    _board[bomb.X - 1][bomb.Y].Type++;
                    if(bomb.Y > 0)
                        _board[bomb.X-1][bomb.Y-1].Type++;
                    if(bomb.Y < _settings.Height-1)
                        _board[bomb.X - 1][bomb.Y+1].Type++;
                }
                if(bomb.X < _settings.Width-1){
                    _board[bomb.X + 1][bomb.Y].Type++;
                    if(bomb.Y > 0)
                        _board[bomb.X + 1][bomb.Y - 1].Type++;
                    if(bomb.Y < _settings.Height-1)
                        _board[bomb.X + 1][bomb.Y + 1].Type++;
                }
                if(bomb.Y > 0)
                    _board[bomb.X][bomb.Y - 1].Type++;
                if(bomb.Y < _settings.Height - 1)
                    _board[bomb.X][bomb.Y + 1].Type++;
            }
        }
    }
}
