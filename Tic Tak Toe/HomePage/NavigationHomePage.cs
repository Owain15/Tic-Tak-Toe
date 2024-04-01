using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tak_Toe.HomePage
{
    internal class NavigationHomePage
    {

        public int[] NavagatePage(ConsoleKey Input, int[]PageReff )
        {
            int GameIndex = PageReff[0];
            int PlayersIndex = PageReff[1];
           
            switch(Input) 
            {
                case (ConsoleKey.UpArrow):   { GameIndex -= 1; break; }
                case (ConsoleKey.DownArrow): { GameIndex += 1; break; }
                case (ConsoleKey.LeftArrow): { PlayersIndex -= 1; break; }
                case (ConsoleKey.RightArrow):{ PlayersIndex += 1; break; }
            }

            //GameIndex = LoopField(GameIndex);
            //PlayersIndex = LoopField(PlayersIndex);


            PageReff[0] = GameIndex;
            PageReff[1] = PlayersIndex;
            
            return PageReff;
        }

        public ConsoleKey GetInput()
        {
            ConsoleKey Input;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Input = keyInfo.Key;
            } while (Console.KeyAvailable);
            return Input;
        }
        //private int LoopField(int Field)
        //{
        //    if (Field > 1) { Field = 0; }
        //    if (Field < 0) { Field = 1; }
        //    return Field;
        //}
    }
}
