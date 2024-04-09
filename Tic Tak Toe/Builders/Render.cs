using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Game;
using Tic_Tak_Toe.Builders;
using Tic_Tak_Toe.Resources;
using System.Reflection;

namespace Tic_Tak_Toe.Builders
{
    internal class RenderClass
    {

        PageClass Window;
        GridClass Bored;
        //PlayerClass CurrentPlayer;
        int[] GameBoredIndex;
        int[] GameLocation;
        Array Builder = new Array();
        TicTakToeSinglePage ArrayReff = new TicTakToeSinglePage();

        public RenderClass(int[] gameLocation)
        {
            GameLocation = gameLocation;

            Window = new PageClass(GameLocation);
            Bored = new GridClass(GameLocation);
            
                       
            Builder = new Array();
            ArrayReff = new TicTakToeSinglePage();
        }


        //public RenderClass(PlayerClass player, int[] gameBordInedx, int[] gamePositionReff)
        //{ CurrentPlayer = player; GameBoredIndex = gameBordInedx; GamePositionReff = gamePositionReff; }

        public void RenderScreen()
        {
            Console.Clear();
            Window.PageBuilder();
            Bored.GridBuilderLoop(GameLocation[0], GameLocation[1], GameBoredIndex);

        }
        public void RenderGameBored(int[] GameLocation,int[] gameBoredIndex) 
        { Bored.GridBuilderLoop(GameLocation[0], GameLocation[1], gameBoredIndex); }
        public void RenderSingleGamePlayerIndicatorsSetUp(int[] GameLocation, PlayerClass currentPlayer)
        {
           
            Bored.TileBuilder(GameLocation[0]+7, GameLocation[1],1);
            Bored.TileBuilder(GameLocation[0]+18, GameLocation[1],-1);
          
        }
        public void RenderPlayer(int[] PlayerLocationIndex, bool IsPositionFreeOnBored, PlayerClass currentPlayer)
        {
            PlayerClass CurrentPlayer = currentPlayer;
            if (IsPositionFreeOnBored == true)
            { CurrentPlayer.Draw(PlayerLocationIndex,GameLocation); }
            else
            { CurrentPlayer.DrawError(PlayerLocationIndex, GameLocation); }
        }
        public void RenderPlayerScores(int PlayerXScore, int PlayerOScore)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(57, 2);
            Console.WriteLine(PlayerXScore);
            Console.SetCursorPosition(67, 2);
            Console.WriteLine(PlayerOScore);
            Console.ResetColor();
        }
        public void RenderPlayerOWins(int[] GamePosition)
        { Builder.DrawArray(ArrayReff.OWinsScreen , GamePosition[0], GamePosition[1]); }
        public void RenderPlayerXWins(int[] GamePosition)
        { Builder.DrawArray(ArrayReff.XWinsScreen, GamePosition[0], GamePosition[1]); }
        public void RenderItsADraw(int[] GamePosition)
        { Builder.DrawArray(ArrayReff.ItsADrawScreen, GamePosition[0], GamePosition[1]); }
        public void RenderGameInstructions()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Builder.DrawArray(ArrayReff.GameInstructions, 0, 0);
            Console.ResetColor();
        }
        public void CCPAnimation(int[] GameLocation, int[] GameBoredLocation,int[] GameBoredIndex, PlayerClass CurrentPlayer)
        {
            NavigationGame Move = new NavigationGame(GameLocation);
            GameLogicClass Logic = new GameLogicClass(GameLocation);

            int[] DisplayBoredIndex = new int[9];
            for (int i = 0; i < 9; i++)
            { DisplayBoredIndex[i] = CurrentPlayer.PlayerIndex; }
            

            int Delay = 100;

            RenderGameBored(GameBoredLocation,DisplayBoredIndex);
            Thread.Sleep(Delay);
            RenderGameBored(GameBoredLocation,GameBoredIndex);
            Thread.Sleep(Delay);
            RenderGameBored(GameBoredLocation, DisplayBoredIndex);
            Thread.Sleep(Delay);
            RenderGameBored(GameBoredLocation, GameBoredIndex);
            Thread.Sleep(Delay*2);

            for (int i = 0; i < 9; i++)
            {
                RenderPlayer(Move.GetGridReff(GameBoredLocation, i),
                          Logic.CheckMoveIsFreeToSet(i, GameBoredIndex), CurrentPlayer);

                Thread.Sleep(Delay);

                RenderGameBored(GameBoredLocation, GameBoredIndex);
            }

            RenderGameBored(GameBoredLocation, DisplayBoredIndex);
            Thread.Sleep(Delay);
            RenderGameBored(GameBoredLocation, GameBoredIndex);
            Thread.Sleep(Delay);
            RenderGameBored(GameBoredLocation, DisplayBoredIndex);
            Thread.Sleep(Delay);
            RenderGameBored(GameBoredLocation, GameBoredIndex);
            Thread.Sleep(Delay);
        }
      



    }
}
