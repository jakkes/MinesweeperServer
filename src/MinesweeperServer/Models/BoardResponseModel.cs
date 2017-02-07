namespace MinesweeperServer.Models
{
    public class BoardResponseModel : ResponseModel
    {
        public Node[][] Board { get; set; }
        public BoardResponseModel()
        {
            Action = "Board";
        }
    }
}
