using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Game;
using Tic_Tak_Toe.Game.SuperTicTakToe;



namespace Tic_Tak_Toe.HomePage
{
    internal class HomePageLogic
    {
        Tic_Tak_Toe.Game.PlayerClass PlayerOne = new Tic_Tak_Toe.Game.PlayerClass(1, true);
        Tic_Tak_Toe.Game.PlayerClass PlayerTwo = new Tic_Tak_Toe.Game.PlayerClass(-1, true);
        
       
        
        public void RunHomePageLogic(int[] PageReff)
        {
            int[] GamePositionReff = new int[] {56,4};
            PlayerClass PlayerOne = new PlayerClass(1,true);
            PlayerClass PlayerTwo = new PlayerClass(-1,true);
            Tic_Tak_Toe.Game.GameLogicClass Application = new Tic_Tak_Toe.Game.GameLogicClass();
            

            int GameReff = PageReff[0];
            int PlayersReff = PageReff[1];

            switch (GameReff)
            {
                case (0):
                    {
                        switch (PlayersReff)
                        {
                            case (0): { Application.Game(PlayerOne,PlayerTwo,GamePositionReff,true); } break;
                            case (1): { GameUnderConstruction(); } break;
                        }
                    }
                    break;
                case (1):
                    {
                        switch (PlayersReff)
                        {
                            case (0): { Application.RunSuperTT(PlayerOne,PlayerTwo); } break;
                            case (1): { GameUnderConstruction(); } break;
                        }
                    }
                    break;
            }
        }
        private void GameUnderConstruction()
        { 
            Tic_Tak_Toe.Resources.HomePage Reff = new Tic_Tak_Toe.Resources.HomePage();
            Tic_Tak_Toe.Builders.Array Builder = new Tic_Tak_Toe.Builders.Array();
            Tic_Tak_Toe.HomePage.HomePage Reset = new Tic_Tak_Toe.HomePage.HomePage();


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Builder.DrawArray(Reff.HomePageBorder,40,2);
            Console.SetCursorPosition(43, 6);
            Console.WriteLine("Game Is Still Under Construction");
            Console.SetCursorPosition(46, 7);
            Console.WriteLine("Please Try Again Later.");
            Console.SetCursorPosition(43, 11);
            Console.WriteLine("Press Enter To Return To HomePage");
            Console.ResetColor();

            Console.Read();
            Console.Clear();
            Reset.OpenHomePage();
        }
    }
    
}
