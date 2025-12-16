// Program.cs
using System;

namespace CodeWithIssues
{
    class Program
    {
        static void Main(string[] args)
        {
            const string StartProgram = "Benvingut al programa de càlculs!";
            const string EndProgram = "Finalitzant el programa...";


            Console.WriteLine(StartProgram);

            int firstValue = 5, seconValue = 10, thirdValue = 15;

            int result = PositiveSum(firstValue, seconValue, thirdValue);

            Console.WriteLine(result);
            Console.WriteLine(EndProgram);
        }

        public static int PositiveSum(int firstValue, int secondValue, int thirdValue)
        {
            int sum = 1;
            return sum;
        }
    }
}