using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Game;
using Tic_Tak_Toe.Builders;
using Tic_Tak_Toe.Resources;

namespace Tic_Tak_Toe.Game
{
    internal class PlayerClass
    {
        // true = Player Conteroled, Fales = Computer Conteroled Player
        public bool PlyerType;
        public int PlayerIndex;
        public int PlayerLocationIndex;

        public int PlayerScore = 0;
       
        public PlayerClass(int playerIndex, bool playerType)
        {
            PlayerIndex = playerIndex;
            PlayerLocationIndex = 4;
            PlyerType = playerType;
        }

        public void Draw(int[] PlayerLocationReff, int[] GameLocation)
        {

            GameLogicClass TileRef = new GameLogicClass(GameLocation);
            string[,] CurrentArray = TileRef.GetTile(PlayerIndex);
            int Rows = CurrentArray.GetLength(0);
            int Columns = CurrentArray.GetLength(1);
            int LoopCount = 0;
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    string Pixel = CurrentArray[y, x];
                    Console.SetCursorPosition(x + PlayerLocationReff[0], y + PlayerLocationReff[1]);
                    Console.WriteLine(Pixel);

                    if (LoopCount == 4)
                    {
                        Console.SetCursorPosition(x + PlayerLocationReff[0], y + PlayerLocationReff[1]);
                        if (PlayerIndex == 1) { Console.ForegroundColor = ConsoleColor.Blue; }
                        else {  Console.ForegroundColor = ConsoleColor.Cyan;}
                        Console.WriteLine(Pixel);
                        Console.ResetColor();
                    }
                    LoopCount++;
                }

            }
        }
            public void DrawError(int[] PlayerLocationReff, int[] GameLocation)
        {
           
            GameLogicClass TileRef = new GameLogicClass(GameLocation);
            string[,] CurrentArray = TileRef.GetTile(PlayerIndex);
            int Rows = CurrentArray.GetLength(0);
            int Columns = CurrentArray.GetLength(1);
            int LoopCount = 0;
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    string Pixel = CurrentArray[y, x];
                    Console.SetCursorPosition(x + PlayerLocationReff[0], y + PlayerLocationReff[1]);
                    Console.WriteLine(Pixel);

                    if (LoopCount == 4)
                    {
                        Console.SetCursorPosition(x + PlayerLocationReff[0], y + PlayerLocationReff[1]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Pixel);
                        Console.ResetColor();
                    }
                    LoopCount++;
                }

            }
        }

    }
}
