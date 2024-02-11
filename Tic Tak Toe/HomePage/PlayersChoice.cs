using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tak_Toe.HomePage
{
    internal class PlayersChoice
    {

        public int PlayersReff;
        public string PlayersString;

        public int WrightLineX;
        public int WrightLineY;

        public PlayersChoice(int playersReff, string playersString,int wrightLineX, int wrightLineY)
        {
           PlayersReff = playersReff;
           PlayersString = playersString;
           WrightLineX = wrightLineX;
           WrightLineY = wrightLineY;

        }
    }
}
