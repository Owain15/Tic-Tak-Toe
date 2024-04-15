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
        CCPData CCP;
        

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

        public SingleGameTTT(int[] gameLocation, bool loopGame, int scoreLimit,PlayerClass playerOne, PlayerClass playerTwo )
        {
          
            GameLocation = gameLocation;

            

            PlayerOne = playerOne;
            PlayerTwo = playerTwo;

            

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
                        Render.CCPAnimation(GameLocation,GameBoredLocation,GameBoredIndex,CurrentPlayer);
                        
                        CCP = new CCPData(GameBoredIndex,CurrentPlayer);
                        int CCPMoveIndex = CCP.NextMove;

                        GameBoredIndex[CCPMoveIndex]=CurrentPlayer.PlayerIndex;
                        // May Be Redundent
                        Render.RenderGameBored(GameBoredLocation,GameBoredIndex);

                        if (Console.KeyAvailable)
                            {
                              ConsoleKey InputCheck;
                              ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                              InputCheck = keyInfo.Key;
                            
                                if (InputCheck == ConsoleKey.Escape)
                                {
                                    bool EndCurrentGame = ExitCurrentGame();
                                    if (EndCurrentGame) { MoveMade = true; TurnCount = 10; ScoreLimit = 0; }
                                    Render.RenderGameBored(GameBoredLocation, GameBoredIndex);
                                }
                        }

                        Thread.Sleep(500);
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
                        else 
                            { 
                                PlayerLocationIndex = Move.GetNextPlayerLocationIndex(PlayerLocationIndex, Input);

                                if(Input == ConsoleKey.Escape) 
                                {
                                    bool EndCurrentGame = ExitCurrentGame();
                                    if (EndCurrentGame) { MoveMade = true; TurnCount = 10; ScoreLimit = 0; } 
                                    Render.RenderGameBored(GameBoredLocation, GameBoredIndex);
                                }
                                
                            }

                    }
                    
                        MoveMade = false;

                    }

                    GameChecker = Logic.SetWinChecker(GameBoredIndex, GameChecker);
                    GameOver = Logic.EvaluateGame(GameBoredIndex, GameChecker);

                    CurrentPlayer = Logic.SwitchPlayer(CurrentPlayer, PlayerOne, PlayerTwo);

                    TurnCount++;

                    if (TurnCount >= 9) { GameOver = true; }
                    
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
        private bool ExitCurrentGame()
        {
            ClearGameBored();

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(GameBoredLocation[0]-4, GameBoredLocation[1]+3);
            Console.WriteLine("Exit Current Game?");

            

            ConsoleKey Input = ConsoleKey.UpArrow;
            bool QuitGame = false;

            while(Input != ConsoleKey.Enter) 
            {
                if (QuitGame) { Console.ForegroundColor = ConsoleColor.Green; }
                Console.SetCursorPosition(GameBoredLocation[0], GameBoredLocation[1] + 5);
                Console.WriteLine("Yes");
                if (QuitGame) { Console.ForegroundColor = ConsoleColor.DarkGray; }

                Console.SetCursorPosition(GameBoredLocation[0] + 4, GameBoredLocation[1] + 5);
                Console.WriteLine("Or");

                if (!QuitGame) { Console.ForegroundColor = ConsoleColor.Green; }
                Console.SetCursorPosition(GameBoredLocation[0] + 7 , GameBoredLocation[1] + 5);
                Console.WriteLine("No");
                if (!QuitGame) { Console.ForegroundColor = ConsoleColor.DarkGray; }

                Input = Move.GetInput();
                
                if (Input == ConsoleKey.LeftArrow) { QuitGame = true; }
                if (Input == ConsoleKey.RightArrow) { QuitGame = false; }
            }

            ClearGameBored();
           
            Console.ResetColor();


            return QuitGame;
        }
        private void ClearGameBored()
        {
            string ClearLine = "                   ";

            for (int i = GameBoredLocation[1]; i <= GameBoredLocation[1] + 8; i++)
            {
                Console.SetCursorPosition(GameBoredLocation[0] - 5, i);
                Console.WriteLine(ClearLine);
            }
        }
        private void PlayerEndGameCheck(ConsoleKey Input)
        {

        }
    }
}
