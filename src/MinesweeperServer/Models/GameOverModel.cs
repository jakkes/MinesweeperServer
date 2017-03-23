namespace MinesweeperServer.Models{
    public class GameOverModel : ResponseModel{
        public Node[][] Board { get; set; }
        public GameOverModel(Node[][] board){
            Action = "GameOver";
            Board = board;
        }
    }
}