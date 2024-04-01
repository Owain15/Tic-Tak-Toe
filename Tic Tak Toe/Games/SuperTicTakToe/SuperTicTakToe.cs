using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Game.SuperTicTakToe;
using Tic_Tak_Toe.Builders;
using System.Numerics;
using System.ComponentModel.DataAnnotations;

namespace Tic_Tak_Toe.Game.SuperTicTakToe
{
    internal class SuperTicTakToe
    {
        PlayerClass PlayerOne;
        PlayerClass PlayerTwo;

        PlayerClass CurrentPlayer;
        SuperTicTakToeGameClass CurrentGame;
        SuperTicTakToeLogic logic;
        Tic_Tak_Toe.Builders.Array Build;
        Tic_Tak_Toe.Resources.SuperTripleTPage Array;
        GameLogicClass DataHandler;

        SuperTicTakToeGameClass[] GameBoredArrays;
        int[,] GameReffs;

        int GameInPlay;
        int?[] MasterGameBored;
        int?[] MasterGameChecker;

        public bool DisplayGameData;

        SuperTicTakToeGameClass GameZero;
        SuperTicTakToeGameClass GameOne;
        SuperTicTakToeGameClass GameTwo;
        SuperTicTakToeGameClass GameThree;
        SuperTicTakToeGameClass GameFour;
        SuperTicTakToeGameClass GameFive;
        SuperTicTakToeGameClass GameSix;
        SuperTicTakToeGameClass GameSeven;
        SuperTicTakToeGameClass GameEight;

        int[] GameLocation;
      
        
        public SuperTicTakToe(PlayerClass playerOne, PlayerClass playerTwo, int[] gameLocation)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
            CurrentPlayer = PlayerOne;
            GameInPlay = 4;
            GameLocation = gameLocation;
            GameReffs = new int[9, 2]
  {
                {49,2 },{60,2 },{71,2 },
                {49,12},{60,12},{71,12},
                {49,22},{60,22},{71,22}
  };

            GameZero = new SuperTicTakToeGameClass(0, ArrayBuilderInt(GameReffs, 0), CurrentPlayer);
            GameOne = new SuperTicTakToeGameClass(1, ArrayBuilderInt(GameReffs, 1), CurrentPlayer);
            GameTwo = new SuperTicTakToeGameClass(2, ArrayBuilderInt(GameReffs, 2), CurrentPlayer);
            GameThree = new SuperTicTakToeGameClass(3, ArrayBuilderInt(GameReffs, 3), CurrentPlayer);
            GameFour = new SuperTicTakToeGameClass(4, ArrayBuilderInt(GameReffs, 4), CurrentPlayer);
            GameFive = new SuperTicTakToeGameClass(5, ArrayBuilderInt(GameReffs, 5), CurrentPlayer);
            GameSix = new SuperTicTakToeGameClass(6, ArrayBuilderInt(GameReffs, 6), CurrentPlayer);
            GameSeven = new SuperTicTakToeGameClass(7, ArrayBuilderInt(GameReffs, 7), CurrentPlayer);
            GameEight = new SuperTicTakToeGameClass(8, ArrayBuilderInt(GameReffs, 8), CurrentPlayer);


            GameBoredArrays = new SuperTicTakToeGameClass[9]
            {   GameZero , GameOne , GameTwo ,
               GameThree ,  GameFour ,GameFive,
              GameSix , GameSeven , GameEight
            };
            DataHandler = new GameLogicClass(GameLocation);

            MasterGameBored = new int?[9] { null, null, null, null, null, null, null, null, null };
            MasterGameChecker = new int?[9]; 

            DisplayGameData = false;

            CurrentGame = GameFour;
            logic = new SuperTicTakToeLogic(CurrentPlayer, CurrentGame, DisplayGameData, GameLocation);
            Build = new Builders.Array();
            Array = new Resources.SuperTripleTPage();
        }


        
        
        public void Run()
        {
            Console.Clear();

            CurrentPlayer.PlayerLocationIndex = 4;

            RenderAllGames();

            DisplayGameDataCheck();
            
            int? MasterGameResult = null;
            
            while (MasterGameResult == null)
            {

                CurrentGame.GameResult = logic.RunPlayerTurn();
               
                HandleGameResult();
                
                LogCurrentGameToMasterBored();

                MasterGameResult = logic.MasterEvaluateGame(MasterGameBored, MasterGameChecker);

                DisplayGameDataCheck();

                ChangeCurrentPlayerAndGame();

            }
            
            BuildRenderEndScreen((int)MasterGameResult);
          
            Console.Read();
            Console.Clear();

            Tic_Tak_Toe.HomePage.HomePage Start = new Tic_Tak_Toe.HomePage.HomePage(GameLocation);
            Start.OpenHomePage();

        }




