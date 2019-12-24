using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfcodeDay2
{
    public class IntcodeComputer
    {
        #region Declarations
        // Constants

        // Properties
        public IntCode Code { get; set; }
        public int OperationRange {get; set;}
        // Variables
        #endregion

        #region Init
        public IntcodeComputer(List<int> input, int operationRange)
        {
            OperationRange = operationRange;
            Code = new IntCode(input, operationRange);
        }
        #endregion

        #region Main
        public void RunComputation()
        {
            while (Code.currentOperationCode != 99)
            {
                switch (Code.currentOperationCode)
                {
                    case 1:
                        Code.Add();
                        break;
                    case 2:
                        Code.Multiply();
                        break;
                    default:
                        break;
                }
                Code.MoveToNextExecutionSet();
            }
        }
        #endregion
        #region Helper
        public void ResetInput(List<int> data)
        {
            Code = new IntCode(data, OperationRange);
        }
        #endregion
    }
}
