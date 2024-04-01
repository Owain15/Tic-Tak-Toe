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
        int[] GameLocation;

        public GameLogicClass(int[] gameLocation)
        { GameLocation = gameLocation; }

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
            SuperTicTakToe.SuperTicTakToe SuperTT = new SuperTicTakToe.SuperTicTakToe(PlayerOne,PlayerTwo,GameLocation);
            SuperTT.Run();
        }

        //public int Game(PlayerClass PLayerOne, PlayerClass PLayerTwo, int[] GamePositionReff, bool LoopGame)
        //{
        //    PlayerClass CurrentPlayer = PLayerOne;

        //    PageClass Window = new PageClass();
        //    GridClass Bored = new GridClass();
        //    NavigationGame CurrentMove = new NavigationGame();
        //    RenderClass Screen = new RenderClass();
        //        //(CurrentPlayer, gameBoredIndex, GamePositionReff);
        //    int TurnCounter = 0;
        //    CurrentPlayer.PlayerLocationIndex = 4;

        //    int Winner = GameLoop();

            
        //    return Winner;

        //    int GameLoop()
        //    {

        //        ResetGameChecker(GameChecker);
        //        ResetGameBoredIndex(GameBoredIndex);
        //        bool GameEvaluation = false;
        //        while (GameEvaluation == false)
        //        {
        //            Screen.RenderScreen();
        //            Screen.RenderPlayerScores(PLayerOne.PlayerScore, PLayerTwo.PlayerScore);
        //            Screen.RenderGameInstructions();

        //            Screen.RenderPlayer(CurrentMove.GridReffBuilder(GridReff, CurrentPlayer.PlayerLocationIndex),
        //                CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex, GameBoredIndex),CurrentPlayer);
        //            GameEvaluation = RunPlayerTurn();
        //            CurrentPlayer = SwitchPlayer(CurrentPlayer ,PLayerOne,PLayerTwo);

        //            if (TurnCounter == 8)
        //            { 
        //               // Check for winner
                       
        //                GameIsADraw();

        //                int Winner = 0;  return Winner; 
        //            }

        //            TurnCounter++;

        //        }
        //        bool WinningPlayer = GetWinningPlayer(GameChecker);
        //        ScoreTheWin(WinningPlayer);

        //        if (WinningPlayer == true)
        //        { PlayerXWins(); int Winner = 1; return Winner; }

        //        else
        //        { PlayerOWins(); int Winner = -1; return Winner; }

        //    }

        //    bool RunPlayerTurn()
        //    {
        //        bool IsMoveFreeToSet = false;
        //        while (IsMoveFreeToSet == false)
        //        {
        //            CurrentPlayer.PlayerLocationIndex = CurrentMove.MovePlayerLoop(CurrentPlayer, PLayerOne, PLayerTwo, GameBoredIndex, GridReff,
        //            GamePositionReff, LoopGame );
        //            IsMoveFreeToSet = CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex, GameBoredIndex);
        //        }
        //        SetToBored(CurrentPlayer.PlayerIndex, CurrentPlayer.PlayerLocationIndex);
        //        bool GameEvaluation = EvaluateGame(gameBoredIndex, gameChecker);

        //        return GameEvaluation;

        //    }

        //    void SetToBored(int PlayerIndex, int PlayerLocationIndex)
        //    {
        //        if (CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex, GameBoredIndex))
        //        { GameBoredIndex.SetValue(PlayerIndex, PlayerLocationIndex); }

        //    }
        //    void ScoreTheWin(bool WinningPlayer)
        //    {
        //        if (WinningPlayer == true) { PLayerOne.PlayerScore ++; }
        //        else { PLayerTwo.PlayerScore++; }

        //    }
        //    ConsoleKey GetInput()
        //    {

        //        ConsoleKey Input;

        //        do
        //        {
        //            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        //            Input = keyInfo.Key;
        //        } while (Console.KeyAvailable);
        //        return Input;
        //    }
        //    void PlayerXWins()
        //    {
        //        Screen.RenderPlayerXWins(GamePositionReff);
        //        Console.SetCursorPosition(54, 14);
        //        Console.WriteLine("Player X Wins!");
        //        ConsoleKey NextRound = GetInput();
        //        while (NextRound != ConsoleKey.Enter) ;

        //        TurnCounter = 0;
        //        if (LoopGame == true) { GameLoop(); }
        //    }
        //    void PlayerOWins()
        //    {
        //        Screen.RenderPlayerOWins(GamePositionReff);
        //        Console.SetCursorPosition(54, 14);
        //        Console.WriteLine("Player O Wins!");
        //        ConsoleKey NextRound = GetInput();
        //        while (NextRound != ConsoleKey.Enter) ;

        //        TurnCounter = 0;
        //        if (LoopGame == true) { GameLoop(); }
        //    }
        //    void GameIsADraw()
        //    {
        //        Screen.RenderItsADraw(GamePositionReff);
        //        Console.SetCursorPosition(54, 14);
        //        Console.WriteLine("! Its A Draw !");

        //        ConsoleKey ReplayRound = GetInput();
        //        while (ReplayRound != ConsoleKey.Enter) ;

        //        TurnCounter = 0;
        //        if (LoopGame == true) { GameLoop(); }
        //    }
        //}
        public int GameNoPage(PlayerClass PLayerOne, PlayerClass PLayerTwo, int[] GamePositionReff, bool LoopGame)
        {
            PlayerClass CurrentPlayer = PLayerOne;

            PageClass Window = new PageClass(GameLocation);
            GridClass Bored = new GridClass(GameLocation);
            NavigationGame CurrentMove = new NavigationGame(GameLocation);
            RenderClass Screen = new RenderClass(GameLocation);
                //(CurrentPlayer, gameBoredIndex, GamePositionReff);
            int TurnCounter = 0;
            CurrentPlayer.PlayerLocationIndex = 4;

            int Winner = GameLoop();


            return Winner;

            int GameLoop()
            {

                ResetGameChecker(GameChecker);
                ResetGameBored(GameBoredIndex);
                bool GameEvaluation = false;
                while (GameEvaluation == false)
                {
                    Screen.RenderGameBored(GamePositionReff,GameBoredIndex);

                    Screen.RenderPlayer(CurrentMove.GridReffBuilder(GridReff, CurrentPlayer.PlayerLocationIndex),
                        CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex, GameBoredIndex),CurrentPlayer);
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
        public int[] SetWinChecker(int[] gameBoredIndex, int[] gameChecker)
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

            return GameChecker;

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
        public int[] ResetGameBored(int[] GameBored)
        {

            GameBored.SetValue(0, 0);
            GameBored.SetValue(0, 1);
            GameBored.SetValue(0, 2);
            GameBored.SetValue(0, 3);
            GameBored.SetValue(0, 4);
            GameBored.SetValue(0, 5);
            GameBored.SetValue(0, 6);
            GameBored.SetValue(0, 7);
            GameBored.SetValue(0, 8);

            return GameBored;
        }
        public int[] ResetGameChecker(int[] GameChecker)
        {

            GameChecker.SetValue(0, 0);
            GameChecker.SetValue(0, 1);
            GameChecker.SetValue(0, 2);
            GameChecker.SetValue(0, 3);
            GameChecker.SetValue(0, 4);
            GameChecker.SetValue(0, 5);
            GameChecker.SetValue(0, 6);
            GameChecker.SetValue(0, 7);

            return GameChecker;

        }
        
        public bool CheckMoveIsFreeToSet(int CurrentPlayerLocationIndex, int[] gameBoredIndex)
        {
            if (gameBoredIndex[CurrentPlayerLocationIndex] == 0) { return true; }
            else { return false; }
        }
        public int[] SetToBored(int PlayerIndex, int PlayerLocationIndex, int[] gameBoredIndex)
        {

            gameBoredIndex.SetValue(PlayerIndex, PlayerLocationIndex);
            return gameBoredIndex;

        }
        public void DisplayGameResult(int[] GameChecker, int[] GamePositionReff)
        {

            bool PlayerOneWins = GameChecker.Contains(3);
            bool PLayerTwoWins = GameChecker.Contains(-3);

            if (PlayerOneWins) { PlayerXWins(GamePositionReff); }
            else if (PLayerTwoWins) { PlayerOWins(GamePositionReff); }
            else { GameIsADraw(GamePositionReff); }

        }
        public void PlayerXWins(int[] gamePositionReff)
        {
            int[] NewGameReff = new int[2] { gamePositionReff[0] - 1, gamePositionReff[1] };

            Builders.RenderClass Screen = new RenderClass(GameLocation);

            Screen.RenderPlayerXWins(NewGameReff);
            Console.SetCursorPosition(NewGameReff[0]+-1, NewGameReff[1]+ 10);
            Console.WriteLine("Player X Wins!");
        }
        public void PlayerOWins(int[] gamePositionReff)
        {
            int[] NewGameReff = new int[2] { gamePositionReff[0] - 1, gamePositionReff[1] };

            Builders.RenderClass Screen = new RenderClass(GameLocation);

            Screen.RenderPlayerOWins(NewGameReff);
            Console.SetCursorPosition(NewGameReff[0] + -1, NewGameReff[1] + 10);
            Console.WriteLine("Player O Wins!");
        }
        public void GameIsADraw(int[] gamePositionReff)
        {
            int[] NewGameReff = new int[2] { gamePositionReff[0] - 1, gamePositionReff[1] };

            Builders.RenderClass Screen = new RenderClass(GameLocation);

            Screen.RenderItsADraw(NewGameReff);
            Console.SetCursorPosition(NewGameReff[0] + -1, NewGameReff[1] + 10);
            Console.WriteLine("! Its A Draw !");
        }
        public void ExtraInputChecks(ConsoleKey Input)
        {
            switch(Input)
            {
                case ConsoleKey.Escape: { }break;

            }
        }

    }




}
