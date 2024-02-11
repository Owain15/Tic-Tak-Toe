using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Builders;

namespace Tic_Tak_Toe.Game.SuperTicTakToe
{
    internal class SuperTicTakToeLogic
    {
       
        TicTakToeGameClass CurrentGame;
        PlayerClass CurrentPlayer;
       
        RenderClass Screen;
        GameLogicClass Logic;
        NavigationGame Move;

        int[] GameChecker;
        bool DisplayGameData;

        public SuperTicTakToeLogic(PlayerClass currentPlayer,TicTakToeGameClass currentGame,bool displayGameData)
        { 
            //PlayerOne = playerOne; 
            //PlayerTwo = playerTwo;
            CurrentPlayer = currentPlayer;
            CurrentGame = currentGame;

            Screen = new RenderClass(CurrentPlayer, CurrentGame.GameBoredIndex,CurrentGame.GamePosition);
            Logic = new GameLogicClass();
            Move = new NavigationGame();

            GameChecker = new int[9];
            DisplayGameData = displayGameData;
        }

        public int[] GetPlayerLoationReff(int PlayerLocationIndex, int[] GameBoredPosition)
        {
            
            int X = GameBoredPosition[0];
            int Y = GameBoredPosition[1];

            switch(PlayerLocationIndex) 
            {
                case 0:break;
                case 1: { X += 3; Y += 0; } break;
                case 2: { X += 6; Y += 0; } break;
                case 3: { X += 0; Y += 3; } break;
                case 4: { X += 3; Y += 3; } break;
                case 5: { X += 6; Y += 3; } break;
                case 6: { X += 0; Y += 6; } break;
                case 7: { X += 3; Y += 6; } break;
                case 8: { X += 6; Y += 6; } break;
               
            }
            int[] PlayerLocationReff = new int[2]
                {X, Y};
            return PlayerLocationReff;

        }
        public int? RunPlayerTurn()
        {
            CurrentGame.Render();
            Screen.RenderPlayer(GetPlayerLoationReff(CurrentPlayer.PlayerLocationIndex, CurrentGame.GamePosition),
                CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex,CurrentGame.GameBoredIndex));
            bool IsMoveFreeToSet = false;
           
            DisplayGameDataCheck();

