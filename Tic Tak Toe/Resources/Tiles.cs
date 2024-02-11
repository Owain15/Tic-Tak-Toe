using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tak_Toe.Resources
{
    internal class Tiles
    {
        public string[,] Empty =
       {   { "#","-","#", },
           { "|"," ","|", },
           { "#","-","#", }
        };
        public string[,] O =
        {
            { "#","-","#", },
            { "|","0","|", },
            { "#","-","#", }
        };
        public string[,] X =
        {   { "#","-","#", },
            { "|","X","|", },
            { "#","-","#", }
        };
    }
}
