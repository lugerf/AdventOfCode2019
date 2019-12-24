using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Day4
{
    static class StaticHelper
    {
        #region Helpers
        /// <summary>
        /// Checks if an input code has digits which are the same and are next to each other. Returns a boolean value.
        /// </summary>
        /// <param name="codeToCheck"></param>
        /// <returns></returns>
        public static bool AdjacentNumbersInCode(string codeToCheck)
        {
            bool result = false;
            char lastDigit = new char();

            for (int i = 0; i < codeToCheck.Length; i++)
            {
                if (codeToCheck[i] == lastDigit)
                {
                    result = true;
                }
                lastDigit = codeToCheck[i];
            }

            return result;
        }

        /// <summary>
        /// Checks if an input code has only increasing digits from left to right. Returns a boolean value. 
        /// </summary>
        /// <param name="codeToCheck"></param>
        /// <returns></returns>
        public static bool AllDigitsDoIncrease(string codeToCheck)
        {
            bool result = true;
            char lastDigit = new char();

            for (int i = 0; i < codeToCheck.Length; i++)
            {
                if (codeToCheck[i] >= lastDigit)
                {
                    // result still true
                }
                else
                {
                    // criteria not met
                    result = false;
                }
                lastDigit = codeToCheck[i];
            }
            return result;
        }
        #endregion
    }
}
