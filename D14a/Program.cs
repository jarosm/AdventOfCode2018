using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D14a
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 323081;

            List<int> recipes = new List<int>();
            recipes.Add(3);
            recipes.Add(7);

            int elf1 = 0, elf2 = 1;

            while (recipes.Count < input + 10)
            {
                int sum = recipes[elf1] + recipes[elf2];
                if (sum >= 10)
                    recipes.Add(1);
                recipes.Add(sum % 10);

                elf1 = (elf1 + 1 + recipes[elf1]) % recipes.Count;
                elf2 = (elf2 + 1 + recipes[elf2]) % recipes.Count;
            }

            for (int i = input; i < input + 10; i++)
            {
                Console.Write(recipes[i].ToString());
            }
            
            Console.ReadLine();
        }

    }

}