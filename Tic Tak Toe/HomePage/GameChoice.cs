using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tak_Toe.HomePage
{
    internal class GameChoice
    {
        public int GameReff;
        public string GameName;

        public int WrightLineX;
        public int WrightLineY;

        public GameChoice(int gameReff, string gameName, int wrightLineX, int wrightLineY)
        {
            GameReff = gameReff;
            GameName = gameName;
            WrightLineX = wrightLineX;
            WrightLineY = wrightLineY;
        }
    }
}
