using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Builders;
using Tic_Tak_Toe.Game;


namespace Tic_Tak_Toe.Game.SuperTicTakToe
{
    internal class TicTakToeGameClass
    {
        public int GameID;
        
        public int[] GamePosition;
        public int[] GameBoredIndex;
        public int? GameResult;
        public bool GameInPlay;

        PlayerClass CurrentPlayer;
        RenderClass Screen;
        
    
        public TicTakToeGameClass(int gameID, int[] gamePosition, PlayerClass currentPlayer)
        {
            GameID = gameID;
            GamePosition = gamePosition;
            CurrentPlayer = currentPlayer;
            GameResult = null;
            GameBoredIndex = new int[9] {0,0,0,0,0,0,0,0,0};
            Screen = new RenderClass(currentPlayer, GameBoredIndex, GamePosition);
            GameInPlay = true;
           
        }   
        public void Render()
        {
            Screen.RenderGameBored();

        }
        public void RenderResult() 
        {
            if(GameResult != null)
            { switch(GameResult)
                {
                    case 3: { Screen.RenderPlayerXWins(GamePosition); } break;
                    case-3: { Screen.RenderPlayerOWins(GamePosition); } break;
                    case 0: { Screen.RenderItsADraw   (GamePosition); } break;

                }
                
            }
            else { Render(); }
        }
        public void SetToBord(PlayerClass Currentplayer)
        { GameBoredIndex.SetValue(Currentplayer.PlayerIndex,Currentplayer.PlayerLocationIndex); }
    }
}
