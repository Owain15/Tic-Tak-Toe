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

            // loss = 11 draw = 10  win <=9 already been played >= 12 not set = 15
            int[] MovesTillOptimalGameOver = new int[9] {15,15,15,15,15,15,15,15,15 };

            for (int i = 0; i<9; i++)
            {
                GameOver = false;
                int TestTurnCount = 12;

                bool?[] Test1 = CoppyGameBoredBool(GameBoredBool);

                if (Test1[i] == null)
                {
                    TestTurnCount = 1;

                    Test1[i] = CurrentPlayer;

                    GameOver = EvaluateGameBool(Test1);
                }
                    //if (MovesTillOptimalGameOver[i] < TestTurnCount) { GameOver = true; }
                   
                    if (GameOver) 
                    {
                        if (TestTurnCount < MovesTillOptimalGameOver[i]) 
                        {
                            MovesTillOptimalGameOver[i] = TestTurnCount;
                        } 
                    }
                    else
                     {
                        bool?[] Test2 = CoppyGameBoredBool(Test1);
                        for(int a=0; a<8; a++)
                        {
                            GameOver = false;
                            TestTurnCount = 12;

                            if (Test2[a] == null)
                            {
                                TestTurnCount = 11;
                                Test2[a] = OpponentPlayer;

                                GameOver = EvaluateGameBool(Test2);
                            }
                                if (MovesTillOptimalGameOver[i] < TestTurnCount) { GameOver = true; }

                                if (GameOver)
                                {
                                    if (TestTurnCount < MovesTillOptimalGameOver[i])
                                    {
                                        MovesTillOptimalGameOver[i] = TestTurnCount;
                                    }
                                }
                                else 
                                {
                                    bool?[] Test3 = CoppyGameBoredBool(Test2);
                                    for (int b = 0; b < 8; b++)
                                    {
                                        GameOver = false;
                                        TestTurnCount = 3;

                                        if (Test3[b] == null)
                                        {
                                            Test3[b] = CurrentPlayer;

                                            GameOver = EvaluateGameBool(Test3);
                                            if (MovesTillOptimalGameOver[i]<TestTurnCount) { GameOver = true; }

                                        }
                                        else
                                        {
                                             bool?[] Test4 = CoppyGameBoredBool(Test3);
                                             for (int c = 0; c < 8; c++)
                                             {
                                                 GameOver = false;
                                                 TestTurnCount = 12;

                                                 if (Test4[c] == null)
                                                 {
                                                     Test4[c] = OpponentPlayer;

                                                     GameOver = EvaluateGameBool(Test4);
                                                 }
                                                 if (MovesTillOptimalGameOver[i] < 4) { GameOver = true; }
                                                 if (GameOver) 
                                                     { 
                                                        if (TestTurnCount < MovesTillOptimalGameOver[i])
                                                        { MovesTillOptimalGameOver[i] = TestTurnCount; }
                                                 }
                                                    else
                                                    {
                                                      bool?[] Test5 = CoppyGameBoredBool(Test4);
                                                      for (int d = 0; d < 8; d++)
                                                      {
                                                        GameOver = false ;
                                                        TestTurnCount = 12;

                                                        if (Test5[d] == null)
                                                        {
                                                         Test3[b] = CurrentPlayer;
                                                         TestTurnCount=5;

                                                         GameOver = EvaluateGameBool(Test5);
                                                                if (TestTurnCount > MovesTillOptimalGameOver[i]){ GameOver = true; }

                                                         if (GameOver) 
                                                                { 
                                                                    if (TestTurnCount < MovesTillOptimalGameOver[i])
                                                                    { MovesTillOptimalGameOver[i] = TestTurnCount; }    
                                                                }
                                                         else
                                                         {
                                                          bool?[] Test6 = CoppyGameBoredBool(Test5);
                                                            for (int e = 0; e < 8; e++)
                                                            {
                                                             GameOver = false;
                                                             TestTurnCount = 6;

                                                             if (Test6[e] == null)
                                                             {
                                                                Test6[e] = OpponentPlayer;
                                                                TestTurnCount=11;

                                                                GameOver = EvaluateGameBool(Test6);
                                                             }
                                                             if (TestTurnCount > MovesTillOptimalGameOver[i]) { GameOver = true; }

                                                             if (GameOver) 
                                                             { 
                                                               if (TestTurnCount < MovesTillOptimalGameOver[i])
                                                               { MovesTillOptimalGameOver[i] = TestTurnCount; }
                                                             }
                                                             else
                                                            {
                                                                bool?[] Test7 = CoppyGameBoredBool(Test6);
                                                                for (int f = 0; f < 8; f++)
                                                                {
                                                                    GameOver = false;
                                                                    TestTurnCount = 7;

                                                                    if (Test7[f] == null)
                                                                    {
                                                                        Test7[f] = CurrentPlayer;
                                                                        TestTurnCount=7;

                                                                        GameOver = EvaluateGameBool(Test7);
                                                                    }
                                                                    if(TestTurnCount > MovesTillOptimalGameOver[i]) { GameOver = true; }
                                                                   
                                                                    if(GameOver)
                                                                    {
                                                                      if (TestTurnCount < MovesTillOptimalGameOver[i])
                                                                      { MovesTillOptimalGameOver[i]= TestTurnCount; }
                                                                    }
                                                                    else
                                                                    {
                                                                        bool?[] Test8 = CoppyGameBoredBool(Test7);
                                                                        for (int g = 0; g < 8; g++)
                                                                        {
                                                                            GameOver = false;
                                                                            TestTurnCount = 8;

                                                                            if (Test8[g] == null)
                                                                            {
                                                                                Test8[g] = OpponentPlayer;
                                                                                TestTurnCount = 11;

                                                                                GameOver = EvaluateGameBool(Test8);

                                                                            }
                                                                            if (TestTurnCount > MovesTillOptimalGameOver[i]) { GameOver = true; }   
                                                                            
                                                                            if(GameOver)
                                                                               {
                                                                                 if (TestTurnCount < MovesTillOptimalGameOver[i])
                                                                                    { MovesTillOptimalGameOver[i] = TestTurnCount; }
                                                                               }
                                                                            else
                                                                            {
                                                                                bool?[] Test9 = CoppyGameBoredBool(Test8);
                                                                                for (int h = 0; h < 8; h++)
                                                                                {
                                                                                    GameOver = false;
                                                                                    TestTurnCount = 9;

                                                                                    if (Test9[h] == null)
                                                                                    {
                                                                                        Test9[h] = CurrentPlayer;
                                                                                        TestTurnCount=9;

                                                                                        GameOver = EvaluateGameBool(Test9);

                                                                                    }
                                                                                    if (TestTurnCount > MovesTillOptimalGameOver[i]) { GameOver =true; }

                                                                                    if(GameOver)
                                                                                       {
                                                                                         if (TestTurnCount < MovesTillOptimalGameOver[i])
                                                                                            { MovesTillOptimalGameOver[i] = TestTurnCount; }
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
                    
                    }
                    
                
           
            }
            //retern index for LestMoves to win (Build Seperate Method) retern MovesTillOptimalGameOver
            
            int OptialGameOverIndex = GetOptimalIndex(MovesTillOptimalGameOver);
            // 11,11 1,7
            return OptialGameOverIndex;
        }

        public int GetSingleGameTrial(int Playerindex, int[] GameBoredIndex)
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

        private bool EvaluateGameBool(bool?[] BoolGameBord)
        {
            bool GameOver = false;

            if (BoolGameBord[0] == BoolGameBord[1]) { if (BoolGameBord[0] == BoolGameBord[2]) { if (BoolGameBord[0] != null) { GameOver = true; } } }
            if (BoolGameBord[3] == BoolGameBord[4]) { if (BoolGameBord[3] == BoolGameBord[5]) { if (BoolGameBord[3] != null) { GameOver = true; } } }
            if (BoolGameBord[6] == BoolGameBord[7]) { if (BoolGameBord[6] == BoolGameBord[8]) { if (BoolGameBord[6] != null) { GameOver = true; } } }

            if (BoolGameBord[0] == BoolGameBord[3]) { if (BoolGameBord[0] == BoolGameBord[6]) { if (BoolGameBord[0] != null) { GameOver = true; } } }
            if (BoolGameBord[1] == BoolGameBord[4]) { if (BoolGameBord[1] == BoolGameBord[7]) { if (BoolGameBord[1] != null) { GameOver = true; } } }
            if (BoolGameBord[3] == BoolGameBord[5]) { if (BoolGameBord[3] == BoolGameBord[8]) { if (BoolGameBord[3] != null) { GameOver = true; } } }

            if (BoolGameBord[0] == BoolGameBord[4]) { if (BoolGameBord[0] == BoolGameBord[8]) { if (BoolGameBord[0] != null) { GameOver = true; } } }
            if (BoolGameBord[6] == BoolGameBord[4]) { if (BoolGameBord[6] == BoolGameBord[2]) { if (BoolGameBord[6] != null) { GameOver = true; } } }

            return GameOver;
        }
        private bool EvaulateGameBoolTestOne(bool?[] BoolGameBord)
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
        private int GetOptimalIndex( int[]MovesTillOptimalGameOver )
        {
            int OptimalMoveIndex = 15;
            int BestMove = 15;

            foreach (int Moves in MovesTillOptimalGameOver)
            {
                if(Moves < BestMove) { BestMove = Moves; }
            }

            List<int> MoveIndexList = new List<int>();

            for (int i = 0; i < MovesTillOptimalGameOver.Length - 1; i++)
            {
                if (MovesTillOptimalGameOver[i] == BestMove) { MoveIndexList.Add(i); }
            }
           
            Random Choice = new Random();
            OptimalMoveIndex = MoveIndexList[Choice.Next(0,MoveIndexList.Count-1)];

            return OptimalMoveIndex;
            
        }
    }
}
