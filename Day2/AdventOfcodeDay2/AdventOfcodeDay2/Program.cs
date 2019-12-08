using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfcodeDay2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Declarations
            // Constants
            string PathInputData = @"C:\Users\lugerf\Source\Repos\AdventOfCode\Day2\AdventOfcodeDay2\AdventOfcodeDay2\data\input.txt";
            
            // Properties

            // Variables
            #endregion

            #region Init
            Data InputData = new Data(PathInputData);
            IntcodeComputer computer = new IntcodeComputer(InputData.GetDataAsList());
            // Set to 1202 error state
            computer.Code.Code[1] = 12;
            computer.Code.Code[2] = 2;
            #endregion

            #region Main
            computer.RunComputation();


            Console.WriteLine(string.Format("Result equal to: {0}", computer.Code.Code[0]));


            #endregion

        }
    }
}
