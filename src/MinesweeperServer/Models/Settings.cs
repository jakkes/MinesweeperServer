using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperServer.Models
{
    public class Settings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Bombs { get; set; }
        public static Settings Easy()
        {
            return new Settings()
            {
                Width = 10,
                Height = 10,
                Bombs = 10
            };
        }
        public static Settings Medium()
        {
            return new Settings()
            {
                Width = 20,
                Height = 20,
                Bombs = 80
            };
        }
        public static Settings Hard()
        {
            return new Settings()
            {
                Width = 30,
                Height = 30,
                Bombs = 270
            };
        }
        public static Settings Extreme()
        {
            return new Settings()
            {
                Width = 40,
                Height = 40,
                Bombs = 640
            };
        }
    }
}
