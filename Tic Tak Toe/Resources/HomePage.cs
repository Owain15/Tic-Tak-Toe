﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tak_Toe.Resources
{
    internal class HomePage
    {
        public string[,] HomePageBorder = 
        {
          {"X","O","-","-","-","-","X","O","-","-","-","-","X","O","-","-","-","-","X","O","-","-","-","-","X","O","-","-","-","-","X","O","-","-","-","-","X","O" },
          {"O","X","-","-","-","-","O","X","-","-","-","-","O","X","-","-","-","-","O","X","-","-","-","-","O","X","-","-","-","-","O","X","-","-","-","-","O","X" },
          {"|","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","/","\\"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","|","|" },
          {"|","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","|","|" },
          {"|","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","|","|" },
          {"|","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","|","|" },
          {"X","O","/"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","\\","X","O" },
          {"O","X","\\"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","/","O","X" },
          {"|","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","|","|" },
          {"|","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","|","|" },
          {"|","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","|","|" },
          {"|","|"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","","\\","/",""," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","|","|" },
          {"X","O","-","-","-","-","X","O","-","-","-","-","X","O","-","-","-","-","X","O","-","-","-","-","X","O","-","-","-","-","X","O","-","-","-","-","X","O" },
          {"O","X","-","-","-","-","O","X","-","-","-","-","O","X","-","-","-","-","O","X","-","-","-","-","O","X","-","-","-","-","X","O","-","-","-","-","X","O" },
         
        };

        public string[,] HomePageInstructions =
        {
            {"Instructions. " },
            {""},
            {"Use The Arrow Key To Choose Your Game." },
            {"Press Enter To Begin." }
        };
    }
}