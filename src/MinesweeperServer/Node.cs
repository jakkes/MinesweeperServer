using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperServer
{
    public class Node : Position
    {
        public StatusType Status { get; set; } = StatusType.Hidden;
        public NodeType Type { get; internal set; }

        public Node(int X, int Y, NodeType Type) : base(X,Y)
        {
            this.Type = Type;
        }
        public Node(Position pos, NodeType Type) : this(pos.X,pos.Y, Type) {}


        public enum NodeType
        {
            Bomb = -1,
            Empty = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8
        }
        public enum StatusType
        {
            Revealed,
            Flagged,
            Hidden
        }
    }
}
