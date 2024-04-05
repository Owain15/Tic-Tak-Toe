using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Builders;
using Tic_Tak_Toe.Game;

namespace Tic_Tak_Toe.Games.TicTakToe
{
    internal class SingleGameTTT
    {
        Tic_Tak_Toe.Builders.PageClass Page;
        Tic_Tak_Toe.Builders.RenderClass Render;
        GameLogicClass Logic;
        NavigationGame Move;
        CCPLogic CPLogic;
        

        PlayerClass PlayerOne;
        PlayerClass PlayerTwo;

        PlayerClass CurrentPlayer;

        int GameResult;

        bool LoopGame;

        int PlayerOneScore;
        int PlayerTwoScore;

        int ScoreLimit;

        int PlayerLocationIndex;

        int[] GameLocation;
        int[] GameBoredLocation;

        int[] GameBoredIndex;
        int[] GameChecker; 

        public SingleGameTTT(int[] gameLocation, bool loopGame, int scoreLimit )
        {
          
            GameLocation = gameLocation;

            

            PlayerOne = new PlayerClass( 1,true );
            PlayerTwo = new PlayerClass( -1,false );

            

            LoopGame = loopGame;

            PlayerOneScore = 0;
            PlayerTwoScore = 0;

            PlayerLocationIndex = 4;

            GameBoredIndex = new int[9];
            GameChecker = new int[8];

            ScoreLimit = scoreLimit;

            Page = new Builders.PageClass(GameLocation);
            Logic = new GameLogicClass(GameLocation);
            Render = new RenderClass(GameLocation);
            Move = new NavigationGame(GameLocation);
            CPLogic = new CCPLogic();

            GameBoredLocation = new int[2];
            GameBoredLocation[0] = GameLocation[0]+Page.GetHeaderHight()+1;
            GameBoredLocation[1] = GameLocation[1]+4;

            CurrentPlayer = PlayerOne;
            
        }
        public void Run()
        {
            Console.Clear();

            Page.PageBuilder();

            bool GameOver = false;
            bool MoveMade = false;

            int TurnCount = 0;

            ConsoleKey Input;

            PlayerIndicatorsSetUp();
            OpitinalScoreSetUp();
            RenderScore();
            
            do
            {
                
                GameBoredIndex = Logic.ResetGameBored(GameBoredIndex);
                GameChecker = Logic.ResetGameChecker(GameChecker);
                
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Page.BorderBuilder();
                Page.FooterBuilder();
                Console.ResetColor();

                while (!GameOver)
                {

                    HighlightPlayer(CurrentPlayer);
                    
                    if (CurrentPlayer.PlyerType == false)
                    {
                        //Render.RenderGameBored(GameBoredLocation, GameBoredIndex);
                        //Render.RenderPlayer(Move.GetGridReff(GameBoredLocation, PlayerLocationIndex),
                        //    Logic.CheckMoveIsFreeToSet(PlayerLocationIndex, GameBoredIndex), CurrentPlayer);

                        int CCPMoveIndex = CPLogic.GetSingleGame(CurrentPlayer.PlayerIndex, GameBoredIndex); 
                    }
                    else 
                    { 
                        while (!MoveMade)
                        {
                        Render.RenderGameBored(GameBoredLocation, GameBoredIndex);
                        Render.RenderPlayer(Move.GetGridReff(GameBoredLocation, PlayerLocationIndex),
                            Logic.CheckMoveIsFreeToSet(PlayerLocationIndex, GameBoredIndex), CurrentPlayer);
                        Input = Move.GetInput();
                        if (Input == ConsoleKey.Enter)
                        {
                            bool MoveIsFree = Logic.CheckMoveIsFreeToSet(PlayerLocationIndex, GameBoredIndex);
                            if (MoveIsFree)
                            {
                                MoveMade = true;
                                GameBoredIndex = Logic.SetToBored(CurrentPlayer.PlayerIndex, PlayerLocationIndex, GameBoredIndex);
                            }

                        }
                        else { PlayerLocationIndex = Move.GetNextPlayerLocationIndex(PlayerLocationIndex, Input); }

                    }
                    
                        MoveMade = false;

                    }

                    GameChecker = Logic.SetWinChecker(GameBoredIndex, GameChecker);
                    GameOver = Logic.EvaluateGame(GameBoredIndex, GameChecker);

                    CurrentPlayer = Logic.SwitchPlayer(CurrentPlayer, PlayerOne, PlayerTwo);

                    TurnCount++;

                    if (TurnCount == 9) { GameOver = true; }
                }

                Logic.DisplayGameResult(GameChecker, GameBoredLocation);

                UpdateScores();
                RenderScore();
                CheckIfScoreLimitIsReached();
                
                if(!LoopGame){ RenderGameOver();  }
                
                Input = ConsoleKey.UpArrow;
                  while(Input != ConsoleKey.Enter)
                  { Input = Move.GetInput(); }
        
                if (LoopGame)
                {
                  GameOver = false;
                  PlayerLocationIndex = 4;
                  TurnCount = 0;
                }
                
            } while (LoopGame);

            Console.Clear(); 
           


        }
        private void PlayerIndicatorsSetUp()
        { Render.RenderSingleGamePlayerIndicatorsSetUp(GameLocation,CurrentPlayer); }
        private void HighlightPlayer(PlayerClass CurrentPlayers)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(GameLocation[0]+8, GameLocation[1]+1);
            if(CurrentPlayers.PlayerIndex == 1) { Console.ForegroundColor = ConsoleColor.DarkBlue; }
            Console.WriteLine("X");
            if (CurrentPlayers.PlayerIndex == 1) { Console.ForegroundColor = ConsoleColor.DarkGray; }

            if (CurrentPlayers.PlayerIndex == -1) { Console.ForegroundColor = ConsoleColor.DarkCyan; }
            Console.SetCursorPosition(GameLocation[0]+19, GameLocation[1]+1);
            Console.WriteLine("O");
            if (CurrentPlayers.PlayerIndex == -1) { Console.ForegroundColor = ConsoleColor.DarkGray; }

        }
        private void OpitinalScoreSetUp()
        {
            if (LoopGame)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.SetCursorPosition(GameLocation[0], GameLocation[1] + 1);
                Console.WriteLine("Score");

                Console.SetCursorPosition(GameLocation[0] + 11, GameLocation[1] + 1);
                Console.WriteLine("Score");

                Console.ResetColor();
            }

        }
        private void RenderScore()
        {
         if(LoopGame)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.SetCursorPosition(GameLocation[0] +5 , GameLocation[1] + 2);
                Console.WriteLine(PlayerOneScore);

                Console.SetCursorPosition(GameLocation[0] + 16 , GameLocation[1] + 2);
                Console.WriteLine(PlayerTwoScore);

                Console.ResetColor();
            }
        }
        private void UpdateScores()
        {
            if (GameChecker.Contains(3))  { PlayerOneScore++; }
            if (GameChecker.Contains(-3)) { PlayerTwoScore++; }
        }
        private void CheckIfScoreLimitIsReached()
        {
            if (PlayerOneScore == ScoreLimit) { LoopGame = false; }
            else if (PlayerTwoScore == ScoreLimit) { LoopGame = false; }
        }
        private void RenderGameOver()
        {
           
                //Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.SetCursorPosition(GameLocation[0] + 6, GameLocation[1] + 5);
                Console.WriteLine("Game Over");

                Console.SetCursorPosition(GameLocation[0] + 6, GameLocation[1] + 11);
                Console.WriteLine("Game Over");

            // Console.ResetColor();

        }
    }
}
