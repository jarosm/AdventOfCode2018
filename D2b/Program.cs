using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D2b
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("d:\\programming\\Advent of Code\\data\\D2a\\input.txt");
            int index1 = 0, index2 = 0;

            int len = input.Length;
            while (index1 < len)
            {
                index2 = index1 + 1;
                Console.Write((index1 + 1).ToString() + "/" + len + "\r");

                while (index2 < len)
                {
                    int differencies = 0;

                    for (int i = 0; i < input[index1].Length; i++)
                    {
                        if (input[index1][i] != input[index2][i])
                            differencies++;
                    }

                    if (differencies == 1)
                        break;
                    index2++;
                }

                if (index2 < len)
                    break;
                index1++;
            }

            Console.WriteLine("");
            if ((index1 < len) && (index2 < len))
            {
                Console.WriteLine(input[index1]);
                Console.WriteLine(input[index2]);
            }
            else
                Console.WriteLine("error");
            Console.ReadLine();
        }

    }

}
