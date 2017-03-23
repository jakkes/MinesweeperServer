namespace MinesweeperServer.Models
{
    public class ClearNodesRevealedModel : ResponseModel {
        public Position[] Nodes { get; set; }
        public ClearNodesRevealedModel(Position[] nodes){
            Action = "ClearNodesRevealed";
            Nodes = nodes;
        }
    }
}