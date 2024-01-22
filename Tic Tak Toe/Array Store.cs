﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tak_Toe
{
    internal class ArrayStore
    {
        string[,] Empty =
        {   { "#","-","#", },
            { "|"," ","|", },
            { "#","-","#", }
        };
        string[,] O =
        {
            { "#","-","#", },
            { "|","0","|", },
            { "#","-","#", }
        };
        string[,] X =
        {   { "#","-","#", },
            { "|","X","|", },
            { "#","-","#", }
        };
        string[,] Header =
        {
           { "#","-","-","-","-","-","-","-","-","-","#","-","-","-","-","-","-","-","-","-","#" },
           { "|","P","l","a","y","e","r",".","X"," ","|","P","l","a","y","e","r",".","O"," ","|" },
           { "|","s","c","o","r","e"," "," "," "," ","|","s","c","o","r","e"," "," "," "," ","|" },
           { "#","-","-","-","-","-","-","-","-","-","#","-","-","-","-","-","-","-","-","-","#" }
          
        };
        string[,] Border =
      {
            { "|"," "," "," "," "," ","#","-","-","-","-","-","-","-","#"," "," "," "," "," ","|" },
            { "|"," "," "," "," "," ","|"," "," "," "," "," "," "," ","|"," "," "," "," "," ","|" },
            { "|"," "," "," "," "," ","|"," "," "," "," "," "," "," ","|"," "," "," "," "," ","|" },
            { "|"," "," "," "," "," ","|"," "," "," "," "," "," "," ","|"," "," "," "," "," ","|" },
            { "|"," "," "," "," "," ","|"," "," "," "," "," "," "," ","|"," "," "," "," "," ","|" },
            { "|"," "," "," "," "," ","|"," "," "," "," "," "," "," ","|"," "," "," "," "," ","|" },
            { "|"," "," "," "," "," ","|"," "," "," "," "," "," "," ","|"," "," "," "," "," ","|" },
            { "|"," "," "," "," "," ","|"," "," "," "," "," "," "," ","|"," "," "," "," "," ","|" },
            { "|"," "," "," "," "," ","#","-","-","-","-","-","-","-","#"," "," "," "," "," ","|" }

        };
        public string[,] Footer =
        {
            { "#","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","#" },
            { "|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","|" },
            { "#","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","-","#" }
        };

        string[,] Grid =
        {
            { "0","0","0" },
            { "0","0","0" },
            { "0","0","0" }
        };

        
        public string[,] TileEmpty()
        {

            return Empty;

        }
        public string[,] TileX()
        {

            return X;
  

        }
        public string[,] TileO()
        {

            return O;
      

        }
        public string[,] grid()
        {
            return Grid;
        }
        public string[,] header()
        { return Header;}
        public string[,] border()
        { return Border; }
        public string[,] footer() 
        { return Footer;}

    }
}