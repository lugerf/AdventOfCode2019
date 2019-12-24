using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Day3
{
    public class Wire
    {
        // Constants
        public static readonly int[] StartCoordinate = { 0, 0, 0 };

        // Class Properties
        public int[] CurrentCoordinate { get; private set; } // X, Y, Steps
        public List<int[]> WireCoordinates { get; private set; }

        #region Init
        public Wire()
        {
            // X, Y, Steps
            CurrentCoordinate = new int[] { 0, 0, 0 };
            WireCoordinates = new List<int[]>();
        }
        #endregion

        #region Processing
        /// <summary>
        /// Calculates a range of coordinates based on the input commands
        /// </summary>
        /// <param name="input"></param>
        public void CalculateWireCoordinates(string input)
        {
            // Parse
            Tuple<string, int> commandSet = ParseCommandInput(input);

            // Process
            switch (commandSet.Item1)
            {
                case "R":
                    for (int i = 0; i < commandSet.Item2; i++)
                    {
                        IncreaseXCoordinate();
                        WireCoordinates.Add(CurrentCoordinate.ToArray());
                    }
                    break;
                case "L":
                    for (int i = 0; i < commandSet.Item2; i++)
                    {
                        DecreaseXCoordinate();
                        WireCoordinates.Add(CurrentCoordinate.ToArray());
                    }
                    break;
                case "U":
                    for (int i = 0; i < commandSet.Item2; i++)
                    {
                        IncreaseYCoordinate();
                        WireCoordinates.Add(CurrentCoordinate.ToArray());
                    }
                    break;
                case "D":
                    for (int i = 0; i < commandSet.Item2; i++)
                    {
                        DecreaseYCoordinate();
                        WireCoordinates.Add(CurrentCoordinate.ToArray());
                    }
                    break;
                default:
                    // Should never happen
                    break;
            }
        }
        #endregion

        #region Helping Methods
        private Tuple<string, int> ParseCommandInput(string input)
        {
            // init
            string command = "";
            int length = 0;
            string pattern = @"^(?'command'[RLUD])(?'length'\d{1,4})";
            Regex regex = new Regex(pattern);

            // parsing
            GroupCollection groups = regex.Match(input).Groups;

            command = groups["command"].Value;

            int i = 0;
            if (Int32.TryParse(groups["length"].Value, out i))
            {
                length = i;
            }

            return new Tuple<string, int>(command, length);
        }

        /// <summary>
        /// Increase X coordinate + 1
        /// </summary>
        public void IncreaseXCoordinate()
        {
            // X coordinate
            CurrentCoordinate[0] = CurrentCoordinate[0] + 1;
            // Steps
            CurrentCoordinate[2] = CurrentCoordinate[2] + 1;
        }

        /// <summary>
        /// Decrease X coordinate - 1
        /// </summary>
        public void DecreaseXCoordinate()
        {
            // X-Coordinate
            CurrentCoordinate[0] = CurrentCoordinate[0] - 1;
            // Steps
            CurrentCoordinate[2] = CurrentCoordinate[2] + 1;
        }

        /// <summary>
        /// Increase Y coordinate + 1
        /// </summary>
        public void IncreaseYCoordinate()
        {
            // Y Coordinate
            CurrentCoordinate[1] = CurrentCoordinate[1] + 1;
            // Steps
            CurrentCoordinate[2] = CurrentCoordinate[2] + 1;
        }

        /// <summary>
        /// Decrease Y coordinate - 1
        /// </summary>
        public void DecreaseYCoordinate()
        {
            // Y Coordinate
            CurrentCoordinate[1] = CurrentCoordinate[1] - 1;
            // Steps
            CurrentCoordinate[2] = CurrentCoordinate[2] + 1;
        }
        #endregion
    }
}
