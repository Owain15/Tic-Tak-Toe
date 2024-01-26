using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace Tic_Tak_Toe
{
    internal class GameClass
    {
        public int[,] GridReff = new int[,] { { 56, 4 }, { 59, 4 }, { 62, 4 }, { 56, 7 }, { 59, 7 }, { 62, 7 }, { 56, 10 }, { 59, 10 }, { 62, 10 } };
        // Grid Reff : T1=[0], T2=[1],T3=[2],T4=[3],T5=[4],T6=[5],T7=[6],T8=[7],T9=[8],
        
        //public int[] GridX = new int[3] { 56, 59, 62 };
        //public int[] GridY = new int[3] { 4, 7, 10 };

        //int[] Grid = [T1,T2,T3,T4,T5,T6,T7,T8,T9];

        public int[] T1 = [56, 4];
        public int[] T2 = [59, 4];
        public int[] T3 = [62, 4];

        public int[] T4 = [56, 7];
        public int[] T5 = [59, 7];
        public int[] T6 = [62, 7];

        public int[] T7 = [56, 10];
        public int[] T8 = [59, 10];
        public int[] T9 = [62, 10];

        public void Game()
        {

            PageClass Window = new PageClass();
            GridClass Bored = new GridClass();
            Navigation CurrentMove = new Navigation();
            PlayerClass CurrentPlayer = new PlayerClass(1);
            Render Screen = new Render(Bored,CurrentPlayer,Window);

            Screen.RenderScreen();
            Screen.RenderPlayer(CurrentPlayer.PlayerIndex, GetPlayerLocationReff(CurrentPlayer.PlayerLocationIndex));

            RunPlayerTurn();
            RunPlayerTurn();
            RunPlayerTurn();

            void RunPlayerTurn()
            {
                CurrentPlayer.PlayerLocationIndex = CurrentMove.MovePlayerLoop(Bored,CurrentPlayer,Window);
                SetToBored(CurrentPlayer.PlayerIndex, CurrentPlayer.PlayerLocationIndex);
                CurrentPlayer.PlayerIndex = SwitchPlayer(CurrentPlayer.PlayerIndex);

            }
           
            void SetToBored(int PlayerIndex, int PlayerLocationIndex)
            {
                Bored.BoredIndex.SetValue(PlayerIndex, PlayerLocationIndex); ;
            }

            int SwitchPlayer(int PlayerIndex)
            {

                if (PlayerIndex == 1)
                { PlayerIndex = -1; }
                else { PlayerIndex = 1; }

                return PlayerIndex;
            }


        }


        //public int SwitchPlayer(int PlayerIndex)
        //    {

        //    if (PlayerIndex == 1)
        //    { PlayerIndex = -1; }
        //    else { PlayerIndex = 1; }

        //    return PlayerIndex;
        //}

        public string[,] GetTile(int TileIndex)
        {
            ArrayStore Tile = new ArrayStore();

            switch (TileIndex)
            {
                case 0:
                    return Tile.TileEmpty();

                case 1:
                    return Tile.TileX();

                case -1:
                    return Tile.TileO();
            }
            return Tile.TileEmpty();
        }

        public int[] GetPlayerLocationReff(int PlayerLocationIndex)
        {
            switch (PlayerLocationIndex) 
            {
                //link to int[] Grid[], instead ofT values.

                case 0: return T1;
                case 1: return T2;
                case 2: return T3;
                case 3: return T4;
                case 4: return T5;
                case 5: return T6;
                case 6: return T7;
                case 7: return T8;
                case 8: return T9;
            }
            return T5;
        }
    }

    internal class PlayerClass
    {
        public int PlayerIndex;
        public int PlayerLocationIndex;

        public PlayerClass(int TileIndex)
        {
            PlayerIndex = TileIndex;
            PlayerLocationIndex = 4;

        }


        public void Draw(int PlayerIndex, int[] PlayerLocationReff)
        {
            int playerIndex = PlayerIndex;
            GameClass TileRef = new GameClass();
            string[,] CurrentArray = TileRef.GetTile(playerIndex);
            int Rows = CurrentArray.GetLength(0);
            int Columns = CurrentArray.GetLength(1);

            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    string pixle = CurrentArray[y, x];
                    Console.SetCursorPosition(x + PlayerLocationReff[0], y + PlayerLocationReff[1]);
                    Console.WriteLine(pixle);

                }

            }

        }

    }

    internal class Navigation
    {

        //public int PlayerIndex;
        //public int[] PlayerLocation;


        public int GetNextPlayerLocationIndexSwitch(int PlayerLocation)
        {
            GameClass Location = new GameClass();

            ConsoleKey Direction;

            ConsoleKeyInfo KeyPressed = Console.ReadKey(true);
            Direction = KeyPressed.Key;

            switch (PlayerLocation)
            {
                case 0:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.RightArrow):
                                {
                                    PlayerLocation = 1;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.DownArrow):
                                {
                                    PlayerLocation = 3;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 1:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.LeftArrow):
                                {
                                    PlayerLocation = 0;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.RightArrow):
                                {
                                    PlayerLocation = 2;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.DownArrow):
                                {
                                    PlayerLocation = 4;
                                    return PlayerLocation;
                                }

                        }
                        return PlayerLocation;
                    }
                case 2:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.LeftArrow):
                                {
                                    PlayerLocation = 1;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.DownArrow):
                                {
                                    PlayerLocation = 5;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 3:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.RightArrow):
                                {
                                    PlayerLocation = 4;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.DownArrow):
                                {
                                    PlayerLocation = 6;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.UpArrow):
                                {
                                    PlayerLocation = 0;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 4:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.RightArrow):
                                {
                                    PlayerLocation = 3;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.LeftArrow):
                                {
                                    PlayerLocation = 5;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.UpArrow):
                                {
                                    PlayerLocation = 1;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.DownArrow):
                                {
                                    PlayerLocation = 7;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 5:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.LeftArrow):
                                {
                                    PlayerLocation = 4;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.UpArrow):
                                {
                                    PlayerLocation = 2;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 6:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.RightArrow):
                                {
                                    PlayerLocation = 7;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.UpArrow):
                                {
                                    PlayerLocation = 3;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 7:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.RightArrow):
                                {
                                    PlayerLocation = 8;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.LeftArrow):
                                {
                                    PlayerLocation = 6;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.UpArrow):
                                {
                                    PlayerLocation = 4;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
                case 8:
                    {
                        switch (Direction)
                        {
                            case (ConsoleKey.LeftArrow):
                                {
                                    PlayerLocation = 7;
                                    return PlayerLocation;
                                }
                            case (ConsoleKey.UpArrow):
                                {
                                    PlayerLocation = 5;
                                    return PlayerLocation;
                                }
                        }
                        return PlayerLocation;
                    }
            }
            return PlayerLocation;
            // replace with math left right +- 1, up down +- 3. logic to keep moves in the grid.

        }

        public int GetNextPlayerLocationIndex(int PlayerLocationIndex, ConsoleKey Move)
        {

            ConsoleKey Direction = Move;
            int NextPlayerLocationIndex = PlayerLocationIndex;


            switch (Direction)
                {
                    case ConsoleKey.UpArrow:
                    {
                        NextPlayerLocationIndex = PlayerLocationIndex - 3;

                        return NextPlayerLocationIndex;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        NextPlayerLocationIndex = PlayerLocationIndex + 3;

                        return NextPlayerLocationIndex;
                    }
                    case ConsoleKey.LeftArrow:
                    {
                        NextPlayerLocationIndex = PlayerLocationIndex - 1;

                        return NextPlayerLocationIndex;
                    }
                    case ConsoleKey.RightArrow:
                    {
                        NextPlayerLocationIndex = PlayerLocationIndex + 1;

                        return NextPlayerLocationIndex;
                    }
                   

            }
                return PlayerLocationIndex;
             
        }

        public bool CheckMoveIsInBounds(int PreposedPlayerLocationIndex) 
        {
            if (PreposedPlayerLocationIndex < 0) {return false;}
        
            if (PreposedPlayerLocationIndex > 8) {return false;}
            else {return true;}
        }

        public int isMoveInBounds(int PreposedPlayerLocationIndex, int InitialPlayerLocationIndex)
        {
            bool PlayerLocationIndex;
            PlayerLocationIndex = CheckMoveIsInBounds(PreposedPlayerLocationIndex);
            if (PlayerLocationIndex == true) { return PreposedPlayerLocationIndex; }
            else { return InitialPlayerLocationIndex; }
        }

        //public int MovePlayer(GridClass bored, PlayerClass player, PageClass window, ConsoleKey Move)
        //{
        //    GridClass Bored = bored;
        //    PlayerClass Player = player;
        //    PageClass Window = window;

        //    Render Screen = new Render(Bored,Player,Window);
        //    GameClass CurrentGame = new GameClass();
        //    int CurrentPlayerPositionIndex;
            
        //    int NextPlayerLocationIndex = GetNextPlayerLocationIndex(Player.PlayerLocationIndex, Move);
        //    CurrentPlayerPositionIndex = isMoveInBounds(NextPlayerLocationIndex, Player.PlayerLocationIndex);

        //    Screen.RenderScreen();
        //    Screen.RenderPlayer(Player.PlayerIndex, CurrentGame.GetPlayerLocationReff(CurrentPlayerPositionIndex));

        //    return CurrentPlayerPositionIndex;

        //}

        public int MovePlayerLoop(GridClass bored, PlayerClass player, PageClass window)
        {
            GridClass Bored = bored;
            PlayerClass Player = player;
            PageClass Window = window;
            Render Refesh = new Render(Bored, Player, Window);
            
            int CurrentPlayerLocationIndex = Player.PlayerLocationIndex;
            ConsoleKey Move = GetInput();
           
            while (Move != ConsoleKey.Enter)
            {
                int NextPlayerLocationIndex = GetNextPlayerLocationIndex(CurrentPlayerLocationIndex, Move);
                CurrentPlayerLocationIndex = isMoveInBounds(NextPlayerLocationIndex, Player.PlayerLocationIndex);
                
                Refesh.RenderScreen();
                Refesh.RenderPlayer(Player.PlayerIndex,GetPlayerLocationReff(CurrentPlayerLocationIndex));
   
                Move = GetInput();
            }
            return CurrentPlayerLocationIndex;
        }

        public ConsoleKey GetInput() 
        {
           
            ConsoleKey Input;
           
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Input = keyInfo.Key;
            } while (Console.KeyAvailable);
            return Input;
        }

        public int[] GetPlayerLocationReff(int PlayerLocationIndex)
        {
           int[] T1 = [56, 4];
           int[] T2 = [59, 4];
           int[] T3 = [62, 4];

           int[] T4 = [56, 7];
           int[] T5 = [59, 7];
           int[] T6 = [62, 7];

           int[] T7 = [56, 10];
           int[] T8 = [59, 10];
           int[] T9 = [62, 10];
          
            switch (PlayerLocationIndex)
            {
                

                case 0: return T1;
                case 1: return T2;
                case 2: return T3;
                case 3: return T4;
                case 4: return T5;
                case 5: return T6;
                case 6: return T7;
                case 7: return T8;
                case 8: return T9;
            }
            return T5;
        }



    }


}
