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
        TicTakToePage ArrayReff = new TicTakToePage();
        Array Builder = new Array();

        public void PageBuilder()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            HeaderBuilder();

            BorderBuilder();

            FooterBuilder();

            Console.ResetColor();
        }

        public void HeaderBuilder()
        { Builder.DrawArray(ArrayReff.Header, 50, 0);}
        public int GetHeaderRows()
        {
           // Builder.ArrayBuilder(ArrayReff.Header);
            return Builder.GetRows(ArrayReff.Header);
        }

        public void BorderBuilder()
        { Builder.DrawArray(ArrayReff.Border, 50, GetHeaderRows());}
        public int GetBorderRows()
        {
            //Builder.ArrayBuilder(ArrayReff.Border);
            return Builder.GetRows(ArrayReff.Border);
        }

        public void FooterBuilder()
        { Builder.DrawArray(ArrayReff.Footer, 50, GetBorderRows() + GetHeaderRows()); }

    }
}
