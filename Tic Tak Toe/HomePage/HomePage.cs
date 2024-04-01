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
        HomePageLogic StartGame;
        Tic_Tak_Toe.Resources.HomePage HomePageReff;
        Tic_Tak_Toe.Builders.Array Builder;
        NavigationHomePage UserInput;
       

        GameChoice[] GameReff = new GameChoice[3];
        PlayersChoice[] PlayersReff = new PlayersChoice[3];
        
        
        private int GameIndex = 0;
        private int PlayersIndex = 0;

        public int[] PageIndex = new int[2];

        int[] GameLocation;

        bool CloseApplication;

        public HomePage(int[] gameLocation)
        {
            GameLocation = gameLocation;
          
            StartGame = new HomePageLogic(GameLocation);
            HomePageReff = new Tic_Tak_Toe.Resources.HomePage();
            Builder = new Tic_Tak_Toe.Builders.Array();
            UserInput = new NavigationHomePage();

            CloseApplication = false;
        }

        public bool ApplicationLoop()
        {

            while(!CloseApplication) { OpenHomePage(); }

            return CloseApplication;
        }
        public void OpenHomePage()
        {
            //51,1
            GameReff[0] = new GameChoice(0, "+ Tic Tak Toe +", GameLocation[0], GameLocation[1]+7);
            GameReff[1] = new GameChoice(1, "+ Super Triple T +", GameLocation[0]-1, GameLocation[1]+7);
            GameReff[2] = new GameChoice(2,"+ Close Program +", GameLocation[0] - 1, GameLocation[1] + 7);

            PlayersReff[0] = new PlayersChoice(0, " P.V.P ", GameLocation[0]+4, GameLocation[1]+10);
            PlayersReff[1] = new PlayersChoice(1, " P.V.C ", GameLocation[0]+4, GameLocation[1]+10);
            PlayersReff[2] = new PlayersChoice(2, " C.V.C ", GameLocation[0]+4, GameLocation[1]+10);

            RenderScreen();
            int[] GameSelection = GameSelectionLoop();
            CloseApplication = StartGame.RunHomePageLogic(GameSelection);
        }

        private int[] GameSelectionLoop()
        {
            
            int[] PageReff = PageReffBuilder(GameIndex,PlayersIndex);
            ConsoleKey Input = ConsoleKey.A;

            while (Input != ConsoleKey.Enter)
            {
                Input = UserInput.GetInput();
                int[] ReffData = new int[2]; 
                ReffData = UserInput.NavagatePage(Input,PageReff);

                

                PageReff[0] = LoopArrayCheckInt(GameReff.Length, ReffData[0]);
                PageReff[1] = LoopArrayCheckInt(PlayersReff.Length, ReffData[1]);
    
                GameIndex = PageReff[0];
                PlayersIndex = PageReff[1];
               
                ClearChoicesRended();
                RenderGameChoice();
                if (PageReff[0] != 2) { RenderPlayersChoice(); }
                
              
            }
           
            // PageReff = PageReffBuilder(GameIndex, PlayersIndex);
           
            return PageReff;
        }
        
        private int[] PageReffBuilder(int GameIndex, int PlayersIndex)
        { int[] PageReff = new int[2] {GameIndex,PlayersIndex};return PageReff; } 
        private int LoopArrayCheckInt(int ArrayLength, int ArrayReff)
        { 
            if(ArrayReff< 0) { ArrayReff = ArrayLength -1; }
            if(ArrayReff> ArrayLength-1) {  ArrayReff = 0;}
            return ArrayReff;
        }
        private void RenderBorder()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Builder.DrawArray(HomePageReff.HomePageBorder, GameLocation[0] - 11, GameLocation[1]+1);
            Console.ResetColor();
        }
        private void RenderInstruction()
        { 
            Console.ForegroundColor= ConsoleColor.DarkGray;
            Builder.DrawArray(HomePageReff.HomePageInstructions, GameLocation[0]-11, GameLocation[1]+17);
            Console.ResetColor();
        }
        private void RenderGameChoice()
        {
            Console.ForegroundColor=( ConsoleColor.DarkGray );

            Console.SetCursorPosition(GameReff[GameIndex].WrightLineX, GameReff[GameIndex].WrightLineY);
            Console.WriteLine(GameReff[GameIndex].GameName);
            
            Console.ResetColor();
        }
        private void ClearChoicesRended()
        {
            Console.SetCursorPosition(GameLocation[0]-2, GameLocation[1]+7);
            Console.WriteLine("                    ");
        
            Console.SetCursorPosition(GameLocation[0] + 3, GameLocation[1] + 10);
            Console.WriteLine("       ");
        
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
