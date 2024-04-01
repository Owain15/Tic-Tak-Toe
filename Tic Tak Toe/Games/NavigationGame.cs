using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Game;
using Tic_Tak_Toe.Builders;
using Tic_Tak_Toe.Resources;
using Tic_Tak_Toe.HomePage;

namespace Tic_Tak_Toe.Game
{
    internal class NavigationGame
    {
        int[] GameLocation;
        public NavigationGame(int[] gameLocation) { GameLocation = gameLocation; }

        public int GetNextPlayerLocationIndex(int PlayerLocationIndex, ConsoleKey Move)
        {
            int NextPlayerLocationIndex = PlayerLocationIndex;

            switch (Move)
            {
                case ConsoleKey.UpArrow:
                    {
                        NextPlayerLocationIndex = PlayerLocationIndex - 3;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        NextPlayerLocationIndex = PlayerLocationIndex + 3;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        NextPlayerLocationIndex = PlayerLocationIndex - 1;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        NextPlayerLocationIndex = PlayerLocationIndex + 1;
                        break;
                    }


            }
            bool MoveInBounds = CheckMoveIsInBounds(NextPlayerLocationIndex);
            if (MoveInBounds) { PlayerLocationIndex = NextPlayerLocationIndex; }
            return PlayerLocationIndex;

        }
        public bool CheckMoveIsInBounds(int PreposedPlayerLocationIndex)
        {
            if (PreposedPlayerLocationIndex < 0) { return false; }
            if (PreposedPlayerLocationIndex > 8) { return false; }
            else { return true; }
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
        private void ScoreResetCheck(ConsoleKey Move, PlayerClass CurrentPlayer,  PlayerClass PlayerOne ,PlayerClass PlayerTwo,
            int[] GamePositionReff, bool GameLooped)
        {
            if (Move == ConsoleKey.Backspace)
            {
                PlayerOne.PlayerScore = 0;
                PlayerTwo.PlayerScore = 0;

                CurrentPlayer.PlayerLocationIndex = 4;
                Tic_Tak_Toe.Game.GameLogicClass ResetCurrentGame = new Tic_Tak_Toe.Game.GameLogicClass(GameLocation);
              //  ResetCurrentGame.Game(PlayerOne,PlayerTwo,GamePositionReff,GameLooped);
            }
        }
        private void PlayerEndGameCheck(ConsoleKey Move)
        { 
            if (Move == ConsoleKey.Escape) 
            { 
                Tic_Tak_Toe.HomePage.HomePage ResetProgram = new Tic_Tak_Toe.HomePage.HomePage(GameLocation);
                Console.Clear();
                ResetProgram.OpenHomePage();
            }
        }
        public int MovePlayerLoop(PlayerClass CurrentPlayer, PlayerClass PlayerOne, PlayerClass PlayerTwo, int[] GameBordIndex, int[,] GridReff,
            int[] GamePositionReff, bool GameLooped )
        {
            int[] gameBordIndex = GameBordIndex;
            RenderClass Refesh = new RenderClass(GameLocation);
                

            int CurrentPlayerLocationIndex = CurrentPlayer.PlayerLocationIndex;
            ConsoleKey Move = GetInput();

            while (Move != ConsoleKey.Enter)
            {
                ScoreResetCheck(Move,CurrentPlayer, PlayerOne,PlayerTwo,GamePositionReff,GameLooped);
                PlayerEndGameCheck(Move);
                int NextPlayerLocationIndex = GetNextPlayerLocationIndex(CurrentPlayerLocationIndex, Move);
                CurrentPlayerLocationIndex = isMoveInBounds(NextPlayerLocationIndex, CurrentPlayerLocationIndex);

                Refesh.RenderScreen();
                Refesh.RenderPlayerScores(PlayerOne.PlayerScore, PlayerTwo.PlayerScore);
                Refesh.RenderGameInstructions();
                Refesh.RenderPlayer(GridReffBuilder(GridReff, CurrentPlayerLocationIndex),
                       CheckMoveIsFreeToSet(CurrentPlayerLocationIndex, gameBordIndex), CurrentPlayer);

                Move = GetInput();
            }
            return CurrentPlayerLocationIndex;
        }
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
        public int[] GridReffBuilder(int[,] GridReff, int gridReffIndex)
        {
            int GridReffIndex = gridReffIndex;
            int gridReffX = GridReff[GridReffIndex, 0];
            int gridReffY = GridReff[GridReffIndex, 1];
            int[] gridReff = new int[2] { gridReffX, gridReffY };
            return gridReff;
        }
        public int[] GetGridReff(int[] GridPositionReff, int PlayerLocationIndex)
        {
            int[] Result = new int[2];

            switch(PlayerLocationIndex) 
            {
                    case 0: { Result[0] = 0; Result[1] = 0; }break;
                    case 1: { Result[0] = 3; Result[1] = 0; } break;
                    case 2: { Result[0] = 6; Result[1] = 0; } break;
                    case 3: { Result[0] = 0; Result[1] = 3; } break;
                    case 4: { Result[0] = 3; Result[1] = 3; } break;
                    case 5: { Result[0] = 6; Result[1] = 3; } break;
                    case 6: { Result[0] = 0; Result[1] = 6; } break;
                    case 7: { Result[0] = 3; Result[1] = 6; } break;
                    case 8: { Result[0] = 6; Result[1] = 6; } break;
            }
           
            Result[0] = Result[0] + GridPositionReff[0];
            Result[1] = Result[1] + GridPositionReff[1];
            
            return Result;
        }
    }
}
