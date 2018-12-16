using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D14b
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 3, 2, 3, 0, 8, 1 };

            List<int> recipes = new List<int>();
            recipes.Add(3);
            recipes.Add(7);

            int elf1 = 0, elf2 = 1, index = 0, positionToCheck = 0;
            bool found = false;

            while (!found)
            {
                int sum = recipes[elf1] + recipes[elf2];
                if (sum >= 10)
                    recipes.Add(1);
                recipes.Add(sum % 10);

                elf1 = (elf1 + 1 + recipes[elf1]) % recipes.Count;
                elf2 = (elf2 + 1 + recipes[elf2]) % recipes.Count;

                while (index + positionToCheck < recipes.Count)
                {
                    if (input[positionToCheck] == recipes[index + positionToCheck])
                    {
                        if (positionToCheck == input.Length - 1)
                        {
                            found = true;
                            break;
                        }
                        positionToCheck++;
                    }
                    else
                    {
                        positionToCheck = 0;
                        index++;
                    }
                }
            }

            Console.WriteLine(index.ToString());
            Console.ReadLine();
        }

    }

}