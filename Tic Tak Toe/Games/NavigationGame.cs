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
                Tic_Tak_Toe.Game.GameLogicClass ResetCurrentGame = new Tic_Tak_Toe.Game.GameLogicClass();
                ResetCurrentGame.Game(PlayerOne,PlayerTwo,GamePositionReff,GameLooped);
            }
        }
        private void PlayerEndGameCheck(ConsoleKey Move)
        { if (Move == ConsoleKey.Escape) 
            { Tic_Tak_Toe.HomePage.HomePage ResetProgram
            = new Tic_Tak_Toe.HomePage.HomePage();
                Console.Clear();
                ResetProgram.OpenHomePage();
            } }
        public int MovePlayerLoop(PlayerClass CurrentPlayer, PlayerClass PlayerOne, PlayerClass PlayerTwo, int[] GameBordIndex, int[,] GridReff,
            int[] GamePositionReff, bool GameLooped )
        {
            int[] gameBordIndex = GameBordIndex;
            RenderClass Refesh = new RenderClass(CurrentPlayer, gameBordIndex , GamePositionReff);

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
                       CheckMoveIsFreeToSet(CurrentPlayerLocationIndex, gameBordIndex));

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
    }
}
