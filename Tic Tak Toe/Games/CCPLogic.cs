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

        public int GetSingleGameEacy(int[] GameBoredIndex)
        {
            int ChosenMove = 4;

            Random Chioce = new Random();

            bool?[] GameBoredBool = ConvertGameBoredToNullBool(GameBoredIndex);

            List<int> AvalabelMoves = GetAvalabelMoves(GameBoredBool);

            ChosenMove = AvalabelMoves[Chioce.Next(0, AvalabelMoves.Count - 1)];

            return ChosenMove;
        }

        public int GetSingleGame(int Playerindex, int[] GameBoredIndex)
        {

            List<int> OptionsPerMove = new List<int>();

            for (int i = 0; i < GameBoredIndex.Length; i++)
            {
                int[] TestMove = new int[9];

                for(int Index = 0; Index < TestMove.Length-1; Index++)
                { TestMove[Index] = GameBoredIndex[Index]; }


                if (TestMove[i] == 0)
                {
                    TestMove[i] = Playerindex;
               
                    // Remove TestMoves containg and opponents playerindex
                    int Options = CheckForBestOptions(TestMove);

                    OptionsPerMove.Add(Options);
                
                }


            }
            
            int MostOptions = 0;

            for (int i = 0; i < OptionsPerMove.Count - 1; i++)
            {
                if (OptionsPerMove[i] > MostOptions) { MostOptions = OptionsPerMove[i]; }
            }
            
            List<int> MoveIndexList = new List<int>();
            
            for(int i = 0;i <= OptionsPerMove.Count -1;i++)
            { if (OptionsPerMove[i] >= MostOptions) { MoveIndexList.Add(i); } }

          
            Random RandomIndex = new Random();
           
            int ChosenMove = MoveIndexList[RandomIndex.Next(0,MoveIndexList.Count-1)];

            return ChosenMove;
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

        private int CheckForBestOptions(int[]TestBordIndex)
        {
            int BestValue = 0;

            int[] GameCheck = new int[8];

            GameCheck[0] = TestBordIndex[0] + TestBordIndex[1] + TestBordIndex[2];
            GameCheck[1] = TestBordIndex[3] + TestBordIndex[4] + TestBordIndex[5];
            GameCheck[2] = TestBordIndex[6] + TestBordIndex[7] + TestBordIndex[8];

            GameCheck[3] = TestBordIndex[0] + TestBordIndex[3] + TestBordIndex[6];
            GameCheck[4] = TestBordIndex[1] + TestBordIndex[4] + TestBordIndex[7];
            GameCheck[5] = TestBordIndex[2] + TestBordIndex[5] + TestBordIndex[8];

            GameCheck[6] = TestBordIndex[0] + TestBordIndex[4] + TestBordIndex[8];
            GameCheck[7] = TestBordIndex[6] + TestBordIndex[4] + TestBordIndex[2];

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

        private List<int> GetAvalabelMoves(bool?[] GameBoredBool)
        {
            List<int> AvalabelMoves = new List<int>();

            for (int i = 0; i < GameBoredBool.Length; i++)
            {
                if (GameBoredBool[i] == null) { AvalabelMoves.Add(i); }
            }

            return AvalabelMoves;
        }

    }
}
