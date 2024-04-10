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

        public int GetSingleGameIndexRandom(int[] GameBoredIndex)
        {
            int ChosenMove = 4;

            Random Chioce = new Random();

            bool?[] GameBoredBool = ConvertGameBoredToNullBool(GameBoredIndex);

            List<int> AvalabelMoves = GetAvalabelMoves(GameBoredBool);

            ChosenMove = AvalabelMoves[Chioce.Next(0, AvalabelMoves.Count - 1)];

            return ChosenMove;
        }
        public int GetSingleGameIndex(int[] GameBoredIndex,int PlayerIndex) 
        {
            bool?[] GameBoredBool = ConvertGameBoredToNullBool(GameBoredIndex);
            
            bool CurrentPlayer = SetCurrentPlayer(PlayerIndex);
            bool OpponentPlayer = SetOpponentPlayer(CurrentPlayer);

            bool GameOver;

            // loss = 11 draw = 10  win <=9 already been played >= 12
            int[] MovesTillOptimalGameOver = new int[9] {11,11,11,11,11,11,11,11,11 };

            int LowestMoveCount = 12;

            for (int i = 0; i<8; i++)
            {
                GameOver = false;
                int TestTurnCount = 0;
                
                if (GameBoredBool[i]==null)
                {
                    bool?[] Test1 = new bool?[9] ;
                    int I=0;
                    foreach (bool? Index in GameBoredBool)
                    {
                        Test1[I] = Index;
                        I++;
                    }
                    Test1[i] = CurrentPlayer;

                    TestTurnCount++;

                    GameOver = EvaulateGameBool(Test1);

                    if (GameOver) 
                    {  if (TestTurnCount < LowestMoveCount) {LowestMoveCount = TestTurnCount;} }
                    else
                     {

                        bool?[] Test2 = CoppyGameBoredBool(Test1);
                        for(int a=0; a<8; a++)
                        {
                            TestTurnCount = 1;

                            if (Test2[a]==null)
                            {
                                Test2[a] = OpponentPlayer;
                                TestTurnCount++;

                                GameOver = EvaulateGameBool(Test2);

                            }
                            else { TestTurnCount = 12; }
                            if (TestTurnCount >= LowestMoveCount) { GameOver = true; }
                            if (GameOver) { break; }
                            else 
                            {
                                bool?[] Test3 = CoppyGameBoredBool(Test2);
                                for (int b = 0; b < 8; b++)
                                {
                                    TestTurnCount = 2;

                                    if (Test3[b] == null)
                                    {
                                        Test3[b] = CurrentPlayer;
                                        TestTurnCount++;

                                        GameOver = EvaulateGameBool(Test3);

                                    }
                                    else { TestTurnCount = 12; }
                                    if (TestTurnCount >= LowestMoveCount) { GameOver = true; }
                                    if (GameOver) { break; }
                                    else
                                    {
                                        bool?[] Test4 = CoppyGameBoredBool(Test3);
                                        for (int c = 0; c < 8; c++)
                                        {
                                            TestTurnCount = 3;

                                            if (Test4[c] == null)
                                            {
                                                Test4[c] = OpponentPlayer;
                                                TestTurnCount++;

                                                GameOver = EvaulateGameBool(Test4);

                                            }
                                            else { TestTurnCount = 12; }
                                            if (TestTurnCount >= LowestMoveCount) { GameOver = true; }
                                            if (GameOver) { break; }
                                            else
                                            {
                                                bool?[] Test5 = CoppyGameBoredBool(Test4);
                                                for (int d = 0; d < 8; d++)
                                                {
                                                    TestTurnCount = 4;

                                                    if (Test5[d] == null)
                                                    {
                                                        Test3[b] = CurrentPlayer;
                                                        TestTurnCount++;

                                                        GameOver = EvaulateGameBool(Test5);

                                                    }
                                                    else { TestTurnCount = 12; }
                                                    if (TestTurnCount >= LowestMoveCount) { GameOver = true; }
                                                    if (GameOver) { break; }
                                                    else
                                                    {
                                                        bool?[] Test6 = CoppyGameBoredBool(Test5);
                                                        for (int e = 0; e < 8; e++)
                                                        {
                                                            TestTurnCount = 5;

                                                            if (Test6[e] == null)
                                                            {
                                                                Test6[e] = OpponentPlayer;
                                                                TestTurnCount++;

                                                                GameOver = EvaulateGameBool(Test6);

                                                            }
                                                            else { TestTurnCount = 12; }
                                                            if (TestTurnCount >= LowestMoveCount) { GameOver = true; }
                                                            if (GameOver) { break; }
                                                            else
                                                            {
                                                                bool?[] Test7 = CoppyGameBoredBool(Test6);
                                                                for (int f = 0; f < 8; f++)
                                                                {
                                                                    TestTurnCount = 6;

                                                                    if (Test7[f] == null)
                                                                    {
                                                                        Test7[f] = CurrentPlayer;
                                                                        TestTurnCount++;

                                                                        GameOver = EvaulateGameBool(Test7);

                                                                    }
                                                                    else { TestTurnCount = 12; }
                                                                    if (TestTurnCount >= LowestMoveCount) { GameOver = true; }
                                                                    if (GameOver) { break; }
                                                                    else
                                                                    {
                                                                        bool?[] Test8 = CoppyGameBoredBool(Test7);
                                                                        for (int g = 0; g < 8; g++)
                                                                        {
                                                                            TestTurnCount = 7;

                                                                            if (Test8[g] == null)
                                                                            {
                                                                                Test8[g] = OpponentPlayer;
                                                                                TestTurnCount++;

                                                                                GameOver = EvaulateGameBool(Test8);

                                                                            }
                                                                            else { TestTurnCount = 12; }
                                                                            if (TestTurnCount >= LowestMoveCount) { GameOver = true; }
                                                                            if (GameOver) { break; }
                                                                            else
                                                                            {
                                                                                bool?[] Test9 = CoppyGameBoredBool(Test8);
                                                                                for (int h = 0; h < 8; h++)
                                                                                {
                                                                                    TestTurnCount = 8;

                                                                                    if (Test9[h] == null)
                                                                                    {
                                                                                        Test9[h] = CurrentPlayer;
                                                                                        TestTurnCount++;

                                                                                        GameOver = EvaulateGameBool(Test9);

                                                                                    }
                                                                                    else { TestTurnCount = 12; }
                                                                                    if (TestTurnCount >= LowestMoveCount) { GameOver = true; }
                                                                                    if (GameOver) { break; }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    
                    }
                    
                }
                else { TestTurnCount = 12; }
                
                //if (TestTurnCount > LowestMoveCount) { GameOver = true; }
            
                //if(GameOver)
                //{
                    MovesTillOptimalGameOver[i] = TestTurnCount;
                //}
            
            }
            //retern index for LestMoves to win
            
            // Game Over On OponentTurns = loss MakeTurnCount = 11. turn counter redundent on Oponent turns.
            return LowestMoveCount;
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
        private bool SetCurrentPlayer(int PlayerIndex)
        {
            if (PlayerIndex == 1) { return true; }
            else { return false; }
        }
        private bool SetOpponentPlayer(bool CurrentPlayer)
        { 
            if (CurrentPlayer == true) { return false; }
            else { return true; }
        }
        private bool?[] CoppyGameBoredBool(bool?[] GameBoredBool)
        {
            bool?[] NewArray = new bool?[9];

            for(int i = 0;i < 9;i++)
            {
                NewArray[i] = GameBoredBool[i];
            }
            return NewArray;
        }
    }
}
