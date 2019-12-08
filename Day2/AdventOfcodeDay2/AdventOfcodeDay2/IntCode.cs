using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfcodeDay2
{
    /// <summary>
    /// Data class for IntCode computer. Everything related to the IntCode including data operations
    /// </summary>
    public class IntCode
    {
        #region Definition
        // Constants
        int[] OPERATIONCODES = new int[] { 1, 2, 99 };
        
        // Properties
        public List<int> Code { get; private set; }
        public int RangeOfOperationSet { get; private set; }

        // Variables
        private int indexCurrentPosition;
        public int currentOperationCode;

        #endregion

        #region Init
        public IntCode(List<int> data, int rangeOfOperationSet)
        {
            Code = data;
            RangeOfOperationSet = rangeOfOperationSet;
            indexCurrentPosition = 0;
            SetOperationCode();
        }
        #endregion

        #region Helper
        /// <summary>
        /// SetOperationCode sets the operation code equal to the current position at data
        /// </summary>
        public void SetOperationCode()
        {
            int operationCode = Code[indexCurrentPosition];
            if (OPERATIONCODES.Contains(operationCode))
            {
                currentOperationCode = operationCode;
            }
            else
            {
                throw new Exception(String.Format("OperationCode is not known to the IncCode computer:", operationCode));
            }
            
        }

        /// <summary>
        /// MoveToNextExecutionSet sets current Position dependent on the current position + defined range of operation.
        /// </summary>
        public void MoveToNextExecutionSet()
        {
            indexCurrentPosition = indexCurrentPosition + RangeOfOperationSet;
            currentOperationCode = Code[indexCurrentPosition];
                    }

        /// <summary>
        /// Add() performs an addition operation of the IntCode computer
        /// </summary>
        public void Add()
        {
            int valueFirstOperand = Code[Code[indexCurrentPosition + 1]];
            int valueSecondOperand = Code[Code[indexCurrentPosition + 2]];
            int indexOutput = Code[indexCurrentPosition + 3];

            Code[indexOutput] = valueFirstOperand + valueSecondOperand; 
        }

        /// <summary>
        /// Multiply() performs a multiplication operation of the Intcode computer
        /// </summary>
        public void Multiply()
        {
            int valueFirstOperand = Code[Code[indexCurrentPosition + 1]];
            int valueSecondOperand = Code[Code[indexCurrentPosition + 2]];
            int indexOutput = Code[indexCurrentPosition + 3];

            Code[indexOutput] = valueFirstOperand * valueSecondOperand;
        }
        #endregion
    }
}
