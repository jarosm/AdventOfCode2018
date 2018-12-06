using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D6b
{
    class Program
    {
        public class Coordinate
        {
            public int left;
            public int top;

            public Coordinate(int _left, int _top)
            {
                left = _left;
                top = _top;
            }
        }

        static void Main(string[] args)
        {
            List<Coordinate> coordinates = new List<Coordinate>();
            int width = 0, height = 0;
            using (StreamReader input = File.OpenText("d:\\programming\\Advent of Code\\data\\D6a\\input.txt"))
            {
                string line = "";
                while ((line = input.ReadLine()) != null)
                {
                    string[] c = line.Split(',');
                    Coordinate coord = new Coordinate(Convert.ToInt32(c[0]), Convert.ToInt32(c[1].Substring(1)));
                    width = Math.Max(width, coord.left);
                    height = Math.Max(height, coord.top);
                    coordinates.Add(coord);
                }
            }

            int[,] grid = new int[width + 1, height + 1];
            for (int i = 0; i < coordinates.Count; i++)
            {
                Coordinate coord = coordinates[i];
                for (int row = 0; row <= height; row++)
                {
                    for (int col = 0; col <= width; col++)
                    {
                        int dist = Math.Abs(coord.left - col) + Math.Abs(coord.top - row);
                        grid[col, row] += dist;
                    }
                }
            }

            int result = 0;
            for (int row = 0; row <= height; row++)
            {
                for (int col = 0; col <= width; col++)
                {
                    if (grid[col, row] < 10000)
                        result++;
                }
            }

            Console.WriteLine(result.ToString());
            Console.ReadLine();

        }

    }

}
