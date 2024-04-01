using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Builders;
using Tic_Tak_Toe.Game;


namespace Tic_Tak_Toe.Game.SuperTicTakToe
{
    internal class SuperTicTakToeGameClass
    {

        public int GameID;
        
        public int[] GameLocation;
        public int[] GameBoredIndex;
        public int? GameResult;
        public bool GameInPlay;

        PlayerClass CurrentPlayer;
        RenderClass Screen;
        
    
        public SuperTicTakToeGameClass(int gameID, int[] gameLocation, PlayerClass currentPlayer)
        {
            GameID = gameID;
            GameLocation = gameLocation;
            CurrentPlayer = currentPlayer;
            GameResult = null;
            GameBoredIndex = new int[9] {0,0,0,0,0,0,0,0,0};
            Screen = new RenderClass(GameLocation);
            GameInPlay = true;
           
        }   
        public void Render()
        {
            Screen.RenderGameBored(GameLocation,GameBoredIndex);

        }
        public void RenderResult() 
        {
            if(GameResult != null)
            { switch(GameResult)
                {
                    case 3: { Screen.RenderPlayerXWins(GameLocation); } break;
                    case-3: { Screen.RenderPlayerOWins(GameLocation); } break;
                    case 0: { Screen.RenderItsADraw   (GameLocation); } break;

                }
                
            }
            else { Render(); }
        }
        public void SetToBord(PlayerClass Currentplayer)
        { GameBoredIndex.SetValue(Currentplayer.PlayerIndex,Currentplayer.PlayerLocationIndex); }
    }
}
