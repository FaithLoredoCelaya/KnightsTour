using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment1FaithLoredoCelaya
{
    partial class Board  //This is a partial class
    {
        //Properties of the table. 
        int[,] board = new int[8, 8];
        int[,] predictiveBoard = new int[8, 8];

        public int[,] predictiveBoardArray
        {
            get
            {
                return predictiveBoard;
            }
            set
            {
                predictiveBoard = value;
            }
        }

        public int[,] BoardArray
        {
            get
            {
                return board;
            }
            set
            {
                board = value;
            }
        }

        public int step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
            }
        }

        public Board()
        {
            //Genereate an empty board.
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = 0;
                }
            }

            //Fill the board with desired paths
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((j == 0 && i == 0) || (i == 7 && j == 0) || (j == 7 && i == 0) || (j == 7 && i == 7))
                    {
                        predictiveBoardArray[i, j] = 2;
                    }
                    else if ((j == 1 && i == 0) || (j == 0 && i == 1) || (j == 1 && i == 7) || (j == 0 && i == 6) ||
                       (j == 7 && i == 6) || (j == 6 && i == 7) || (j == 0 && i == 7) || (j == 6 && i == 0))
                    {
                        predictiveBoardArray[i, j] = 3;
                    }
                    else if (((j == 1 && i == 1) || (j == 1 && i == 6)) || ((j == 6 && i == 1) || (j == 6 && i == 6)) ||
                      (j == 0 && (i > 1 && i < 7)) || (j == 7 && (i > 1 && i < 7)) || (i == 0 && (j > 1 && j < 7)) ||
                      (i == 7 && (j > 1 && j < 7)))
                    {
                        predictiveBoardArray[i, j] = 4;
                    }
                    else if ((j == 1 && (i > 1 && i < 6)) || (j == 6 && (i > 1 && i < 6)) || (i == 1 && (j > 1 && j < 6)) || (i == 6 && (j > 1 && j < 6)))
                    {
                        predictiveBoardArray[i, j] = 6;
                    }
                    else
                    {
                        predictiveBoardArray[i, j] = 8;
                    }
                }
            }

        }

        //Track movements. 
        public void tracking(int x, int y, int step)
        {
            board[x, y] = step;
        }

    }
}
