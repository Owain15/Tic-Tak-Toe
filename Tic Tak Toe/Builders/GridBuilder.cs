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
    internal class GridClass
    {

        int[] GameLocation;

        Array Builder;
        GameLogicClass TileSelector;

        public GridClass(int[] gameLocation)
        {
            GameLocation = gameLocation;

            Builder = new Array();
           
            TileSelector = new GameLogicClass(GameLocation);

        }

        public void TileBuilder(int TileDisplamentX, int TileDisplamentY, int TileIndex)
        { Builder.DrawBoredTile(TileIndex ,0 + TileDisplamentX, 0 + TileDisplamentY, GameLocation); }

        public void GridBuilderLoop(int GridDisplasmentX, int GridDisplasmentY, int[] GameBoredIndex)
        {

            // for (int Tile = 0; TileIndex < .Length; TileIndex++)
            //{
            
            
            TileBuilder(0 + GridDisplasmentX, 0 + GridDisplasmentY, GameBoredIndex[0]);
            TileBuilder(3 + GridDisplasmentX, 0 + GridDisplasmentY, GameBoredIndex[1]);
            TileBuilder(6 + GridDisplasmentX, 0 + GridDisplasmentY, GameBoredIndex[2]);
            TileBuilder(0 + GridDisplasmentX, 3 + GridDisplasmentY, GameBoredIndex[3]);
            TileBuilder(3 + GridDisplasmentX, 3 + GridDisplasmentY, GameBoredIndex[4]);
            TileBuilder(6 + GridDisplasmentX, 3 + GridDisplasmentY, GameBoredIndex[5]);
            TileBuilder(0 + GridDisplasmentX, 6 + GridDisplasmentY, GameBoredIndex[6]);
            TileBuilder(3 + GridDisplasmentX, 6 + GridDisplasmentY, GameBoredIndex[7]);
            TileBuilder(6 + GridDisplasmentX, 6 + GridDisplasmentY, GameBoredIndex[8]);
            

            //}
        }


    }
}
