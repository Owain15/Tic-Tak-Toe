using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tak_Toe
{
    internal class PageClass
    {
        int PlayerXScore;
        int PlayerOScore;

        string[,] Header;
        string[,] Border;
        string[,] Footer;

        public void PageBuilder()
        {

            HeaderBuilder();

            BorderBuilder();

            FooterBuilder();
        }


        public void HeaderBuilder()
        {
            ArrayStore HeaderRef = new ArrayStore();
            Array Header = new Array();

            Header.ArrayBuilder(HeaderRef.header());
            Header.DrawArray(50, 0);
           
        }
        public int GetHeaderRows()
        {
            Array Build = new Array();
            ArrayStore HeadarRef = new ArrayStore();
            Build.ArrayBuilder(HeadarRef.header());

            return Build.GetRows();

        }
        public int GetHeaderColums()
        {
            Array Build = new Array();
            ArrayStore HeadarRef = new ArrayStore();
            Build.ArrayBuilder(HeadarRef.header());

            return Build.GetColumns();
        }


        public void BorderBuilder()
        {
            ArrayStore BorderRef = new ArrayStore();
            Array Build = new Array();

            Build.ArrayBuilder(BorderRef.border());

            Build.DrawArray(50, GetHeaderRows());

        }
        public int GetBorderRows()
        {
            Array Build = new Array();
            ArrayStore BorderRef = new ArrayStore();
            Build.ArrayBuilder(BorderRef.border());

            return Build.GetRows();

        }
        public int GetBorderColums()
        {
            Array Build = new Array();
            ArrayStore BorderRef = new ArrayStore();
            Build.ArrayBuilder(BorderRef.border());

            return Build.GetColumns();
        }

        public void FooterBuilder()
        {
            ArrayStore FooterRef = new ArrayStore();
            Array Build = new Array();

            Build.ArrayBuilder(FooterRef.footer());

            Build.DrawArray(50, GetHeaderRows() + GetBorderRows());

        }

    }
    internal class GridClass

    {
        Array Tile = new Array();
        GameClass TileSelector = new GameClass();

        public void TileBuilder(int TileDisplamentX, int TileDisplamentY, int TileIndex)
        {
         
            Tile.ArrayBuilder(TileSelector.GetTile(TileIndex));
            Tile.DrawArray(0 + TileDisplamentX, 0 + TileDisplamentY);

        }
       
        private int[] boredIndex = new int[9]{ 0,0,0,0,0,0,0,0,0 };
        public int[] BoredIndex 
        {
            
            get { return boredIndex; }
            set { BoredIndex = value; }
        }

         

        public void GridBuilder(int GridDisplasmentX, int GridDisplasmentY)
        {
            int TileIndex1 = 0;
            int TileIndex2 = 0;
            int TileIndex3 = 0;

            int TileIndex4 = 0;
            int TileIndex5 = 0;
            int TileIndex6 = 0;

            int TileIndex7 = 0;
            int TileIndex8 = 0;
            int TileIndex9 = 0;

            TileBuilder(0 + GridDisplasmentX, 0 + GridDisplasmentY, TileIndex1);
            TileBuilder(3 + GridDisplasmentX, 0 + GridDisplasmentY, TileIndex2);
            TileBuilder(6 + GridDisplasmentX, 0 + GridDisplasmentY, TileIndex3);
            TileBuilder(0 + GridDisplasmentX, 3 + GridDisplasmentY, TileIndex4);
            TileBuilder(3 + GridDisplasmentX, 3 + GridDisplasmentY, TileIndex5);
            TileBuilder(6 + GridDisplasmentX, 3 + GridDisplasmentY, TileIndex6);
            TileBuilder(0 + GridDisplasmentX, 6 + GridDisplasmentY, TileIndex7);
            TileBuilder(3 + GridDisplasmentX, 6 + GridDisplasmentY, TileIndex8);
            TileBuilder(6 + GridDisplasmentX, 6 + GridDisplasmentY, TileIndex9);

        }

        public void GridBuilderLoop(int GridDisplasmentX, int GridDisplasmentY)
        {
            
           // for (int Tile = 0; TileIndex < .Length; TileIndex++)
            //{
                TileBuilder(0 + GridDisplasmentX, 0 + GridDisplasmentY, boredIndex[0]);
                TileBuilder(3 + GridDisplasmentX, 0 + GridDisplasmentY, boredIndex[1]);
                TileBuilder(6 + GridDisplasmentX, 0 + GridDisplasmentY, boredIndex[2]);
                TileBuilder(0 + GridDisplasmentX, 3 + GridDisplasmentY, boredIndex[3]);
                TileBuilder(3 + GridDisplasmentX, 3 + GridDisplasmentY, boredIndex[4]);
                TileBuilder(6 + GridDisplasmentX, 3 + GridDisplasmentY, boredIndex[5]);
                TileBuilder(0 + GridDisplasmentX, 6 + GridDisplasmentY, boredIndex[6]);
                TileBuilder(3 + GridDisplasmentX, 6 + GridDisplasmentY, boredIndex[7]);
                TileBuilder(6 + GridDisplasmentX, 6 + GridDisplasmentY, boredIndex[8]);


            //}
        }


    }

    
    internal class testGrid
    {

        ArrayStore Tile = new ArrayStore();
        
        private int TileIndex;

        string[,] Grid; 
        int Rows;
        int Columns;

        public void GridBuilder()
        {
            Array Tile = new Array();
            GameClass tile = new GameClass();

            Grid = tile.GetTile(0);
            Rows = Grid.GetLength(0);   
            Columns = Grid.GetLength(1);


        }

       
        public void DrawGrid()
        {
            GridBuilder();
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    // set to wright tile acording to Tile index, 

                    string TileOne = Grid[y, x];
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(TileOne);

                    string TileTwo = Grid[y, x];
                    Console.SetCursorPosition(x+3, y);
                    Console.WriteLine(TileTwo);

                    string TileThree = Grid[y, x];
                    Console.SetCursorPosition(x + 6, y);
                    Console.WriteLine(TileThree);

                    string TileFour = Grid[y, x];
                    Console.SetCursorPosition(x, y + 3);
                    Console.WriteLine(TileFour);

                    string TileFive = Grid[y, x];
                    Console.SetCursorPosition(x + 3, y + 3);
                    Console.WriteLine(TileFive);

                    string TileSix = Grid[y, x];
                    Console.SetCursorPosition(x + 6, y + 3);
                    Console.WriteLine(TileSix);

                    string TileSeven = Grid[y, x];
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine(TileSeven);

                    string TileEight = Grid[y, x];
                    Console.SetCursorPosition(x + 3, y + 6);
                    Console.WriteLine(TileEight);

                    string TileNine = Grid[y, x];
                    Console.SetCursorPosition(x + 6, y + 6);
                    Console.WriteLine(TileNine);

                }

            }

        }

    }
    
    internal class Array
    {
        private string[,] CurrentArray;
        private int Rows;
        private int Columns;

        public void ArrayBuilder(string[,] array)
        {
            CurrentArray = array;
            Rows = CurrentArray.GetLength(0);
            Columns = CurrentArray.GetLength(1);

        }

        public void DrawArray(int StartX, int StartY )
        {
            ArrayBuilder(CurrentArray);

            for (int y = 0; y < Rows; y++) 
            { for (int x = 0; x < Columns; x++)
                { 
                    string pixle = CurrentArray[y,x];
                    Console.SetCursorPosition(x + StartX, y + StartY);
                    Console.WriteLine(pixle);

                }
                    
            }

        }
       
        public int GetRows()
        { return Rows; }
        public int GetColumns() 
        { return Columns;}
    
    }

    internal class Render
    {
        PageClass Window;
        GridClass Bored;
        PlayerClass Player;

        public Render(GridClass bored, PlayerClass player, PageClass window)
        {
            PageClass Window = window;
            GridClass Bored = bored;
            PlayerClass Player = player;

        }

        public void RenderScreen()
        {
            Console.Clear();
            Window.PageBuilder();
            Bored.GridBuilderLoop(56, 4);

        }
        public void RenderPlayer(int PlayerIndex, int[] PlayerLocation)
        {
            Player.Draw(PlayerIndex, PlayerLocation);
        }


    }

}
