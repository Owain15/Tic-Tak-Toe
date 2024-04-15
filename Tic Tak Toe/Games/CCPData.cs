using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Game;

namespace Tic_Tak_Toe.Games
{
    internal class CCPData
    {
        public int NextMove;

        List<int> BestMoveList;
        int[] MoveCounts;

        PlayerClass CurrentPlayer;

        int PlayerIndex;
        int OpponentsIndex;

        public CCPData(int[] GameBoredIndex,PlayerClass currentPlayer)
        {
            CurrentPlayer = currentPlayer;

            PlayerIndex = CurrentPlayer.PlayerIndex;
            OpponentsIndex = SetOpponentIndex(PlayerIndex);

            MoveCounts = MovesToGameOver(GameBoredIndex);

            BestMoveList = SetBestMoveList(MoveCounts);

            NextMove = SetNextMove(BestMoveList);
        }

        private int[] MovesToGameOver(int[] GameBoredIndex)
        {
           // List<int> BestMoves = new List<int>();

            // 15,not set. 12,loss. >9, win.
            int[] MoveCount = new int[9] { 15, 15, 15, 15, 15, 15, 15, 15, 15 };

            bool GameOver;
            int TurnCount;

            for (int a = 0; a<9; a++)
            {
                GameOver = false;
                TurnCount = 13;

                int[] Test1 = CopyGameBored(GameBoredIndex);

                if (Test1[a] == 0)
                {
                    Test1[a] = PlayerIndex;

                    TurnCount = 1;
                }
                GameOver = EvaluateGame(Test1);
                if (GameOver)
                {
                    if (TurnCount < MoveCount[a]) { MoveCount[a] = TurnCount; }
                }
                else
                {
                    for (int b = 0; b < 9; b++)
                    {
                        GameOver = false;
                        TurnCount = 12;

                        int[] Test2 = CopyGameBored(Test1);

                        if (Test2[b] == 0)
                        {
                            Test2[b] = OpponentsIndex;
                        }
                        GameOver = EvaluateGame(Test2);
                        if (GameOver)
                        {
                            if (TurnCount < MoveCount[a]) { MoveCount[a] = TurnCount; }
                        }
                        else
                        {
                            for (int c = 0; c < 9; c++)
                            {
                                GameOver = false;
                                TurnCount = 3;

                                int[] Test3 = CopyGameBored(Test2);

                                if (Test3[c] == 0)
                                {
                                    Test3[c] = PlayerIndex;
                                }
                                GameOver = EvaluateGame(Test3);
                                if (GameOver)
                                {
                                    if (TurnCount < MoveCount[a]) { MoveCount[a] = TurnCount; }
                                }
                                else 
                                {
                                    for (int d = 0; d < 9; d++)
                                    {
                                        GameOver = false;
                                        TurnCount = 12;

                                        int[] Test4 = CopyGameBored(Test3);

                                        if (Test4[d] == 0)
                                        {
                                            Test4[d] = OpponentsIndex;
                                        }
                                        GameOver = EvaluateGame(Test4);
                                        if (GameOver)
                                        {
                                            if (TurnCount < MoveCount[a]) { MoveCount[a] = TurnCount; }
                                        }
                                        else
                                        {
                                            for (int e = 0; e < 9; e++)
                                            {
                                                GameOver = false;
                                                TurnCount = 5;

                                                int[] Test5 = CopyGameBored(Test4);

                                                if (Test5[e] == 0)
                                                {
                                                    Test5[e] = PlayerIndex;
                                                }
                                                GameOver = EvaluateGame(Test5);
                                                if (GameOver)
                                                {
                                                    if (TurnCount < MoveCount[a]) { MoveCount[a] = TurnCount; }
                                                }
                                                else
                                                {
                                                    for( int f = 0; f < 9; f++)
                                                    {
                                                        GameOver = false;
                                                        TurnCount = 13;

                                                        int[] Test6 = CopyGameBored(Test5);

                                                        if (Test6[f] == 0)
                                                        {
                                                            Test6[f] = OpponentsIndex;
                                                        }
                                                        GameOver = EvaluateGame(Test6);
                                                        if (GameOver)
                                                        {
                                                            if (TurnCount < MoveCount[a]) { MoveCount[a] = TurnCount; }
                                                        }
                                                        else
                                                        {
                                                            for( int g = 0; g < 9; g++)
                                                            {
                                                                GameOver = false;
                                                                TurnCount = 7;

                                                                int[] Test7 = CopyGameBored(Test6);

                                                                if (Test7[g] == 0)
                                                                {
                                                                    Test7[g] = PlayerIndex;
                                                                }
                                                                GameOver = EvaluateGame(Test7);
                                                                if (GameOver)
                                                                {
                                                                    if (TurnCount < MoveCount[a]) { MoveCount[a] = TurnCount; }
                                                                }
                                                                else
                                                                { 
                                                                    for( int h = 0; h < 9; h++)
                                                                    {
                                                                        GameOver = false;
                                                                        TurnCount = 13;

                                                                        int[] Test8 = CopyGameBored(Test7);

                                                                        if (Test8[h] == 0)
                                                                        {
                                                                            Test8[h] = OpponentsIndex; 
                                                                        }
                                                                        GameOver = EvaluateGame(Test8);
                                                                        if (GameOver)
                                                                        {
                                                                            if (TurnCount < MoveCount[a]) { MoveCount[a] = TurnCount; }
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

            return MoveCount;
        }


        private int SetOpponentIndex(int PlayerIndex)
        { 
            int OpponentIndex = 1;

            if (PlayerIndex == 1) { OpponentIndex = -1; }

            return OpponentIndex;
        }
        private List<int> SetBestMoveList( int[] MoveCounts )
        {
            List<int> BestMoves = new List<int>();

            int LowestValue = 15;
            
            foreach (int Moves in MoveCounts)
            { if( Moves<LowestValue) { LowestValue = Moves; } }

            for (int i = 0; i < MoveCounts.Length-1; i++)
            { if (MoveCounts[i] == LowestValue) { BestMoves.Add(i); } }

            return BestMoves;
        }
        private int SetNextMove( List<int> BestMoveList)
        {
            Random Choice = new Random();

            int Move = BestMoveList[Choice.Next(0,BestMoveList.Count-1)];

            return Move;
        }
        private int[] CopyGameBored(int[] GameBoredIndex)
        {
            int[] Copy = new int[9];
            
            for (int i = 0;i<GameBoredIndex.Length-1;i++)
            { Copy[i] = GameBoredIndex[i]; }

            return Copy;
        }
        private bool EvaluateGame(int[]GameBoredIndex)
        {
            bool GameOver = false;

            int[] GameCheck = new int[8];

            GameCheck[0] = GameBoredIndex[0] + GameBoredIndex[1] + GameBoredIndex[2];
            GameCheck[1] = GameBoredIndex[3] + GameBoredIndex[4] + GameBoredIndex[5];
            GameCheck[2] = GameBoredIndex[6] + GameBoredIndex[7] + GameBoredIndex[8];

            GameCheck[3] = GameBoredIndex[0] + GameBoredIndex[3] + GameBoredIndex[6];
            GameCheck[4] = GameBoredIndex[1] + GameBoredIndex[4] + GameBoredIndex[7];
            GameCheck[5] = GameBoredIndex[2] + GameBoredIndex[4] + GameBoredIndex[8];

            GameCheck[6] = GameBoredIndex[0] + GameBoredIndex[4] + GameBoredIndex[8];
            GameCheck[7] = GameBoredIndex[6] + GameBoredIndex[4] + GameBoredIndex[2];

            foreach (int Result in GameCheck)
            {
                if (Result == 3) { GameOver = true; }
                if (Result ==-3) { GameOver = true; }
            }

            return GameOver;
        }
    }
}
