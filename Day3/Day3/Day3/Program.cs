using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = @"C:\Users\lugerf\Source\Repos\AdventOfCode\Day3\Day3\Day3\Input.txt";
            // Read in input data;
            string[] input = File.ReadAllLines(inputPath);

            // Split to wire input
            string[] inputWireOne = input[0].Split(',');
            string[] inputWireTwo = input[1].Split(',');

            // Construct wires
            Wire wireOne = new Wire();
            Wire wireTwo = new Wire();


            foreach (string commandSet in inputWireOne)
            {
                wireOne.CalculateWireCoordinates(commandSet);
            }

            foreach (string commandSet in inputWireTwo)
            {
                wireTwo.CalculateWireCoordinates(commandSet);
            }

            // Get subset of all matching coordinates of wireOne and wireTwo
            List<int[]> matchingCoordinatesTaskOne = new List<int[]>();
            List<List<int[]>> matchingCoordinatesTaskTwo = new List<List<int[]>>();
            List<int[]> coordinatesWireOne = new List<int[]>();
            List<int[]> coordinatesWireTwo = new List<int[]>();
            matchingCoordinatesTaskTwo.Add(coordinatesWireOne);
            matchingCoordinatesTaskTwo.Add(coordinatesWireTwo);


            foreach (int[] wireOneCoordinate in wireOne.WireCoordinates)
            {
                foreach (int[] wireTwoCoordinate in wireTwo.WireCoordinates)
                {
                    //Console.WriteLine($"{wireOneCoordinate[0]}{wireOneCoordinate[1]}, {wireTwoCoordinate[0]}{wireTwoCoordinate[1]}");
                    if ((wireOneCoordinate[0] == wireTwoCoordinate[0]) && (wireOneCoordinate[1] == wireTwoCoordinate[1]))
                    {
                        // Task 1
                        matchingCoordinatesTaskOne.Add(wireOneCoordinate);
                        // Task 2
                        matchingCoordinatesTaskTwo[0].Add(wireOneCoordinate);
                        matchingCoordinatesTaskTwo[1].Add(wireTwoCoordinate);
                    }
                }
            }

            // Calculate task one: Manhattan distance for each potential result
            List<int> resultCoordinates = new List<int>();
            
            foreach (int[] matchedCoordinate in matchingCoordinatesTaskOne)
            {
                int result = Math.Abs(matchedCoordinate[0]) + Math.Abs(matchedCoordinate[1]);
                resultCoordinates.Add(result);
                Console.WriteLine($"{matchedCoordinate[0]} + {matchedCoordinate[1]} = {result}");
            }

            resultCoordinates.Sort();

            Console.WriteLine($"Final Result Task One: {resultCoordinates[0]}");

            // Calculate task two: Shortest distance by steps.
            foreach (List<int[]> wire in matchingCoordinatesTaskTwo)
            {
                foreach (int[] coordinate in wire)
                {
                    Console.WriteLine($"Wire {wire.ToString()}: X={coordinate[0]}, Y={coordinate[1]} in Steps={coordinate[2]}");
                }
            }
        }
    }
}
