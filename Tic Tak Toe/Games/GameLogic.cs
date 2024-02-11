using System.ComponentModel.Design;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using Tic_Tak_Toe.Game;
using Tic_Tak_Toe.Builders;
using Tic_Tak_Toe.Resources;

namespace Tic_Tak_Toe.Game
{
    internal class GameLogicClass
    {
        

        public int[,] GridReff = new int[,]
        { { 56, 4 },{ 59, 4 },{ 62, 4 },
          { 56, 7 },{ 59, 7 },{ 62, 7 },
          { 56, 10},{ 59, 10},{ 62, 10}
        };
        private int[] gameChecker = new int[8];
        public int[] GameChecker { get { return gameChecker; } set { gameChecker = value; } }
        private int[] gameBoredIndex = new int[9] { 1, 0, 0, 0, 0, 0, 0, 0, 1 };
        public int[] GameBoredIndex
        {
            get { return gameBoredIndex; }
            set { gameBoredIndex = value; }
        }

        public void RunSuperTT(PlayerClass PlayerOne, PlayerClass PlayerTwo)
        {
            SuperTicTakToe.SuperTicTakToe SuperTT = new SuperTicTakToe.SuperTicTakToe(PlayerOne,PlayerTwo);
            SuperTT.Run();
        }

        public int Game(PlayerClass PLayerOne, PlayerClass PLayerTwo, int[] GamePositionReff, bool LoopGame)
        {
            PlayerClass CurrentPlayer = PLayerOne;

            PageClass Window = new PageClass();
            GridClass Bored = new GridClass();
            NavigationGame CurrentMove = new NavigationGame();
            RenderClass Screen = new RenderClass(CurrentPlayer, gameBoredIndex, GamePositionReff);
            int TurnCounter = 0;
            CurrentPlayer.PlayerLocationIndex = 4;

            int Winner = GameLoop();

            
            return Winner;

            int GameLoop()
            {

                ResetGameChecker(GameChecker);
                ResetGameBoredIndex(GameBoredIndex);
                bool GameEvaluation = false;
                while (GameEvaluation == false)
                {
                    Screen.RenderScreen();
                    Screen.RenderPlayerScores(PLayerOne.PlayerScore, PLayerTwo.PlayerScore);
                    Screen.RenderGameInstructions();

                    Screen.RenderPlayer(CurrentMove.GridReffBuilder(GridReff, CurrentPlayer.PlayerLocationIndex),
                        CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex, GameBoredIndex));
                    GameEvaluation = RunPlayerTurn();
                    CurrentPlayer = SwitchPlayer(CurrentPlayer ,PLayerOne,PLayerTwo);

                    if (TurnCounter == 8)
                    { 
                       // Check for winner
                       
                        GameIsADraw();

                        int Winner = 0;  return Winner; 
                    }

                    TurnCounter++;

                }
                bool WinningPlayer = GetWinningPlayer(GameChecker);
                ScoreTheWin(WinningPlayer);

                if (WinningPlayer == true)
                { PlayerXWins(); int Winner = 1; return Winner; }

                else
                { PlayerOWins(); int Winner = -1; return Winner; }

            }

            bool RunPlayerTurn()
            {
                bool IsMoveFreeToSet = false;
                while (IsMoveFreeToSet == false)
                {
                    CurrentPlayer.PlayerLocationIndex = CurrentMove.MovePlayerLoop(CurrentPlayer, PLayerOne, PLayerTwo, GameBoredIndex, GridReff,
                    GamePositionReff, LoopGame );
                    IsMoveFreeToSet = CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex, GameBoredIndex);
                }
                SetToBored(CurrentPlayer.PlayerIndex, CurrentPlayer.PlayerLocationIndex);
                bool GameEvaluation = EvaluateGame(gameBoredIndex, gameChecker);

                return GameEvaluation;

            }

