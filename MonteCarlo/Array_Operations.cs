using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    class Array_Operations
    {
        //Generate random Array arguments(Size, Min Value, Max Value)
        public static int[] GenerateRandomArray(int howMany, int min, int max)
        {
            int[] randomArray = new int[howMany];

            Random randNum = new Random();
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = randNum.Next(min,max);
            }
            return randomArray;
        }

        //Calculate Average from Array(Array to calculate average)
        public static int ArrayAverage(int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum / arr.Length;
        }

        //Float percentage table about finishing plan
        public static int[,] Percentage(int[,] arr)
        {
            int length = arr.Length / 2;
            int sum = 0;

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
        public static int[,] PercentageSum(int[,] arr)
        {
            for (int i = 1; i < arr.Length / 2; i++)
            {
                arr[1, i] = arr[1, i - 1] + arr[1, i];
            }
            return arr;
        }

        //Sum values
        public static int SumArray(int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

    }
}
