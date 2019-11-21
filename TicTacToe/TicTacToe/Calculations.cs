using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Calculations
    {

        public int P1NumTurns;
        public int P2NumTurns;
        public int NumRows = 3;
        public bool GameOver;
        public int[,] board;

        //public static void StartUp()
        /// <summary>StartUp Procedure. 
        /// sets up variables for game
        /// </summary>
        public void StartUp()
        {
            // set num turns to 0
            P1NumTurns = 0;
            P2NumTurns = 0;
            
            // set GameOver flag to false
            GameOver = false;
            
            // initialize board and set values to 0
            board = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = 0;
                }
            }
        }

        /// Restart
        /// <summary>
        /// resets all variables for a new game
        /// </summary>
        public void Restart()
        {
            // set num turns to 0
            P1NumTurns = 0;
            P2NumTurns = 0;

            // set GameOver flag to false
            GameOver = false;

            // initialize board and set values to 0
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = 0;
                }
            }
        }

        /// CheckColumns
        /// <summary>
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool CheckColumns(int[,] arr)
        {
            bool flag = false;
            for (int i = 0; i < 3; i++)
            {
                if((arr[0,i] == arr[1,i])&(arr[1, i] == arr[2, i])&((arr[0,i] + arr[1,i] + arr[2,i]) != 0))
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// CheckRows
        /// <summary></summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool CheckRows(int[,] arr)
        {
            bool flag = false;
            for (int i = 0; i < 3; i++)
            {
                if ((arr[i, 0] == arr[i, 1]) & (arr[i, 1] == arr[i, 2]) & ((arr[i, 0] + arr[i, 1] + arr[i, 2]) != 0))
                {
                    flag = true;
                }
            }
            return flag;
        }
        
        /// CheckDiagonals
        /// <summary>
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool CheckDiagonals(int[,] arr)
        {
            bool flag = false;
            if ((arr[0, 0] == arr[1, 1]) & (arr[1, 1] == arr[2, 2]) & ((arr[0, 0] + arr[1, 1] + arr[2, 2]) != 0))
            {
                flag = true;
            }
            if ((arr[2, 0] == arr[1, 1]) & (arr[1, 1] == arr[0, 2]) & ((arr[2, 0] + arr[1, 1] + arr[0, 2]) != 0))
            {
                flag = true;
            }
            return flag;
        }



        /// Testing
        /// <summary>Used for testing different functions in Calculations class</summary>
        public void Testing()
        {
            int[,] intArray = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    intArray[i, j] = 0;
                }
            }
            bool flag1;

            flag1 = false;
            flag1 = CheckColumns(intArray);
            Console.WriteLine("Testing False Cols {0}", flag1); //Should return False

            flag1 = false;
            flag1 = CheckRows(intArray);
            Console.WriteLine("Testing False Rows {0}", flag1); //Should return False

            flag1 = false;
            flag1 = CheckDiagonals(intArray);
            Console.WriteLine("Testing False Diag {0}", flag1); //Should return False

            intArray[0, 0] = 1;
            intArray[0, 1] = 1;
            intArray[0, 2] = 1;
            intArray[1, 1] = 1;
            intArray[1, 2] = 1;
            intArray[2, 2] = 1;

            flag1 = false;
            flag1 = CheckColumns(intArray);
            Console.WriteLine("Testing True Cols {0}", flag1); //Should return True

            flag1 = false;
            flag1 = CheckRows(intArray);
            Console.WriteLine("Testing True Rows {0}", flag1); //Should return True

            flag1 = false;
            flag1 = CheckDiagonals(intArray);
            Console.WriteLine("Testing True Diag {0}", flag1); //Should return True

            intArray[0, 1] = 2;
            intArray[1, 1] = 2;
            intArray[1, 2] = 2;
            flag1 = false;
            flag1 = CheckColumns(intArray);
            Console.WriteLine("Testing FalseV2 Cols {0}", flag1); //Should return False

            flag1 = false;
            flag1 = CheckRows(intArray);
            Console.WriteLine("Testing FalseV2 Rows {0}", flag1); //Should return False

            flag1 = false;
            flag1 = CheckDiagonals(intArray);
            Console.WriteLine("Testing FalseV2 Diag {0}", flag1); //Should return False
        }
    }



}
