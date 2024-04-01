using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Game;
using Tic_Tak_Toe.Builders;
using Tic_Tak_Toe.Resources;

namespace Tic_Tak_Toe.Builders
{
    internal class PageClass
    {
        TicTakToeSinglePage ArrayReff = new TicTakToeSinglePage();
        Array Builder = new Array();
        int[] GameLocation;
        public PageClass(int[] gameLocation) { GameLocation = gameLocation; }

        public void PageBuilder()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            HeaderBuilder();

            BorderBuilder();

            FooterBuilder();

            Console.ResetColor();
        }

        public void HeaderBuilder()
        { Builder.DrawArray(ArrayReff.Header, GameLocation[0]-1, GameLocation[1]-1);}
        public int GetHeaderHight()
        {
           // Builder.ArrayBuilder(ArrayReff.Header);
            return Builder.GetRows(ArrayReff.Header);
        }

        public void BorderBuilder()
        { Builder.DrawArray(ArrayReff.Border, GameLocation[0] - 1, GameLocation[1]-1+ GetHeaderHight());}
        public int GetBorderHight()
        {
            //Builder.ArrayBuilder(ArrayReff.Border);
            return Builder.GetRows(ArrayReff.Border);
        }

        public void FooterBuilder()
        { Builder.DrawArray(ArrayReff.Footer, GameLocation[0]-1,GameLocation[1]-1+ GetBorderHight() + GetHeaderHight()); }

    }
}
