namespace Tic_Tak_Toe
{
    internal class GameClass
    {
        public int[] T1 = [56, 4];
        public int[] T2 = [59, 4];
        public int[] T3 = [62, 4];

        public int[] T4 = [56, 7];
        public int[] T5 = [59, 7];
        public int[] T6 = [62, 7];

        public int[] T7 = [56, 10];
        public int[] T8 = [59, 10];
        public int[] T9 = [62, 10];
        public int[] PlayerLocations;

        public void Game()
        {

            PageClass Window = new PageClass();
            GridClass Grid = new GridClass();
            var PlayerX = new PlayerClass(1);
            PlayerClass PlayerO = new PlayerClass(2);
            Navigation CurretMove = new Navigation();


            while (CurretMove.MoveMade() == true)
            {
                Window.PageBuilder();
                Grid.GridBuilder(56, 4);
                PlayerX.Draw(-1, T8);

                Console.Read();
            }


        }



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

    }

    internal class PlayerClass
    {
        public int TileIndex;
        public int[,] PlayerLocation;

        public PlayerClass(int playerIndex)
        {
            TileIndex = playerIndex;

        }


        public void Draw(int PlayerIndex, int[] PlayerLocation)
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
                    Console.SetCursorPosition(x + PlayerLocation[0], y + PlayerLocation[1]);
                    Console.WriteLine(pixle);

                }

            }

        }

    }

    internal class Navigation
    {

        public int PlayerIndex;
        public int[] PlayerLocation;


        public void MovePlayer(int PlayerIndex, int[] PlayerLocation)
        {
            GameClass Location = new GameClass();
            int[] T1 = [53, 4];


            ConsoleKey Direction;

            ConsoleKeyInfo KeyPressed = Console.ReadKey(true);
            Direction = KeyPressed.Key;
            //  switch (PlayerLocation[0], PlayerLocation[1])
            ////  {
            //     // case (int Location.T1[0], Location.T1[1]): 
            //      {
            //              return;
            //      }

            //  }



        }
        public bool MoveMade()
        {

            return true;
        }

    }


}
