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

        //Display results
        public static void DisplayResults(int best, int worst, int average, int examples)
        {
            Console.WriteLine($"After probing {examples} random plans, the results are: ");
            Console.WriteLine("Minimum: " + best);
            Console.WriteLine("Maximum: " + worst);
            Console.WriteLine("Average: " + average);
        }

        //Display examples menu
        public static int SetExamples()
        {
            Console.WriteLine("How many random planes do you want to generate?");
            int examples;
            while (!int.TryParse(Console.ReadLine(), out examples))
            {
                Console.WriteLine("Wrong number, try again");
            }
            return examples;
        }
    }
}
