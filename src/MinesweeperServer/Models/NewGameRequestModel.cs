using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperServer.Models
{
    public class NewGameRequestModel : RequestModel
    {
        public string Mode { get; set; }
        public Settings Config { get; set; }
        public NewGameRequestModel()
        {
            Action = "NewGame";
        }
    }
}
