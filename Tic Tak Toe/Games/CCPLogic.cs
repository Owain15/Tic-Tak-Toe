using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Game;

namespace Tic_Tak_Toe.Games
{
    internal class CCPLogic
    {


        public int GetSingleGame(int Playerindex, int[] GameBoredIndex)
        {
            int[] NullGameLocation = new int[0];
            GameLogicClass Logic = new GameLogicClass(NullGameLocation);

            int OptimalMove = 15;

            bool CurrentPlayerBoolIndex;
            bool OponentPlayerBoolIndex;

            if (Playerindex == 1) { CurrentPlayerBoolIndex = true; }
            else { CurrentPlayerBoolIndex = false; }

            if (CurrentPlayerBoolIndex) { OponentPlayerBoolIndex = false; }
            else { OponentPlayerBoolIndex = true; }

            bool?[] BoolGameBord = ConvertGameBoredToNullBool(GameBoredIndex);

            int MoveCountToGameOver;

            bool MoveFound = false;
            bool GameOver = false;


            List<int> OptionsPerMove = new List<int>();

            for (int i = 0; i < GameBoredIndex.Length - 1; i++)
            {
                GameBoredIndex[i] = Playerindex;

                int Options = CheckForOptions(GameBoredIndex);

                OptionsPerMove.Add(Options);
            

            //MoveCountToGameOver = 0;

            ////List<int> PosibleMoves = new List<int>();

            //for (int i = 0; i < BoolGameBord.Length - 1; i++)
            //{
            //    BoolGameBord[i] = CurrentPlayerBoolIndex;
            //    GameOver = EvaulateGameBool(BoolGameBord);

            //}



            }

            return OptimalMove;
        }


        private bool?[] ConvertGameBoredToNullBool(int[] GameBoredIndex)
        {
            bool?[] Convertion = new bool?[9];

            for (int i = 0; i < GameBoredIndex.Length - 1; i++)
            {
                bool? IndexResult = null;

                switch (GameBoredIndex[i])
                {
                    case 1: { IndexResult = true; } break;
                    case -1: { IndexResult = false; } break;
                }

                Convertion[i] = IndexResult;
            }

            return Convertion;
        }
        private bool EvaulateGameBool(bool?[] BoolGameBord)
        {
            bool GameOver = false;

            if (BoolGameBord[0] == BoolGameBord[1] == BoolGameBord[2]) { GameOver = true; }
            if (BoolGameBord[3] == BoolGameBord[4] == BoolGameBord[5]) { GameOver = true; }
            if (BoolGameBord[6] == BoolGameBord[7] == BoolGameBord[8]) { GameOver = true; }

            if (BoolGameBord[0] == BoolGameBord[3] == BoolGameBord[6]) { GameOver = true; }
            if (BoolGameBord[1] == BoolGameBord[4] == BoolGameBord[7]) { GameOver = true; }
            if (BoolGameBord[3] == BoolGameBord[5] == BoolGameBord[8]) { GameOver = true; }

            if (BoolGameBord[0] == BoolGameBord[4] == BoolGameBord[8]) { GameOver = true; }
            if (BoolGameBord[6] == BoolGameBord[4] == BoolGameBord[2]) { GameOver = true; }

            return GameOver;

        }

        private int CheckForOptions(int[]GameBordIndex)
        {
            int BestValue = 0;

            int[] GameCheck = new int[8];

            GameCheck[0] = GameBordIndex[0] + GameBordIndex[1] + GameBordIndex[2];
            GameCheck[1] = GameBordIndex[3] + GameBordIndex[4] + GameBordIndex[5];
            GameCheck[2] = GameBordIndex[6] + GameBordIndex[7] + GameBordIndex[8];

            GameCheck[3] = GameBordIndex[0] + GameBordIndex[3] + GameBordIndex[6];
            GameCheck[4] = GameBordIndex[1] + GameBordIndex[4] + GameBordIndex[7];
            GameCheck[5] = GameBordIndex[2] + GameBordIndex[5] + GameBordIndex[8];

            GameCheck[6] = GameBordIndex[0] + GameBordIndex[4] + GameBordIndex[8];
            GameCheck[7] = GameBordIndex[6] + GameBordIndex[4] + GameBordIndex[2];

            for(int i = 0; i < GameCheck.Length-1;i++)
            {
                if (GameCheck[i] > BestValue) { BestValue= GameCheck[i]; }
            }

            List<int> Result = new List<int>();
            
            for (int i = 0; i < GameCheck.Length - 1; i++)
            {
                if (GameCheck[i] == BestValue) { Result.Add(GameCheck[i]); }
            }

            int AmountOfOptions = Result.Count;

            return AmountOfOptions;
        }

    }
}
