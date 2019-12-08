using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfcodeDay2
{
    public class IntcodeComputer
    {
        #region Declarations
        // Constants
        int OPERATIONRANGE = 4;
        // Properties
        public IntCode Code {get; set;}
        // Variables
        #endregion

        #region Init
        public IntcodeComputer(List<int> input)
        {
            Code = new IntCode(input, OPERATIONRANGE);
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
    }
}
