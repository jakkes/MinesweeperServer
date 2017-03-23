namespace MinesweeperServer.Models
{
    public class NewGameRequestModel : RequestModel
    {
        public string Mode { get; set; }
        public string SettingsMode { get; set; } 
        public Settings Config { get; set; }
        public NewGameRequestModel()
        {
            Action = "NewGame";
        }
    }
}
