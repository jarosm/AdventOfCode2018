using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D2a
{
    class Program
    {
        static void Main(string[] args)
        {
            int twoTimes = 0, threeTimes = 0;
            using (StreamReader input = File.OpenText("d:\\programming\\Advent of Code\\data\\D2a\\input.txt"))
            {
                string id = "";
                while ((id = input.ReadLine()) != null)
                {
                    foreach (char c in id)
                    {
                        if (id.Count(x => x == c) == 2)
                        {
                            twoTimes++;
                            break;
                        }
                    }
                    foreach (char c in id)
                    {
                        if (id.Count(x => x == c) == 3)
                        {
                            threeTimes++;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine((twoTimes * threeTimes).ToString());
            Console.ReadLine();
        }

    }

}