            while (IsMoveFreeToSet == false)
            {
                
                ConsoleKey Input = Move.GetInput();

                while (Input != ConsoleKey.Enter)
                {
                    AditinalInputChecks(Input);
                    int CurrentPlayerLocationIndex = CurrentPlayer.PlayerLocationIndex;
                    int NextPlayerLocationIndex = Move.GetNextPlayerLocationIndex(CurrentPlayer.PlayerLocationIndex, Input);
                    CurrentPlayer.PlayerLocationIndex = Move.isMoveInBounds(NextPlayerLocationIndex, CurrentPlayerLocationIndex);

                    CurrentGame.Render();
                    Screen.RenderPlayer(GetPlayerLoationReff(CurrentPlayer.PlayerLocationIndex, CurrentGame.GamePosition),
                 CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex, CurrentGame.GameBoredIndex));
                   
                    DisplayGameDataCheck();
                    Input = Move.GetInput();
                }
                IsMoveFreeToSet = Move.CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex,CurrentGame.GameBoredIndex);
            }
            
            CurrentGame.SetToBord(CurrentPlayer);
            CurrentGame.Render();
            
            int? CurrentGameResult = EvaluateGame(CurrentGame.GameBoredIndex,GameChecker);
            return CurrentGameResult;
        }
       
        
        private int? EvaluateGame(int[] CurrentGameBoredIndex, int[] gameChecker)
        {
            Logic.SetWinChecker(CurrentGameBoredIndex, gameChecker);

            int? Evaluation = CheckWinChecker(gameChecker);

            if (Evaluation == 0) 
            {
                foreach (int I in CurrentGameBoredIndex)
                { if (I == 0) { Evaluation = null; return Evaluation; }  }
              
            }
           
            return Evaluation;

        }

        public int CheckWinChecker(int[] gameChecker)
        { 
            foreach (int Game in gameChecker)
            { if (Game > 2) { return Game; } if (Game < -2) { return Game; } }
            int NoWinner = 0;
            return NoWinner;
        }
        public int? CheckWinCheckerWithNull(int?[] gameChecker)
        {
            int? Result = null;
            foreach (int? Game in gameChecker)
            {
                if (Game > 2) { Result = 3; } if (Game < -2) { Result = -3; } if (Game == 0) { Result = 0; }
            }
            return Result;
        }
        private void AditinalInputChecks(ConsoleKey Input)
        {
            switch(Input)
            {
                case ConsoleKey.Escape:
                    {
                        Console.Clear();

                        Tic_Tak_Toe.HomePage.HomePage Start = new Tic_Tak_Toe.HomePage.HomePage();
                        Start.OpenHomePage();
                    } break;
                //case ConsoleKey.I: { DisplayGameData == true; }break;
            }

        }
        private bool CheckMoveIsFreeToSet(int PlayerLocationIndex, int[] GameBoredIndex) 
        {
            bool Result = false;

            if (GameBoredIndex[PlayerLocationIndex] == 0) { Result = true; }

            return Result;
        }
        private void TestDataCurrentData()
        {
            Console.SetCursorPosition(90, 15);
            Console.WriteLine("Current Player Location Index");
            Console.SetCursorPosition(90, 16);
            Console.WriteLine("." + CurrentPlayer.PlayerLocationIndex);
            Console.SetCursorPosition(90, 18);
            Console.WriteLine("Current Game ");
            Console.SetCursorPosition(90, 19);
            Console.WriteLine("." + CurrentGame.GameID);
            Console.SetCursorPosition(90, 23);
            Console.WriteLine("Current Game Bored Index");
            Console.SetCursorPosition(90, 24);
            Console.WriteLine(CurrentGame.GameBoredIndex[0]+","+ CurrentGame.GameBoredIndex[1] + "," + CurrentGame.GameBoredIndex[2] + "," +
                CurrentGame.GameBoredIndex[3] + "," + CurrentGame.GameBoredIndex[4] + "," + CurrentGame.GameBoredIndex[5] + "," +
                CurrentGame.GameBoredIndex[6] + "," + CurrentGame.GameBoredIndex[7] + "," + CurrentGame.GameBoredIndex[8]);
        }
        private void DisplayGameDataCheck()
        { if (DisplayGameData == true) { TestDataCurrentData(); } }
        public void SetMasterWinChecker(int?[] MasterGameBoredIndex, int?[] MasterGameChecker)
        {
            int?[] GameBoredIndex = MasterGameBoredIndex;
            int?[] GameChecker = MasterGameChecker;

            GameChecker.SetValue(GameBoredIndex[0] + GameBoredIndex[1] + GameBoredIndex[2], 0);
            GameChecker.SetValue(GameBoredIndex[3] + GameBoredIndex[4] + GameBoredIndex[5], 1);
            GameChecker.SetValue(GameBoredIndex[6] + GameBoredIndex[7] + GameBoredIndex[8], 2);
            GameChecker.SetValue(GameBoredIndex[0] + GameBoredIndex[3] + GameBoredIndex[6], 3);
            GameChecker.SetValue(GameBoredIndex[1] + GameBoredIndex[4] + GameBoredIndex[7], 4);
            GameChecker.SetValue(GameBoredIndex[2] + GameBoredIndex[5] + GameBoredIndex[8], 5);
            GameChecker.SetValue(GameBoredIndex[0] + GameBoredIndex[4] + GameBoredIndex[8], 6);
            GameChecker.SetValue(GameBoredIndex[6] + GameBoredIndex[4] + GameBoredIndex[2], 7);

        }
        public int? MasterEvaluateGame(int?[] MasterGameBoredIndex, int?[] MasterGameChecker)
        {
            SetMasterWinChecker(MasterGameBoredIndex, MasterGameChecker);

            int? Evaluation = CheckWinCheckerWithNull(MasterGameChecker);

            return Evaluation;

        }


    }  
}
