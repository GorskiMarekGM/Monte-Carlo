using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    static class RandomPlan
    {
        static public int[] estimation, worst, best;
        
        private static void setTables(int col)
        {
            estimation = new int[col];
            worst = new int[col];
            best = new int[col];
        }

        public static int[] GenerateRandomPlan(int n,int[,] arr)
        {
            Random randNum = new Random();
            setTables(n);

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    int random = randNum.Next(0, arr.GetLength(1));
                    estimation[j] += arr[i, random];
                    worst[j] += arr[i, arr.GetLength(1)-1];
                    best[j] += arr[i, 0];
                }
            }
            return estimation;
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
