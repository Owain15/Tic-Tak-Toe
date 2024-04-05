using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Game;
using Tic_Tak_Toe.Game.SuperTicTakToe;
using Tic_Tak_Toe.Games.TicTakToe;



namespace Tic_Tak_Toe.HomePage
{
    internal class HomePageLogic
    {
        Resources.HomePage Render = new Resources.HomePage();
        Builders.Array Build = new Builders.Array();
        NavigationGame Move;

        Tic_Tak_Toe.Game.PlayerClass PlayerOne = new Tic_Tak_Toe.Game.PlayerClass(1, true);
        Tic_Tak_Toe.Game.PlayerClass PlayerTwo = new Tic_Tak_Toe.Game.PlayerClass(-1, true);
        
        int[] GameLocation;

        public HomePageLogic(int[] gameLocation)
        {
            GameLocation = gameLocation;
            Move = new NavigationGame(GameLocation);
        }

        public bool RunHomePageLogic(int[] PageReff)
        {
            Tic_Tak_Toe.HomePage.HomePage Reset = new Tic_Tak_Toe.HomePage.HomePage(GameLocation);

           // int[] GamePositionReff = new int[] { GameLocation[0]+5, GameLocation[1]+3 };
            PlayerClass PlayerOne = new PlayerClass(1, true);
            PlayerClass PlayerTwo = new PlayerClass(-1, true);

            bool CloseApplication = false;

            int GameReff = PageReff[0];
            int PlayersReff = PageReff[1];

            switch (GameReff)
            {
                case (0):
                    {
                        switch (PlayersReff)
                        {
                            case (0):
                                { 
                                    bool GameLoop = RunGetGameLoopPage();
                                    int ScoreLimit = 1;
                                    
                                    if (GameLoop) { ScoreLimit = RunGetScoreLimitPage(); }

                                    SingleGameTTT Game = new SingleGameTTT(GameLocation, GameLoop, ScoreLimit);
                                    
                                    Game.Run();


                                
                                } break;
                            case (1): { GameUnderConstruction(); } break;
                            case (2): { GameUnderConstruction(); } break;
                        }
                    }
                    break;
                case (1):
                    {
                        switch (PlayersReff)
                        {
                            case (0):
                                {
                                    SuperTicTakToe Game = new SuperTicTakToe(PlayerOne, PlayerTwo, GameLocation);
                                    Game.Run();
                                    
                                } break;
                            case (1): { GameUnderConstruction(); } break;
                            case (2): { GameUnderConstruction(); } break;
                        }
                    
                    }
                    break;
                case (2): 
                {
                        CloseApplication = true;
                }break;
            }

            return CloseApplication;

        }
        private void GameUnderConstruction()
        {
            Tic_Tak_Toe.Resources.HomePage Reff = new Tic_Tak_Toe.Resources.HomePage();
            Tic_Tak_Toe.Builders.Array Builder = new Tic_Tak_Toe.Builders.Array();
            


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Builder.DrawArray(Reff.HomePageBorder, 40, 2);
            Console.SetCursorPosition(43, 6);
            Console.WriteLine("Game Is Still Under Construction");
            Console.SetCursorPosition(46, 7);
            Console.WriteLine("Please Try Again Later.");
            Console.SetCursorPosition(43, 11);
            Console.WriteLine("Press Enter To Return To HomePage");
            Console.ResetColor();

            Console.Read();
            Console.Clear();
           // Reset.OpenHomePage();
        }
        private bool RunGetGameLoopPage()
        {

            Console.ForegroundColor= ConsoleColor.DarkGray;
            
            bool Result = false;

            string Prompt1 = "Single Game";
            string Prompt2 = "First Too";

            Build.DrawArray(Render.HomePageBorder, GameLocation[0]-11, GameLocation[1]+1);
          
            Console.SetCursorPosition(GameLocation[0]+6, GameLocation[1]+5);
            Console.WriteLine("Play");

            Console.SetCursorPosition(GameLocation[0]+7, GameLocation[1]+8);
            Console.WriteLine("or");

            ConsoleKey Input = ConsoleKey.Z;
            
            while (Input != ConsoleKey.Enter)
            { 

                if (!Result) { Console.ForegroundColor = ConsoleColor.Green;}
                else { Console.ForegroundColor = ConsoleColor.DarkGray;}
                Console.SetCursorPosition(GameLocation[0] + 3, GameLocation[1] + 7);
                Console.WriteLine(Prompt1);

                if (Result) { Console.ForegroundColor = ConsoleColor.Green; }
                else { Console.ForegroundColor = ConsoleColor.DarkGray; }
                Console.SetCursorPosition(GameLocation[0] + 4, GameLocation[1] + 9);
                Console.WriteLine(Prompt2);


                Input = Move.GetInput();
                if(Input == ConsoleKey.UpArrow) { Result = false; }
                if (Input == ConsoleKey.DownArrow) {  Result = true; }

            }

            Console.ResetColor();

            return Result;
        }
        private int RunGetScoreLimitPage()
        {

            Console.ForegroundColor = ConsoleColor.DarkGray;

            int ScoreLimit = 2;

            string Prompt = "First To Reach";


            Build.DrawArray(Render.HomePageBorder, GameLocation[0] - 11, GameLocation[1] + 1);

            Console.SetCursorPosition(GameLocation[0] + 1, GameLocation[1] + 6);
            Console.WriteLine(Prompt);

            

            ConsoleKey Input = ConsoleKey.Z;

            while (Input != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(GameLocation[0] + 7, GameLocation[1] + 8);
                Console.WriteLine(ScoreLimit);



                Input = Move.GetInput();
                if (Input == ConsoleKey.LeftArrow) { ScoreLimit --; }
                if (Input == ConsoleKey.RightArrow) { ScoreLimit ++; }

                if (Input == ConsoleKey.DownArrow) { ScoreLimit--; }
                if (Input == ConsoleKey.UpArrow) { ScoreLimit++; }

                if (ScoreLimit < 2) { ScoreLimit = 2; }
                if(ScoreLimit > 5) { ScoreLimit = 5; }

            }

            Console.ResetColor();

            return ScoreLimit;
        }
    }
    
}
