using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D6a
{
    public class Coordinate
    {
        public int left;
        public int top;
        public bool finite;
        public int area;

        public Coordinate(int _left, int _top)
        {
            left = _left;
            top = _top;
            finite = true;
            area = 0;
        }
    }

    public class GridPoint
    {
        public int distance;
        public int coordIndex;

        public GridPoint(int _dist, int _index)
        {
            distance = _dist;
            coordIndex = _index;
        }
    }

    class Program
    {
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

            GridPoint[,] grid = new GridPoint[width + 1, height + 1];
            for (int i = 0; i < coordinates.Count; i++)
            {
                Coordinate coord = coordinates[i];
                for (int row = 0; row <= height; row++)
                {
                    for (int col = 0; col <= width; col++)
                    {
                        int dist = Math.Abs(coord.left - col) + Math.Abs(coord.top - row);
                        if (grid[col, row] != null)
                        {
                            if (dist < grid[col, row].distance)
                            {
                                grid[col, row].distance = dist;
                                grid[col, row].coordIndex = i;
                            }
                            else
                            {
                                if (dist == grid[col, row].distance)
                                {
                                    grid[col, row].distance = dist;
                                    grid[col, row].coordIndex = -1;
                                }
                            }
                        }
                        else
                            grid[col, row] = new GridPoint(dist, i);
                    }
                }
            }

            for (int row = 0; row <= height; row++)
            {
                for (int col = 0; col <= width; col++)
                {
                    GridPoint point = grid[col, row];
                    if (grid[col, row].coordIndex == -1)
                        continue;
                    if ((row == 0) || (row == height - 1) || (col == 0) || (col == width - 1))
                        coordinates[point.coordIndex].finite = false;
                    coordinates[point.coordIndex].area++;
                }
            }

            Coordinate result = coordinates.Aggregate((currMax, x) => (x.finite && (currMax == null || x.area > currMax.area) ? x : currMax));
            
            Console.WriteLine(result.area.ToString());
            Console.ReadLine();
        }

    }

}
