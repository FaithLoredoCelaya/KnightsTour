using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//NOTES: For some reason. The windows form format messed up with the processing. 
//If it runs on console commands it usally gives a higher and more consistant results. 
//About 40-50 in heuristc and 30 in random. Been trying to figure out why. But I cant seem to find a reason why it does that.

namespace Assingment1FaithLoredoCelaya
{
    //Inheritance
    class Knight : Piece
    {
        public Knight()
        {

        }
        //Possible move sets
        private readonly int[] observedXmov = { 2, 1, -1, -2, -2, -1, 1, 2 };
        private readonly int[] observedYmov = { 1, 2, 2, 1, -1, -2, -2, -1 };

        //Initialzing values
        private static int moveX = 0;
        private static int moveY = 0;
        private static int count = 0;
        private static int last = 0;

        //Get steps + their property. 
        private int step = 0;
        public int Step
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

        //Random movement.
        public string randomMovement(Board b, int x, int y)
        {
            //Initilaize frist movement and variables.
            step = 0;
            b.tracking(x, y, step);
            Random r = new Random();
            int newX = x;
            int newY = y;
            int count = 0;
            moveX = newX;
            moveY = newY;

            int wildCard = 0;

            //make a random move
            while (count < 64)
            {
                step++;
                count++;
                wildCard = r.Next(8);
                newX += observedXmov[wildCard];
                newY += observedYmov[wildCard];

                //Check if is valid and is on an empty space
                if (base.isAllowed(newX, newY))
                {
                    if (b.BoardArray[newX, newY] != 0)
                    {
                        //Reset move
                        step--;
                        newX = moveX;
                        newY = moveY;
                    }
                    else
                    {
                        //Make move
                        moveX = newX;
                        moveY = newY;
                        b.tracking(moveX, moveY, step);
                    }
                }
                else
                {
                    //Reset move
                    newX = moveX;
                    newY = moveY;
                    if (step > 0)
                    {
                        step--;
                    }
                }
            }
            return " The Knight was able to successfully touch " + step + " Squares";
        }

        //Check the possible values moves 
        public bool possibleValue(Board b, int v)
        {
            //Initilize necessary values
            int tempX = moveX;
            int tempY = moveY;
            Random r = new Random();

            //Check every combination until we find one that works.
            for (int i = 0; i < 20; i++)
            {
                //Give a combination possiblity
                int wildCard = 0;
                wildCard = r.Next(8);
                //If it was equal as the last move. Get a new one.
                if (wildCard == last)
                {
                    wildCard = r.Next(8);
                    count++;
                }
                last = wildCard;

                //Add up into values. 
                tempX += observedXmov[wildCard];
                tempY += observedYmov[wildCard];

                //Check if move is valid. 
                if (base.isAllowed(tempX, tempY))
                {
                    if (b.BoardArray[tempX, tempY] > 0)
                    {
                        tempX = moveX;
                        tempY = moveY;
                        return false;
                    }
                    //Check if this move will match the desired move.
                    if (b.predictiveBoardArray[tempX, tempY] == v)
                    {
                        moveX = tempX;
                        moveY = tempY;
                        return true;
                    }
                    else
                    { //Reset moves
                        tempX = moveX;
                        tempY = moveY;
                    }
                }
            }
            return false;
        }

        public bool move(Board b, int x, int y)
        {
            //Set the current value
            moveX = x;
            moveY = y;

            if (base.isAllowed(moveX, moveY))
            {
                step++;

                //Check if we got any desired value and if a move is possible
                if (possibleValue(b, 8) == true)
                {
                    b.tracking(moveX, moveY, step);
                    return true;
                }

                if (possibleValue(b, 4) == true)
                {
                    b.tracking(moveX, moveY, step);
                    return true;
                }

                if (possibleValue(b, 6) == true)
                {
                    b.tracking(moveX, moveY, step);
                    return true;
                }

                if (possibleValue(b, 3) == true)
                {
                    b.tracking(moveX, moveY, step);
                    return true;
                }

                if (possibleValue(b, 2) == true)
                {
                    b.tracking(moveX, moveY, step);
                    return true;
                }

            }
            else
            { //Else there is no possible move. 
                return false;
            }

            step--;
            return false;
        }

        //Heuristic moves 
        public string smartMovement(Board b, int x, int y)
        {
            //Initiallized values 
            step = 0;
            bool progress = false;
            b.tracking(x, y, step);
            moveX = x;
            moveY = y;

            //Check values and fill them onto the board until it fails or fills the board.
            for (int i = 0; i < 64; i++)
            {
                while (progress != true)
                {
                    progress = move(b, moveX, moveY);
                    if (count > 60)
                    {
                        break;
                    }
                }
                progress = false;
                count = 0;
            }
            //Print value.
            return " The Knight was able to successfully touch " + step + " Squares";
        }
    }
}
