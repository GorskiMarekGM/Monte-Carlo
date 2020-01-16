using System;

namespace MonteCarlo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide 3 tasks");
            Console.WriteLine("Task |Best Scenario| Average | Worst scenario");

            int worst = 0, best = 0, average = 0, examples = 13;
            
            //Set range of bruckets
            int range = 5;

            int[,] intNumbers = Menu.MainMenu();
            int[,] rangeMatrix = new int[2,range];

            for (int i=0; i<intNumbers.GetLength(0); i++)
            {
                best += intNumbers[i,0];
                average += intNumbers[i,1];
                worst += intNumbers[i,2];
            }

            examples = Display.SetExamples();

            //Monte Carlo
            int[] inum = Array_Operations.GenerateRandomArray(examples, best, worst);

            average = Array_Operations.ArrayAverage(inum);

            Display.DisplayResults(best, worst, average, examples);

            Display.DisplayMatrix(intNumbers, intNumbers.GetLength(0), intNumbers.GetLength(1));

            //Display array of random numbers
            /* foreach (int s in inum)
            {
                Console.Write(s+ ", ");
            }
            Console.WriteLine();*/

            rangeMatrix = Array_Bucketing.Buckets(inum, range, best, worst);

           // Console.WriteLine("Ranges: ");
           // Display.DisplayMatrix(rangeMatrix, 2, range);


            Console.WriteLine("Probability of finishing the plan in: ");
            Display.DisplayProbability(Array_Operations.Percentage(rangeMatrix), range);

            Console.WriteLine("Accumulated probability of finishing the plan in or before: ");
            Display.DisplayProbability(Array_Operations.PercentageSum(Array_Operations.Percentage(rangeMatrix)), range);
            
        }
    }
}
