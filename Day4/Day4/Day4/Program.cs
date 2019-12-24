using System;
using System.Collections.Generic;

namespace Day4
{
    class Program
    {
        /// <summary>
        /// Task:
        /// For range: 372304 - 847060
        /// Get the number of passwords which:
        /// - two adjacent numbers are the same
        /// - from left to right digits never decrease
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Task 1:
            // Init
            List<int> taskOneResult = new List<int>();

            // Processing
            for (int i = 372304; i < 847060; i++)
            {
                if (StaticHelper.AdjacentNumbersInCode(i.ToString()) && StaticHelper.AllDigitsDoIncrease(i.ToString()))
                {
                    taskOneResult.Add(i);
                }
            }

            Console.WriteLine($"The number of matching codes are: {taskOneResult.Count}");
        }

       
    }
}
