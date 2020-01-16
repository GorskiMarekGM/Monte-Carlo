using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    class Display
    {
        //Show Matrix arguments(Matrix, Number of rows and columns)
        public static void DisplayMatrix(int[,] arr, int M, int N)
        {
            for (int row = 0; row < M; row++)
            {
                Console.Write("[");
                for (int col = 0; col < N; col++)
                {
                    Console.Write(arr[row, col] + ", ");
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }

        //Display probability in nice way(Matrix with results, number of columns)
        public static void DisplayProbability(int[,] arr, int columns)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.WriteLine($"{arr[0, col]} days: {arr[1, col]}%");
            }
        }
    }
}
