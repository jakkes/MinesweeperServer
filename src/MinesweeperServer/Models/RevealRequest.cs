namespace MinesweeperServer.Models{
    public class RevealRequest : RequestModel{
        public Position Node { get; set; }
        public RevealRequest(){
            Action = "Reveal";
        }
    }
}