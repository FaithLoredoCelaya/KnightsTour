using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment1FaithLoredoCelaya
{
    abstract class Piece //Abstract class for the knight class. 
    {
        //Checks the values to see if they are allowed into the board. 
        public bool isAllowed(int x, int y)
        {
            return ((x >= 0 && y >= 0) && (x < 8 && y < 8));
        }
    }
}
