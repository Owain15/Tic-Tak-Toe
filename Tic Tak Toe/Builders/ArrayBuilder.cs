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
    internal class Array
    {
        //private string[,] CurrentArray;
        private int Rows;
        private int Columns;




        private void ArrayBuilder(string[,] array)
        {
           string[,] CurrentArray = array;
            Rows = CurrentArray.GetLength(0);
            Columns = CurrentArray.GetLength(1);

        }

        public void DrawArray(string[,] Array, int StartX, int StartY)
        {
           
            ArrayBuilder(Array);

            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    string Pixel = Array[y, x];
                    Console.SetCursorPosition(x + StartX, y + StartY);
                    Console.WriteLine(Pixel);
                }

            }

        }
        public void DrawBoredTile(int PlayerIndex,int StartX, int StartY, int[] GameLocation)
        {
            GameLogicClass logicClass = new GameLogicClass(GameLocation);

            string[,] Array = logicClass.GetTile(PlayerIndex);
            ArrayBuilder(Array);

            int LoopCount = 0;

            Console.ForegroundColor = ConsoleColor.DarkGray;

            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    string Pixel = Array[y, x];
                    Console.SetCursorPosition(x + StartX, y + StartY);
                    Console.WriteLine(Pixel);

                    if (LoopCount == 4)
                    {
                        Console.SetCursorPosition(x + StartX, y + StartY);
                        if (PlayerIndex == 1) { Console.ForegroundColor = ConsoleColor.DarkBlue; }
                        else if (PlayerIndex == -1) { Console.ForegroundColor = ConsoleColor.DarkCyan; }
                        Console.WriteLine(Pixel);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    LoopCount++;

                }

            }Console.ResetColor();

        }

        public int GetRows(string[,] Array)
        { ArrayBuilder(Array); return Rows; }

    }
}
