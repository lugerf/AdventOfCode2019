using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfcodeDay2
{
    class Simulator
    {
        #region Declarations
        // Constants

        // Properties
        public Data InitialCode { get; private set; }
        public int OperationRange { get; private set; }
        public IntcodeComputer Computer {get; private set;}
        public int TargetResult { get; set; }
        public int resultVerb { get; set; }
        public int resultNoun { get; set; }
        public List<string> SimulationResults { get; set; }

        // Variables
        int verbCounter;
        int nounCounter;
        #endregion

        #region Init
        public Simulator(int targetResult, Data input, int operationRange)
        {
            InitialCode = input;
            TargetResult = targetResult;
            OperationRange = operationRange;
            SimulationResults = new List<string>();
            Computer = new IntcodeComputer(InitialCode.GetDataAsList(), OperationRange);
        }
        #endregion

        #region Main
        public void RunSimulation()
        {
            for (nounCounter = 0; nounCounter < 100; nounCounter++)
            {
                for (verbCounter = 0; verbCounter < 100; verbCounter++)
                {
                    Computer.Code.Code[1] = nounCounter;
                    Computer.Code.Code[2] = verbCounter;
                    // Compute and log
                    Computer.RunComputation();
                    SimulationResults.Add(string.Format("{0}, verb={1}, noun={2}", Computer.Code.Code[0].ToString(), nounCounter, verbCounter)); //Test
                    // Compare with result
                    if (Computer.Code.Code[0] == TargetResult)
                    {
                        resultNoun = nounCounter;
                        resultVerb = verbCounter;
                        break;
                    }
                    else
                    {
                        Computer.ResetInput(InitialCode.GetDataAsList());
                    }
                }
                if (Computer.Code.Code[0] == TargetResult)
                {
                    break;
                }
            }
        }


        #endregion
    }
}
