using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D1a
{
    class Program
    {
        static void Main(string[] args)
        {
            int frequency = 0;
            using (StreamReader input = File.OpenText("d:\\programming\\Advent of Code\\data\\D1a\\input.txt"))
            {
                string number = "";
                while ((number = input.ReadLine()) != null)
                {
                    try
                    {
                        frequency += Convert.ToInt32(number);
                    }
                    catch { }
                }
            }
            Console.WriteLine(frequency);
            Console.ReadLine();
        }

    }

}
