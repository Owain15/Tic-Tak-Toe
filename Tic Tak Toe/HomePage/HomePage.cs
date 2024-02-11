using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tak_Toe.Resources;
using Tic_Tak_Toe.Builders;


namespace Tic_Tak_Toe.HomePage
{
    internal class HomePage
    {
        Tic_Tak_Toe.Resources.HomePage HomePageReff = new Tic_Tak_Toe.Resources.HomePage();
        Tic_Tak_Toe.Builders.Array Builder = new Tic_Tak_Toe.Builders.Array();
        NavigationHomePage UserInput = new NavigationHomePage();
        HomePageLogic StartGame = new HomePageLogic();

        GameChoice[] GameReff = new GameChoice[2];
        PlayersChoice[] PlayersReff = new PlayersChoice[2];
        
        
        private int GameIndex = 0;
        private int PlayersIndex = 0;

        public int[] PageIndex = new int[2];

        public void OpenHomePage()
        {

            GameReff[0] = new GameChoice(0, "+ Tic Tak Toe +", 51, 8);
            GameReff[1] = new GameChoice(1, " + Super Triple T +", 49, 8);

            PlayersReff[0] = new PlayersChoice(0, " P.V.P ", 55, 11);
            PlayersReff[1] = new PlayersChoice(1, " P.V.C ", 55, 11);

            RenderScreen();
            int[] GameSelection = GameSelectionLoop(UserInput);
            StartGame.RunHomePageLogic(GameSelection);
        }

        private int[] GameSelectionLoop(NavigationHomePage UserInput)
        {
            
            int[] PageReff = PageReffBuilder(GameIndex,PlayersIndex);
            ConsoleKey Input = ConsoleKey.A;

            while (Input != ConsoleKey.Enter)
            {
                Input = UserInput.GetInput();
                int[] NextPageReff = UserInput.NavagatePage(Input,PageReff);

                

                PageReff[0] = LoopArrayCheckInt(GameReff.Length, PageReff[0]);
                PageReff[1] = LoopArrayCheckInt(PlayersReff.Length, PageReff[1]);
    
                GameIndex = PageReff[0];
                PlayersIndex = PageReff[1];
                RenderGameChoice();
                RenderPlayersChoice();
                
              
            }
            PageReff = PageReffBuilder(GameIndex, PlayersIndex);
            return PageReff;
        }
        
        private int[] PageReffBuilder(int GameIndex, int PlayersIndex)
        { int[] PageReff = new int[2] {GameIndex,PlayersIndex};return PageReff; } 
        private int LoopArrayCheckInt(int ArrayLength, int ArrayReff)
        { 
        if(ArrayReff< 0) { ArrayReff = ArrayLength -1; }
        if(ArrayReff> ArrayLength) {  ArrayReff = 0;}
        return ArrayReff;
        }
        private void RenderBorder()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Builder.DrawArray(HomePageReff.HomePageBorder, 40, 2);
            Console.ResetColor();
        }
        private void RenderInstruction()
        { 
            Console.ForegroundColor= ConsoleColor.DarkGray;
            Builder.DrawArray(HomePageReff.HomePageInstructions,40,18);
            Console.ResetColor();
        }
        private void RenderGameChoice()
        {
            Console.ForegroundColor=( ConsoleColor.DarkGray );
            Console.SetCursorPosition(GameReff[GameIndex].WrightLineX, GameReff[GameIndex].WrightLineY);
            Console.WriteLine(GameReff[GameIndex].GameName);
            Console.ResetColor();
        }
        private void RenderPlayersChoice() 
        {
            Console.ForegroundColor = (ConsoleColor.DarkGray);
            Console.SetCursorPosition(PlayersReff[PlayersIndex].WrightLineX, PlayersReff[PlayersIndex].WrightLineY);
            Console.WriteLine(PlayersReff[PlayersIndex].PlayersString);
            Console.ResetColor();
        }
        private void RenderScreen()
        {
            RenderBorder();
            RenderGameChoice();
            RenderPlayersChoice();
            RenderInstruction();
        }

    }
}
