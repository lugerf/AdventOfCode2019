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
            string PATHINPUTDATA = @"C:\Users\lugerf\Source\Repos\AdventOfCode\Day2\AdventOfcodeDay2\AdventOfcodeDay2\data\input.txt";
            int OPERATIONRANGE = 4;
            int TARGETRESULT = 19690720;

            // Properties

            // Variables
            #endregion

            #region Init
            Data InputData = new Data(PATHINPUTDATA);
            IntcodeComputer computer = new IntcodeComputer(InputData.GetDataAsList(), OPERATIONRANGE);

            // Day 2 part 1: Set to 1202 error state
            computer.Code.Code[1] = 12;
            computer.Code.Code[2] = 2;
            #endregion

            #region Main
            // Day 2 part 1
            computer.RunComputation();

            // Day 2 part 2
            Simulator sim = new Simulator(TARGETRESULT, InputData, OPERATIONRANGE);
            sim.RunSimulation();

            using (TextWriter tw = new StreamWriter("SimulationResult.txt"))
            {
                foreach (string result in sim.SimulationResults)
                {
                    tw.WriteLine(result);
                }
            }


            Console.WriteLine(string.Format("Result of day 2 part 1 is equal to: {0}", computer.Code.Code[0]));
            Console.WriteLine(string.Format("Result of day 2 part 2 is equal to: {0}, given noun = {1}, verb = {2}", (100 * sim.resultNoun + sim.resultVerb), sim.resultNoun, sim.resultVerb));

            #endregion
        }
    }
}