        public int[] ArrayBuilderInt(int[,] Array, int ChosenArray)
        {

            int A = Array[ChosenArray, 0];
            int B = Array[ChosenArray, 1];

            int[] Build = new int[2] { A, B };

            return Build;
        }
        private void RenderAllGames()
        {
            GameZero.Render();
            GameOne.Render();
            GameTwo.Render();
            GameThree.Render();
            GameFour.Render();
            GameFive.Render();
            GameSix.Render();
            GameSeven.Render();
            GameEight.Render();

        }
        private SuperTicTakToeGameClass GetGame(int GameInPlay)
        {
            SuperTicTakToeGameClass ChossenGame = GameFour;
            switch (GameInPlay)
            { case 0: { ChossenGame = GameZero; } break;
                case 1: { ChossenGame = GameOne; } break;
                case 2: { ChossenGame = GameTwo; } break;
                case 3: { ChossenGame = GameThree; } break;
                case 4: { ChossenGame = GameFour; } break;
                case 5: { ChossenGame = GameFive; } break;
                case 6: { ChossenGame = GameSix; } break;
                case 7: { ChossenGame = GameSeven; } break;
                case 8: { ChossenGame = GameEight; } break;

            }
            return ChossenGame;
        }
        private void ChangeGame()
        {
            
            int NextGameId = CurrentPlayer.PlayerLocationIndex;
            bool IsNextGameInPlay = CheckGameIsInPlay(GetGame(NextGameId));

            if (IsNextGameInPlay != true)
            {
                NextGameId = CurrentGame.GameID;
                IsNextGameInPlay = CheckGameIsInPlay(GetGame(NextGameId));
                while (IsNextGameInPlay != true)
                {
                    NextGameId ++;
                    if (NextGameId > 8) { NextGameId = 0; }
                    IsNextGameInPlay = CheckGameIsInPlay(GetGame(NextGameId));
                }
            }
             CurrentGame = GetGame(NextGameId);
        }
        private void ChangePlayer()
        {
            if (CurrentPlayer.PlayerIndex == 1) { CurrentPlayer = PlayerTwo; }
            else { CurrentPlayer = PlayerOne; }
            
            CurrentPlayer.PlayerLocationIndex = 4;

        }
        private void ChangeCurrentPlayerAndGame()
        {    
            ChangeGame();
        
            ChangePlayer();
            
            logic = new SuperTicTakToeLogic(CurrentPlayer, CurrentGame, DisplayGameData, GameLocation);   
        }
        private bool CheckGameIsInPlay(SuperTicTakToeGameClass ChosenGame)
        {
            bool IsGameInPlay = ChosenGame.GameInPlay;
            return IsGameInPlay;

        }
        private void LogCurrentGameToMasterBored()
        {
            MasterGameBored.SetValue(CurrentGame.GameResult, CurrentGame.GameID);
        }
        private void TestDataGame(SuperTicTakToeGameClass Game, int CurserLine)
        {

            Console.SetCursorPosition(0, CurserLine);
            Console.WriteLine("\nGame Bored Game " + Game.GameID + ": " + Game.GameBoredIndex[0] + "," + Game.GameBoredIndex[1] + ","
                + Game.GameBoredIndex[2] + "," + Game.GameBoredIndex[3] + "," + Game.GameBoredIndex[4] + ","
                + Game.GameBoredIndex[5] + "," + Game.GameBoredIndex[6] + "," + Game.GameBoredIndex[7]
                + "," + Game.GameBoredIndex[8]);


        }
        private void TestDataAllGames()
        {
            TestDataGame(GameZero, 2); TestDataGame(GameOne, 5); TestDataGame(GameTwo, 8);
            TestDataGame(GameThree, 11); TestDataGame(GameFour, 14); TestDataGame(GameFive, 17);
            TestDataGame(GameSix, 20); TestDataGame(GameSeven, 23); TestDataGame(GameEight, 26);

        }
        private void TestDataMasterBored()
        {
            Console.SetCursorPosition(90, 4);
            Console.WriteLine("Master Gamebored");
            Console.SetCursorPosition(90, 5);
            Console.WriteLine("." + MasterGameBored[0] + "," + MasterGameBored[1] + "," + MasterGameBored[2] + "," +
                MasterGameBored[3] + "," + MasterGameBored[4] + "," +
                MasterGameBored[5] + "," + MasterGameBored[6] + "," + MasterGameBored[7] + "," + MasterGameBored[8]);

        }
        private void DisplayGameDataCheck()
        {
            if (DisplayGameData == true)
            { 
            TestDataAllGames();
            TestDataMasterBored();
            }
        }
        private void HandleGameResult()
        {
           if(CurrentGame.GameResult != null) { CurrentGame.GameInPlay = false; }
            CurrentGame.RenderResult();
        }
        private string[,] GetEndScreen(int MasterEvaluation)
        {
            string[,] GameResult = Array.ItsADraw; ;
            switch (MasterEvaluation) 
            {
                case 3: { GameResult = Array.PlayerXWins; } break;
                case-3: { GameResult = Array.PlayerOWins; } break;
                case 0: { GameResult = Array.ItsADraw;    } break;
            }
            return GameResult;
        }
        private string[,] GetEndScreenCenter(int MasterEvaluation)
        {
            Resources.TicTakToeSinglePage CenterArray = new Resources.TicTakToeSinglePage();
            
            string[,] GameResult = CenterArray.ItsADrawScreen ;
            switch (MasterEvaluation)
            {
                case 3: { GameResult = CenterArray.XWinsScreen;    } break;
                case-3: { GameResult = CenterArray.OWinsScreen;    } break;
                case 0: { GameResult = CenterArray.ItsADrawScreen; } break;
            }
            return GameResult;
        }
        private void BuildRenderEndScreen(int MasterEvaluation)
        {
           

            Build.DrawArray(GetEndScreen(MasterEvaluation), GameReffs[0, 0], GameReffs[0, 1]);
            Build.DrawArray(GetEndScreenCenter(MasterEvaluation), GameReffs[4, 0], GameReffs[4, 1]);

            Console.SetCursorPosition(48,40);
            Console.WriteLine("Press Enter To Return To Main Menu.");

        }




    }
}
