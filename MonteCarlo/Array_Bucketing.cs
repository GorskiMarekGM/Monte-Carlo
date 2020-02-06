using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    class Array_Bucketing
    {
        //Bucketing (int[]arr - Array with random values, 
        //           bucketCount - How many buckets there should be
        //           min - min value, max - max value)
        //Return 2D Array with bruckets that looks like this
        //[20, 40, 60, 80, 100] <- range is 20 in this case
        //[5 , 7 , 9 , 3 , 15 ] <- counts how many samples are in each range
        public static int[,] Buckets(int[] arr, int bucketCount, int min, int max)
        {
            int stepSize = (max - min) / (bucketCount - 1);

            int[,] arrBucket = new int[2, bucketCount];

            arrBucket[0, 0] = min;
            arrBucket[0, bucketCount - 1] = max;

            for (int i = 1; i < bucketCount - 1; i++)
            {
                arrBucket[0, i] = arrBucket[0, i - 1] + stepSize;
            }

            for (int j = 0; j < arr.Length; j++)
            {
                int col = 0;
                while (arr[j] > arrBucket[0, col])
                {
                    col++;
                }
                arrBucket[1, col]++;
            }
            return arrBucket;
        }

    }
}
