using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D1b
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("d:\\programming\\Advent of Code\\data\\D1a\\input.txt");
            int frequency = 0;
            List<int> history = new List<int>();

            int i = 0;
            history.Add(frequency);
            while (true)
            {
                try
                {
                    frequency += Convert.ToInt32(input[i]);
                    if (history.Contains(frequency))
                        break;
                    else
                        history.Add(frequency);
                }
                catch { }

                i++;
                if (i >= input.Length)
                    i = 0;
            }

            Console.WriteLine(frequency);
            Console.ReadLine();
        }

    }

}
