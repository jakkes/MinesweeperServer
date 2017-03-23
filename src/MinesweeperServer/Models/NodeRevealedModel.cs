namespace MinesweeperServer.Models{
    public class NodeRevealed:ResponseModel{
        public Node Node { get; set; }
        public NodeRevealed(Node node){
            Action = "NodeRevealed";
            Node = node;
        }
    }
}