            void SetToBored(int PlayerIndex, int PlayerLocationIndex)
            {
                if (CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex, GameBoredIndex))
                { GameBoredIndex.SetValue(PlayerIndex, PlayerLocationIndex); }

            }
            void ScoreTheWin(bool WinningPlayer)
            {
                if (WinningPlayer == true) { PLayerOne.PlayerScore ++; }
                else { PLayerTwo.PlayerScore++; }

            }
            ConsoleKey GetInput()
            {

                ConsoleKey Input;

                do
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    Input = keyInfo.Key;
                } while (Console.KeyAvailable);
                return Input;
            }
            void PlayerXWins()
            {
                Screen.RenderPlayerXWins(GamePositionReff);
                Console.SetCursorPosition(54, 14);
                Console.WriteLine("Player X Wins!");
                ConsoleKey NextRound = GetInput();
                while (NextRound != ConsoleKey.Enter) ;

                TurnCounter = 0;
                if (LoopGame == true) { GameLoop(); }
            }
            void PlayerOWins()
            {
                Screen.RenderPlayerOWins(GamePositionReff);
                Console.SetCursorPosition(54, 14);
                Console.WriteLine("Player O Wins!");
                ConsoleKey NextRound = GetInput();
                while (NextRound != ConsoleKey.Enter) ;

                TurnCounter = 0;
                if (LoopGame == true) { GameLoop(); }
            }
            void GameIsADraw()
            {
                Screen.RenderItsADraw(GamePositionReff);
                Console.SetCursorPosition(54, 14);
                Console.WriteLine("! Its A Draw !");

                ConsoleKey ReplayRound = GetInput();
                while (ReplayRound != ConsoleKey.Enter) ;

                TurnCounter = 0;
                if (LoopGame == true) { GameLoop(); }
            }
        }
        public int GameNoPage(PlayerClass PLayerOne, PlayerClass PLayerTwo, int[] GamePositionReff, bool LoopGame)
        {
            PlayerClass CurrentPlayer = PLayerOne;

            PageClass Window = new PageClass();
            GridClass Bored = new GridClass();
            NavigationGame CurrentMove = new NavigationGame();
            RenderClass Screen = new RenderClass(CurrentPlayer, gameBoredIndex, GamePositionReff);
            int TurnCounter = 0;
            CurrentPlayer.PlayerLocationIndex = 4;

            int Winner = GameLoop();


            return Winner;

            int GameLoop()
            {

                ResetGameChecker(GameChecker);
                ResetGameBoredIndex(GameBoredIndex);
                bool GameEvaluation = false;
                while (GameEvaluation == false)
                {
                    Screen.RenderGameBored();

                    Screen.RenderPlayer(CurrentMove.GridReffBuilder(GridReff, CurrentPlayer.PlayerLocationIndex),
                        CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex, GameBoredIndex));
                    GameEvaluation = RunPlayerTurn();
                    CurrentPlayer = SwitchPlayer(CurrentPlayer, PLayerOne, PLayerTwo);

                    if (TurnCounter == 8)
                    {
                        // Check for winner

                        GameIsADraw();

                        int Winner = 0; return Winner;
                    }

                    TurnCounter++;

                }
                bool WinningPlayer = GetWinningPlayer(GameChecker);
                ScoreTheWin(WinningPlayer);

                if (WinningPlayer == true)
                { PlayerXWins(); int Winner = 1; return Winner; }

                else
                { PlayerOWins(); int Winner = -1; return Winner; }

            }

            bool RunPlayerTurn()
            {
                bool IsMoveFreeToSet = false;
                while (IsMoveFreeToSet == false)
                {
                    CurrentPlayer.PlayerLocationIndex = CurrentMove.MovePlayerLoop(CurrentPlayer, PLayerOne, PLayerTwo, GameBoredIndex, GridReff,
                    GamePositionReff, LoopGame);
                    IsMoveFreeToSet = CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex, GameBoredIndex);
                }
                SetToBored(CurrentPlayer.PlayerIndex, CurrentPlayer.PlayerLocationIndex);
                bool GameEvaluation = EvaluateGame(gameBoredIndex, gameChecker);

                return GameEvaluation;

            }

            void SetToBored(int PlayerIndex, int PlayerLocationIndex)
            {
                if (CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex, GameBoredIndex))
                { GameBoredIndex.SetValue(PlayerIndex, PlayerLocationIndex); }

            }
            void ScoreTheWin(bool WinningPlayer)
            {
                if (WinningPlayer == true) { PLayerOne.PlayerScore++; }
                else { PLayerTwo.PlayerScore++; }

            }
            ConsoleKey GetInput()
            {

                ConsoleKey Input;

                do
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    Input = keyInfo.Key;
                } while (Console.KeyAvailable);
                return Input;
            }
            void PlayerXWins()
            {
                Screen.RenderPlayerXWins(GamePositionReff);
                Console.SetCursorPosition(54, 14);
                Console.WriteLine("Player X Wins!");
                ConsoleKey NextRound = GetInput();
                while (NextRound != ConsoleKey.Enter) ;

                TurnCounter = 0;
                if (LoopGame == true) { GameLoop(); }
            }
            void PlayerOWins()
            {
                Screen.RenderPlayerOWins(GamePositionReff);
                Console.SetCursorPosition(54, 14);
                Console.WriteLine("Player O Wins!");
                ConsoleKey NextRound = GetInput();
                while (NextRound != ConsoleKey.Enter) ;

                TurnCounter = 0;
                if (LoopGame == true) { GameLoop(); }
            }
            void GameIsADraw()
            {
                Screen.RenderItsADraw(GamePositionReff);
                Console.SetCursorPosition(54, 14);
                Console.WriteLine("! Its A Draw !");

                ConsoleKey ReplayRound = GetInput();
                while (ReplayRound != ConsoleKey.Enter) ;

                TurnCounter = 0;
                if (LoopGame == true) { GameLoop(); }
            }
        }

        public PlayerClass SwitchPlayer(PlayerClass CurrentPlayer, PlayerClass PlayerOne, PlayerClass PlayerTwo)
        {

            if (CurrentPlayer.PlayerIndex == 1)
            { PlayerTwo.PlayerLocationIndex = CurrentPlayer.PlayerLocationIndex; return PlayerTwo; }
            else { PlayerOne.PlayerLocationIndex = CurrentPlayer.PlayerLocationIndex; return PlayerOne; }
        }
        public bool GetWinningPlayer(int[] gameChecker)
        {

            int[] GameChecker = gameChecker;
            foreach (int Game in GameChecker)
            {
                if (Game > 2) { return true; }
            }

            return false;
        }
        public bool EvaluateGame(int[] gameBoredIndex, int[] gameChecker)
        {
            SetWinChecker(gameBoredIndex, gameChecker);
            bool GameEvaluation = CheckWinChecker(gameChecker);
            return GameEvaluation;
        }
        public void SetWinChecker(int[] gameBoredIndex, int[] gameChecker)
        {
            int[] GameBoredIndex = gameBoredIndex;
            int[] GameChecker = gameChecker;

            GameChecker.SetValue(GameBoredIndex[0] + GameBoredIndex[1] + GameBoredIndex[2], 0);
            GameChecker.SetValue(GameBoredIndex[3] + GameBoredIndex[4] + GameBoredIndex[5], 1);
            GameChecker.SetValue(GameBoredIndex[6] + GameBoredIndex[7] + GameBoredIndex[8], 2);
            GameChecker.SetValue(GameBoredIndex[0] + GameBoredIndex[3] + GameBoredIndex[6], 3);
            GameChecker.SetValue(GameBoredIndex[1] + GameBoredIndex[4] + GameBoredIndex[7], 4);
            GameChecker.SetValue(GameBoredIndex[2] + GameBoredIndex[5] + GameBoredIndex[8], 5);
            GameChecker.SetValue(GameBoredIndex[0] + GameBoredIndex[4] + GameBoredIndex[8], 6);
            GameChecker.SetValue(GameBoredIndex[6] + GameBoredIndex[4] + GameBoredIndex[2], 7);

        }
        public bool CheckWinChecker(int[] gameChecker)
        {
            int[] GameChecker = gameChecker;
            foreach (int Game in GameChecker)
            { if (Game > 2) { return true; } if (Game < -2) { return true; } }
            return false;
        }
        public string[,] GetTile(int TileIndex)
        {
            Tiles ArrayReff = new Tiles();

            switch (TileIndex)
            {
                case 0:
                    return ArrayReff.Empty;

                case 1:
                    return ArrayReff.X;

                case -1:
                    return ArrayReff.O;
            }
            return ArrayReff.Empty;
        }
        void ResetGameBoredIndex(int[] gameBoredIndex)
        {
            int[] GameBoredIndex = gameBoredIndex;

            GameBoredIndex.SetValue(0, 0);
            GameBoredIndex.SetValue(0, 1);
            GameBoredIndex.SetValue(0, 2);
            GameBoredIndex.SetValue(0, 3);
            GameBoredIndex.SetValue(0, 4);
            GameBoredIndex.SetValue(0, 5);
            GameBoredIndex.SetValue(0, 6);
            GameBoredIndex.SetValue(0, 7);
            GameBoredIndex.SetValue(0, 8);
        }
        void ResetGameChecker(int[] gameChecker)
        {
            int[] GameChecker = gameChecker;

            GameChecker.SetValue(0, 0);
            GameChecker.SetValue(0, 1);
            GameChecker.SetValue(0, 2);
            GameChecker.SetValue(0, 3);
            GameChecker.SetValue(0, 4);
            GameChecker.SetValue(0, 5);
            GameChecker.SetValue(0, 6);
            GameChecker.SetValue(0, 7);

        }
        public bool CheckMoveIsFreeToSet(int CurrentPlayerLocationIndex, int[] gameBordIndex)
        {
            if (gameBoredIndex[CurrentPlayerLocationIndex] == 0) { return true; }
            else { return false; }
        }

    }




}
