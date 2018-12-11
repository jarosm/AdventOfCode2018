using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D11a
{
    class Program
    {
        static int gridSerialNumber = 8199; // input

        static void Main(string[] args)
        {
            int[,] grid = new int[300, 300]; // rows, cols
            int maxPower = int.MinValue, maxPowerX = -1, maxPowerY = -1;

            for (int y = 0; y < 300; y++)
            {
                for (int x = 0; x < 300; x++)
                {
                    int powerLevel = (x + 1) + 10; // Find the fuel cell's rack ID, which is its X coordinate plus 10
                    powerLevel *= y + 1; // Begin with a power level of the rack ID times the Y coordinate
                    powerLevel += gridSerialNumber; // Increase the power level by the value of the grid serial number
                    powerLevel *= (x + 1) + 10; // Set the power level to itself multiplied by the rack ID
                    powerLevel = (powerLevel / 100) % 10; // Keep only the hundreds digit of the power level
                    powerLevel -= 5; // Subtract 5 from the power level

                    // add power level to all cells in 3x3 grid
                    // save max value
                    for (int j = y; (j >= 0) && (j >= y - 2); j--)
                    {
                        for (int i = x; (i >= 0) && (i >= x - 2); i--)
                        {
                            grid[j, i] += powerLevel;

                            if ((i < 298) && (j < 298) && (grid[j, i] > maxPower))
                            {
                                maxPower = grid[j, i];
                                maxPowerX = i + 1;
                                maxPowerY = j + 1;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("X,Y = " + maxPowerX.ToString() + "," + maxPowerY.ToString() + " ; " + maxPower.ToString());
            Console.ReadLine();
        }

    }

}
