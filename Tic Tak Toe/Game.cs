using System.ComponentModel.Design;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace Tic_Tak_Toe
{
    internal class GameClass
    {
        public int[,] GridReff = new int[,] { { 56, 4 }, { 59, 4 }, { 62, 4 }, { 56, 7 }, { 59, 7 }, { 62, 7 }, { 56, 10 }, { 59, 10 }, { 62, 10 } };
        // Grid Reff : T1=[0], T2=[1],T3=[2],T4=[3],T5=[4],T6=[5],T7=[6],T8=[7],T9=[8],

        //public int[] GridX = new int[3] { 56, 59, 62 };
        //public int[] GridY = new int[3] { 4, 7, 10 };

        //int[] Grid = [T1,T2,T3,T4,T5,T6,T7,T8,T9];

        public int[] T1 = [56, 4];
        public int[] T2 = [59, 4];
        public int[] T3 = [62, 4];

        public int[] T4 = [56, 7];
        public int[] T5 = [59, 7];
        public int[] T6 = [62, 7];

        public int[] T7 = [56, 10];
        public int[] T8 = [59, 10];
        public int[] T9 = [62, 10];
        
        //private int playerXScore = 0;
        //public int PlayerXScore { get { return playerXScore; } set { playerXScore = value; } }
        //private int playerOScore = 0;
        //public int PlayerOScore { get { return playerOScore; } set { playerOScore = value; } }

        private int[] gameChecker = new int[8] ;
        public int[] GameChecker { get { return gameChecker; } set { gameChecker = value; } }

        private int[] gameBoredIndex = new int[9] {1,0,0,0,0,0,0,0,1};
        public int[] GameBoredIndex
        {
            get { return gameBoredIndex; }
            set { gameBoredIndex = value; }
        }
        public void Game()
        {

            PageClass Window = new PageClass();
            GridClass Bored = new GridClass();
            Navigation CurrentMove = new Navigation();
            PlayerClass CurrentPlayer = new PlayerClass(1);
            RenderClass Screen = new RenderClass(CurrentPlayer, gameBoredIndex);
            int TurnCounter = 0;
           
            GameLoop();

           
            void GameLoop()
            {

                ResetGameChecker(GameChecker);
                ResetGameBoredIndex(GameBoredIndex);
                bool GameEvaluation = false;
                while (GameEvaluation == false) 
                {
                    Screen.RenderScreen();
                    Screen.RenderPlayerScores( CurrentPlayer.PlayerXScore,CurrentPlayer.PlayerOScore );
                    Screen.RenderGameInstructions();

                    Screen.RenderPlayer(GetPlayerLocationReff(CurrentPlayer.PlayerLocationIndex),
                        CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex,GameBoredIndex));
                    GameEvaluation = RunPlayerTurn();
                    CurrentPlayer.PlayerIndex = CurrentPlayer.SwitchPlayer(CurrentPlayer.PlayerIndex);

                    if (TurnCounter == 8)
                    {
                       
                        switch (EvaluateGameForInt(GameBoredIndex,GameChecker))
                        {
                            case 1:
                                {
                                    CurrentPlayer.PlayerXScore = +1;
                                    PlayerXWins();
                                }
                                break;
                            case -1:
                                {
                                    CurrentPlayer.PlayerOScore = +1;
                                    PlayerOWins();
                                }
                                break;
                            case 0:
                                { GameIsADraw(); }
                                break;


                        }
                        
                    }

                    TurnCounter++;

                }
                bool WinningPlayer = GetWinningPlayer(GameChecker);
                ScoreTheWin(WinningPlayer);

                if (WinningPlayer == true)
                { PlayerXWins(); }

                else
                { PlayerOWins(); }

            }

            bool RunPlayerTurn()
            {
                bool IsMoveFreeToSet = false;
                while( IsMoveFreeToSet == false)
                {
                    CurrentPlayer.PlayerLocationIndex = CurrentMove.MovePlayerLoop(CurrentPlayer, GameBoredIndex);
                    IsMoveFreeToSet = CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex, GameBoredIndex);
                }
                SetToBored(CurrentPlayer.PlayerIndex, CurrentPlayer.PlayerLocationIndex);
                bool GameEvaluation = EvaluateGame(gameBoredIndex,gameChecker);
                
                return GameEvaluation;

            }

            void SetToBored(int PlayerIndex, int PlayerLocationIndex)
            {
                if (CheckMoveIsFreeToSet(CurrentPlayer.PlayerLocationIndex, GameBoredIndex))
                { GameBoredIndex.SetValue(PlayerIndex, PlayerLocationIndex); }
              
            }

            void ScoreTheWin(bool WinningPlayer)
            {
                if (WinningPlayer == true) {CurrentPlayer.PlayerXScore ++; }
                else { CurrentPlayer.PlayerOScore ++; }

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
                Screen.RenderPlayerXWins();
                Console.SetCursorPosition(54, 14);
                Console.WriteLine("Player X Wins!");
                ConsoleKey NextRound = GetInput();
                while (NextRound != ConsoleKey.Enter) ;

                TurnCounter = 0;
                GameLoop();
            }
            void PlayerOWins()
            {
                Screen.RenderPlayerOWins();
                Console.SetCursorPosition(54, 14);
                Console.WriteLine("Player O Wins!");
                ConsoleKey NextRound = GetInput();
                while (NextRound != ConsoleKey.Enter) ;

                TurnCounter = 0;
                GameLoop();
            }
            void GameIsADraw()
            {
                Screen.RenderItsADraw();
                Console.SetCursorPosition(54, 14);
                Console.WriteLine("! Its A Draw !");

                ConsoleKey ReplayRound = GetInput();
                while (ReplayRound != ConsoleKey.Enter) ;

                TurnCounter = 0;
                GameLoop();
            }
        }

        public int EvaluateGameForInt(int[] gameBoredIndex, int[] gameChecker)
        {
            SetWinChecker(gameBoredIndex, gameChecker);
            int GameWinningInt = CheckWinCheckerForInt(gameChecker);
            return GameWinningInt;
        }
        public int CheckWinCheckerForInt(int[] gameChecker)
        {
            int[] GameChecker = gameChecker;
            foreach (int Game in GameChecker)
            {
                if (Game > 2) { return 1; }
                if (Game < -2) { return -1; }
               
            }
            return 0;
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
        public bool EvaluateGame( int[] gameBoredIndex, int[]gameChecker)
        {
            SetWinChecker( gameBoredIndex, gameChecker);
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
            {
                if (Game > 2) { return true; }
                if (Game < -2) { return true; }
                //else { return false; }
            }
            return false;
        }

        public string[,] GetTile(int TileIndex)
        {
            ArrayStore Tile = new ArrayStore();

            switch (TileIndex)
            {
                case 0:
                    return Tile.TileEmpty();

                case 1:
                    return Tile.TileX();

                case -1:
                    return Tile.TileO();
            }
            return Tile.TileEmpty();
        }

        public int[] GetPlayerLocationReff(int PlayerLocationIndex)
        {
            switch (PlayerLocationIndex) 
            {
                //link to int[] Grid[], instead ofT values.

                case 0: return T1;
                case 1: return T2;
                case 2: return T3;
                case 3: return T4;
                case 4: return T5;
                case 5: return T6;
                case 6: return T7;
                case 7: return T8;
                case 8: return T9;
            }
            return T5;
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
        // Build A Universil ArrayReset();
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

    internal class PlayerClass
    {
        public int PlayerIndex;
        public int PlayerLocationIndex;

        public int PlayerXScore = 0;
        public int PlayerOScore = 0;
        
        public PlayerClass(int TileIndex)
        {
            PlayerIndex = TileIndex;
            PlayerLocationIndex = 4;
            

        }

        public int SwitchPlayer(int PlayerIndex)
        {

            if (PlayerIndex == 1)
            {return PlayerIndex = -1; }
            else { return PlayerIndex = 1; }


        }

        public void Draw(int PlayerIndex, int[] PlayerLocationReff)
        {
            int playerIndex = PlayerIndex;
            GameClass TileRef = new GameClass();
            string[,] CurrentArray = TileRef.GetTile(playerIndex);
            int Rows = CurrentArray.GetLength(0);
            int Columns = CurrentArray.GetLength(1);

            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    string pixle = CurrentArray[y, x];
                    Console.SetCursorPosition(x + PlayerLocationReff[0], y + PlayerLocationReff[1]);
                    Console.WriteLine(pixle);

                }

            }
        }  
        public void DrawError(int PlayerIndex, int[] PlayerLocationReff)
            {
                int playerIndex = PlayerIndex;
                GameClass TileRef = new GameClass();
                string[,] CurrentArray = TileRef.GetTile(playerIndex);
                int Rows = CurrentArray.GetLength(0);
                int Columns = CurrentArray.GetLength(1);
                int LoopCount = 0;
                for (int y = 0; y < Rows; y++)
                {
                    for (int x = 0; x < Columns; x++)
                    {
                        string pixle = CurrentArray[y, x];
                        Console.SetCursorPosition(x + PlayerLocationReff[0], y + PlayerLocationReff[1]);
                        Console.WriteLine(pixle);

                        if (LoopCount == 4)
                        {
                            Console.SetCursorPosition(x + PlayerLocationReff[0], y + PlayerLocationReff[1]);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(pixle);
                            Console.ResetColor();
                        }
                        LoopCount++;
                    }

                }
            }

    }

    internal class Navigation
    {

        public int GetNextPlayerLocationIndexSwitch(int PlayerLocation)
        {
            GameClass Location = new GameClass();

            ConsoleKey Direction;

            ConsoleKeyInfo KeyPressed = Console.ReadKey(true);
            Direction = KeyPressed.Key;

            switch (PlayerLocation)
            {
                case 0:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.RightArrow):
                                {
                                    PlayerLocation = 1;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.DownArrow):
                                {
                                    PlayerLocation = 3;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 1:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.LeftArrow):
                                {
                                    PlayerLocation = 0;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.RightArrow):
                                {
                                    PlayerLocation = 2;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.DownArrow):
                                {
                                    PlayerLocation = 4;
                                    return PlayerLocation;
                                }

                        }
                        return PlayerLocation;
                    }
                case 2:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.LeftArrow):
                                {
                                    PlayerLocation = 1;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.DownArrow):
                                {
                                    PlayerLocation = 5;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 3:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.RightArrow):
                                {
                                    PlayerLocation = 4;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.DownArrow):
                                {
                                    PlayerLocation = 6;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.UpArrow):
                                {
                                    PlayerLocation = 0;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 4:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.RightArrow):
                                {
                                    PlayerLocation = 3;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.LeftArrow):
                                {
                                    PlayerLocation = 5;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.UpArrow):
                                {
                                    PlayerLocation = 1;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.DownArrow):
                                {
                                    PlayerLocation = 7;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 5:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.LeftArrow):
                                {
                                    PlayerLocation = 4;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.UpArrow):
                                {
                                    PlayerLocation = 2;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 6:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.RightArrow):
                                {
                                    PlayerLocation = 7;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.UpArrow):
                                {
                                    PlayerLocation = 3;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 7:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.RightArrow):
                                {
                                    PlayerLocation = 8;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.LeftArrow):
                                {
                                    PlayerLocation = 6;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.UpArrow):
                                {
                                    PlayerLocation = 4;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 8:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.LeftArrow):
                                {
                                    PlayerLocation = 7;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.UpArrow):
                                {
                                    PlayerLocation = 5;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
            }
            return PlayerLocation;
            // replace with math left right +- 1, up down +- 3. logic to keep moves in the grid.

        }

        public int GetNextPlayerLocationIndex(int PlayerLocationIndex, ConsoleKey Move)
        {

            ConsoleKey Direction = Move;
            int NextPlayerLocationIndex = PlayerLocationIndex;


            switch (Direction)
                {
                    case ConsoleKey.UpArrow:
                    {
                        NextPlayerLocationIndex = PlayerLocationIndex - 3;

                        return NextPlayerLocationIndex;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        NextPlayerLocationIndex = PlayerLocationIndex + 3;

                        return NextPlayerLocationIndex;
                    }
                    case ConsoleKey.LeftArrow:
                    {
                        NextPlayerLocationIndex = PlayerLocationIndex - 1;

                        return NextPlayerLocationIndex;
                    }
                    case ConsoleKey.RightArrow:
                    {
                        NextPlayerLocationIndex = PlayerLocationIndex + 1;

                        return NextPlayerLocationIndex;
                    }
                   

            }
                return PlayerLocationIndex;
             
        }

        public bool CheckMoveIsInBounds(int PreposedPlayerLocationIndex) 
        {
            if (PreposedPlayerLocationIndex < 0) {return false;}
        
            if (PreposedPlayerLocationIndex > 8) {return false;}
            else {return true;}
        }

        public bool CheckMoveIsFreeToSet(int CurrentPlayerLocationIndex, int[] gameBordIndex)
        {
            int[] GameBoredIndex = gameBordIndex;
            if (GameBoredIndex[CurrentPlayerLocationIndex] == 0) { return true; }
            else { return false; }

        }

        public int isMoveInBounds(int PreposedPlayerLocationIndex, int InitialPlayerLocationIndex)
        {
            bool PlayerLocationIndex;
            PlayerLocationIndex = CheckMoveIsInBounds(PreposedPlayerLocationIndex);
            if (PlayerLocationIndex == true) { return PreposedPlayerLocationIndex; }
            else { return InitialPlayerLocationIndex; }
        }

        //public void IsMoveIsFreeToSet(int CurrentPlayerLocationIndex, int[] gameBordIndex)
        //{
        //    bool IsBoredIndexEmpty;
        //    IsBoredIndexEmpty = CheckMoveIsFreeToSet(CurrentPlayerLocationIndex, gameBordIndex);
        //    if (IsBoredIndexEmpty == true) { return; }
        //    else { return InitialPlayerLocationIndex; }
        //}
        private void ScoreResetCheck(ConsoleKey Move, PlayerClass Player)
        {
            if (Move == ConsoleKey.Escape)
            {
                Player.PlayerXScore = 0;
                Player.PlayerOScore = 0;

                GameClass ResetGame = new GameClass();
                ResetGame.Game();
            }
        }
        public int MovePlayerLoop(PlayerClass Player, int[] GameBordIndex)
        {
            int[] gameBordIndex = GameBordIndex;
            RenderClass Refesh = new RenderClass(Player, gameBordIndex);

            int CurrentPlayerLocationIndex = Player.PlayerLocationIndex;
            ConsoleKey Move = GetInput();
           
                while(Move != ConsoleKey.Enter)
                {
                    ScoreResetCheck(Move, Player);

                    int NextPlayerLocationIndex = GetNextPlayerLocationIndex(CurrentPlayerLocationIndex, Move);
                    CurrentPlayerLocationIndex = isMoveInBounds(NextPlayerLocationIndex, CurrentPlayerLocationIndex);

                    Refesh.RenderScreen();
                    Refesh.RenderPlayerScores(Player.PlayerXScore, Player.PlayerOScore);
                    Refesh.RenderGameInstructions();
                    Refesh.RenderPlayer(GetPlayerLocationReff(CurrentPlayerLocationIndex),
                        CheckMoveIsFreeToSet(CurrentPlayerLocationIndex, gameBordIndex));

                    Move = GetInput();
                }
             
            return CurrentPlayerLocationIndex;
            //int BackupLocationIndex = 4;
            //return BackupLocationIndex;
        }
        public int RunPlayerTurn(PlayerClass Player, int[] GameBordIndex)
        {
            int[] gameBordIndex = GameBordIndex;
            RenderClass Refesh = new RenderClass(Player, gameBordIndex);

            int CurrentPlayerLocationIndex = Player.PlayerLocationIndex;
            ConsoleKey Move = GetInput();
            bool SetMove = false;

            while (SetMove == false)
            {
                while (Move != ConsoleKey.Enter)
                {
                    if (Move == ConsoleKey.Escape)
                    {
                        Player.PlayerXScore = 0;
                        Player.PlayerOScore = 0;

                        //GameClass ResetGame = new GameClass();
                        //ResetGame.Game();
                    }

                    int NextPlayerLocationIndex = GetNextPlayerLocationIndex(CurrentPlayerLocationIndex, Move);
                    CurrentPlayerLocationIndex = isMoveInBounds(NextPlayerLocationIndex, CurrentPlayerLocationIndex);

                    Refesh.RenderScreen();
                    Refesh.RenderPlayerScores(Player.PlayerXScore, Player.PlayerOScore);
                    Refesh.RenderGameInstructions();
                    Refesh.RenderPlayer(GetPlayerLocationReff(CurrentPlayerLocationIndex),
                        CheckMoveIsFreeToSet(CurrentPlayerLocationIndex, gameBordIndex));

                    Move = GetInput();
                }
                SetMove = CheckMoveIsFreeToSet(CurrentPlayerLocationIndex, gameBordIndex);
                if (SetMove == false) { MovePlayerLoop(Player, GameBordIndex); }
            }
            int BackupLocationIndex = CurrentPlayerLocationIndex;
            return BackupLocationIndex;
        }
        //    if (CheckMoveIsFreeToSet(CurrentPlayerLocationIndex, gameBordIndex )==true) { return CurrentPlayerLocationIndex; }
        //    //else { MovePlayerLoop( Player, GameBordIndex); }

        //        MovePlayerLoop(Player, GameBordIndex);


        //    int BackupLocationIndex = CurrentPlayerLocationIndex;
        //    return BackupLocationIndex;
        //}

        public ConsoleKey GetInput() 
        {
           
            ConsoleKey Input;
           
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Input = keyInfo.Key;
            } while (Console.KeyAvailable);
            return Input;
        }

        public int[] GetPlayerLocationReff(int PlayerLocationIndex)
        {
           int[] T1 = [56, 4];
           int[] T2 = [59, 4];
           int[] T3 = [62, 4];

           int[] T4 = [56, 7];
           int[] T5 = [59, 7];
           int[] T6 = [62, 7];

           int[] T7 = [56, 10];
           int[] T8 = [59, 10];
           int[] T9 = [62, 10];
          
            switch (PlayerLocationIndex)
            {
                

                case 0: return T1;
                case 1: return T2;
                case 2: return T3;
                case 3: return T4;
                case 4: return T5;
                case 5: return T6;
                case 6: return T7;
                case 7: return T8;
                case 8: return T9;
            }
            return T5;
        }



    }


}
