using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Game;
using Tic_Tak_Toe.Builders;
using Tic_Tak_Toe.Resources;

namespace Tic_Tak_Toe.Builders
{
    internal class RenderClass
    {
        PageClass Window = new PageClass();
        GridClass Bored = new GridClass();
        PlayerClass CurrentPlayer;
        int[] GameBoredIndex;
        int[] GamePositionReff;
        Array Builder = new Array();
        TicTakToePage ArrayReff = new TicTakToePage();


        public RenderClass(PlayerClass player, int[] gameBordInedx, int[] gamePositionReff)
        { CurrentPlayer = player; GameBoredIndex = gameBordInedx; GamePositionReff = gamePositionReff; }

        public void RenderScreen()
        {
            Console.Clear();
            Window.PageBuilder();
            Bored.GridBuilderLoop(GamePositionReff[0], GamePositionReff[1], GameBoredIndex);

        }
        public void RenderGameBored() { Bored.GridBuilderLoop(GamePositionReff[0], GamePositionReff[1], GameBoredIndex); }
        public void RenderPlayer(int[] PlayerLocationIndex, bool IsPositionFreeOnBored)
        {
            if (IsPositionFreeOnBored == true)
            { CurrentPlayer.Draw(PlayerLocationIndex); }
            else
            { CurrentPlayer.DrawError(PlayerLocationIndex); }
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



    }
}
