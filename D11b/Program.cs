using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D11b
{
    class Program
    {
        static int gridSerialNumber = 8199; // input

        static void Main(string[] args)
        {
            int[,] grid = new int[301, 301]; // rows, cols
            int maxPower = int.MinValue, maxPowerX = -1, maxPowerY = -1, gridSize = 0;

            for (int y = 1; y <= 300; y++)
            {
                for (int x = 1; x <= 300; x++)
                {
                    int powerLevel = x + 10; // Find the fuel cell's rack ID, which is its X coordinate plus 10
                    powerLevel *= y; // Begin with a power level of the rack ID times the Y coordinate
                    powerLevel += gridSerialNumber; // Increase the power level by the value of the grid serial number
                    powerLevel *= x + 10; // Set the power level to itself multiplied by the rack ID
                    powerLevel = (powerLevel / 100) % 10; // Keep only the hundreds digit of the power level
                    powerLevel -= 5; // Subtract 5 from the power level

                    // Partial sums -> https://en.wikipedia.org/wiki/Summed-area_table
                    grid[y, x] = powerLevel + grid[y - 1, x] + grid[y, x - 1] - grid[y - 1, x - 1];
                }
            }

            for (int gSize = 1; gSize <= 300; gSize++)
            {
                for (int y = gSize; y <= 300; y++)
                {
                    for (int x = gSize; x <= 300; x++)
                    {
                        int totalPower = grid[y, x] - grid[y - gSize, x] - grid[y, x - gSize] + grid[y - gSize, x - gSize];
                        if (totalPower > maxPower)
                        {
                            maxPower = totalPower;
                            maxPowerX = x;
                            maxPowerY = y;
                            gridSize = gSize;
                        }
                    }
                }
            }
            maxPowerX += -gridSize + 1;
            maxPowerY += -gridSize + 1;

            Console.WriteLine("X,Y = " + maxPowerX.ToString() + "," + maxPowerY.ToString() + "," + gridSize.ToString());
            Console.ReadLine();
        }

    }

}
