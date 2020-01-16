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

        //Calculate Average from Array
        static int ArrayAverage(int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum/arr.Length;
        }

        //Bucketing
        static int[,] Buckets(int []arr,int bucketCount, int min, int max)
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

        //Float percentage table
        static float[] Percentage(int[,]arr)
        {
            int length = arr.Length / 2;
            float[] randomArray = new float[length];
            int sum=0;

            for (int i = 0; i < length - 1; i++)
            {
                sum += arr[1, i];
            }

            for (int j = 0; j < length; j++)
            {
                randomArray[j] = (arr[1, j] * 100) / sum;
            }

            return randomArray;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Provide 3 tasks");
            Console.WriteLine("Task1 |Best Scenario| Average | Worst scenario");

            int worst=0, best=0, average=0, examples=100, range = 15;
            string line;
            string[] numbers;
            int[,] intNumbers = new int[3,3];
            int[,] rangeMatrix = new int[2,range];

            for (int i=0; i<3; i++)
            {
                Console.WriteLine($"Task {i+1}: ");
                line = Console.ReadLine();
                numbers = line.Split(' ');
                int j = 0;
                foreach (string s in numbers)
                {
                    int a = Convert.ToInt32(s);
                    intNumbers[i, j] = a;
                    j++;
                }
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

            rangeMatrix = Buckets(inum, range, best, worst);

            Console.WriteLine("Random Array: ");

            foreach (int s in Percentage(rangeMatrix))
            {
                Console.Write(s + ", ");
            }
            Console.WriteLine();
        }
    }
}
