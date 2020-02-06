using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    class Menu
    {
        //Main menu function, take user input, outputs 2D array
        public static int[,] MainMenu()
        {
            List<List<int>> matrix = new List<List<int>>(); //Creates new nested List
            string line;
            int iterator = 0, maxi = 0;
            string[] numbersInLine;
            Console.WriteLine("Enter equations press END to finish:");
            while (true)
            {
                Console.Write($"Task {iterator + 1}: ");
                line = Console.ReadLine();
                if (line == "END" || line == "end")
                    break;
                //delate spaces
                numbersInLine = line.Split(' ');

                matrix.Add(new List<int>()); //Adds new sub List

                for (int i = 0; i < numbersInLine.Length; i++)
                {
                    int numInput = 0;

                    while (!int.TryParse(numbersInLine[i], out numInput))
                    {
                        Console.WriteLine("Wrong number, try again");
                        line = Console.ReadLine();
                        numbersInLine = line.Split(' ');
                    }
                    matrix[iterator].Add(numInput);

                    if (i > maxi)
                        maxi = i;
                }
                iterator++;
            }
            maxi = maxi + 1;

            int[,] MatrixInt = new int[iterator, maxi];

            for (int row = 0; row < iterator; row++)
            {
                for (int col = 0; col < maxi; col++)
                {
                    MatrixInt[row, col] = 0;
                    try
                    {
                        MatrixInt[row, col] = matrix[row][col];
                    }
                    catch
                    {

                    }
                }
            }
            return MatrixInt;
        }

    }
}
