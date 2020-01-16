using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    class Program
    {
        //Show Matrix arguments(Matrix, Number of rows and columns)
        static void DisplayMatrix(int[,] arr, int M, int N)
        {
            for (int row = 0; row < M; row++)
            {
                Console.Write("[");
                for (int col = 0; col < N; col++)
                {
                    Console.Write(arr[row, col]+", ");
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }

        //Generate random Array arguments(Size, Min Value, Max Value)
        static int[] GenerateRandomArray(int howMany, int min, int max)
        {
            int[] randomArray = new int[howMany];

            Random randNum = new Random();
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = randNum.Next(min, max);
            }
            return randomArray;
        }

        //Calculate Average from Array(Array to calculate average)
        static int ArrayAverage(int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum/arr.Length;
        }

        //Bucketing (int[]arr - Array with random values, 
        //           bucketCount - How many buckets there should be
        //           min - min value, max - max value)
        //Return 2D Array with bruckets that looks like this
        //[20, 40, 60, 80, 100] <- range is 20 in this case
        //[5 , 7 , 9 , 3 , 15 ] <- counts how many samples are in each range
        static int[,] Buckets(int[]arr,int bucketCount, int min, int max)
        {
            int stepSize = (max-min) / (bucketCount-1);

            int[,] arrBucket = new int[2, bucketCount];

            arrBucket[0, 0] = min;
            arrBucket[0, bucketCount - 1] = max;

            for(int i=1; i < bucketCount-1; i++)
            {
                arrBucket[0, i] = arrBucket[0,i-1] + stepSize;
            }

            for (int j = 0; j < arr.Length; j++)
            {
                int col = 0;
                while(arr[j]>arrBucket[0,col])
                {
                    col++;
                }
                arrBucket[1, col]++;
            }
            return arrBucket;
        }

        //Float percentage table about finishing plan
        static int[,] Percentage(int[,]arr)
        {
            int length = arr.Length / 2;
            int sum=0;

            for (int i = 0; i < length; i++)
            {
                sum += arr[1, i];
            }
            for (int j = 0; j < length; j++)
            {
                arr[1, j] = (arr[1, j] * 100) / sum;
            }
            return arr;
        }

        //Changing table into sum of percentage
        static int[,] PercentageSum(int[,]arr)
        {
            for (int i = 1; i < arr.Length/2; i++)
            {
                arr[1,i] = arr[1,i - 1] + arr[1,i];
            }
            return arr;
        }

        //Display probability in nice way(Matrix with results, number of columns)
        static void DisplayProbability(int[,] arr,int columns)
        {
            for (int col = 0; col < columns; col++)
            {
                Console.WriteLine($"{arr[0,col]} days: {arr[1,col]}%");
            }
        }

        //Main menu function, take user input, outputs array
        static int[,] MainMenu()
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
            Console.WriteLine("maxi: " + maxi);
            Console.WriteLine("iterator: " + iterator);

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


        static void Main(string[] args)
        {
            Console.WriteLine("Provide 3 tasks");
            Console.WriteLine("Task1 |Best Scenario| Average | Worst scenario");

            int worst=0, best=0, average=0, examples=13, range = 5;
            string line;
            string[] numbers;
            int[,] intNumbers = MainMenu();
            int[,] rangeMatrix = new int[2,range];

            for (int i=0; i<intNumbers.GetLength(0); i++)
            {
                best += intNumbers[i,0];
                average += intNumbers[i,1];
                worst += intNumbers[i,2];
            }

            average = ArrayAverage(GenerateRandomArray(examples, best, worst));

            DisplayMatrix(intNumbers, 3,3);

            //------------
            //Monte carlo
            int[] inum = GenerateRandomArray(examples, best, worst);

            Console.WriteLine("Best: " + best);
            Console.WriteLine("Worst: " + worst);

            foreach (int s in inum)
            {
                Console.Write(s+ ", ");
            }
            Console.WriteLine();

            //Create 2D Array with bruckets that looks like this
            //[20, 40, 60, 80, 100] <- range is 20 in this case
            //[5 , 7 , 9 , 3 , 15 ] <- counts how many samples are in each range
            rangeMatrix = Buckets(inum, range, best, worst);

            Console.WriteLine("Ranges: ");
            DisplayMatrix(rangeMatrix, 2, range);


            Console.WriteLine("Probability of finishing the plan in: ");
            DisplayProbability(PercentageSum(rangeMatrix), range);

            Console.WriteLine("Accumulated probability of finishing the plan in or before: ");
            DisplayProbability(PercentageSum(Percentage(rangeMatrix)), range);
            
        }
    }
}
