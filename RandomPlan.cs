using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    static class RandomPlan
    {
        static private int[] estimation;
        
        private static void setEstimation(int col)
        {
            estimation = new int[col];
        }

        public static void GenerateRandomPlan(int n,int[,] arr)
        {
            Random randNum = new Random();
            setEstimation(n);

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    int random = randNum.Next(0, arr.GetLength(1));
                    estimation[j] += arr[i, random];
                }
            }
        }

        public static void estimationDisplay()
        {
            foreach (var item in estimation)
            {
                Console.WriteLine("Estimated:" + item);
            }
        }
    }
}
