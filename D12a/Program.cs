using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D12a
{
    class Program
    {
        public struct Rule
        {
            public string state;
            public string change;
        }

        static void Main(string[] args)
        {
            string currentGeneration = ".............................."; // 30 pots as a buffer to left and right
            string nextGeneration = "";
            List<Rule> rules = new List<Rule>();

            using (StreamReader input = File.OpenText("d:\\programming\\Advent of Code\\data\\D12a\\input.txt"))
            {
                string line = "";
                while ((line = input.ReadLine()) != null)
                {
                    if (line.StartsWith("#") || line.StartsWith("."))
                    {
                        string[] temp = line.Split(' ');
                        if (temp[0][2] != temp[2][0]) // skip rules with no change
                        {
                            Rule rule = new Rule();
                            rule.state = temp[0];
                            rule.change = temp[2];
                            rules.Add(rule);
                        }
                    }
                    else
                    {
                        if (line.StartsWith("initial"))
                            currentGeneration = currentGeneration + line.Split(' ')[2] + currentGeneration;
                    }
                }
                
                for (int g = 1; g <= 20; g++)
                {
                    nextGeneration = currentGeneration;

                    for (int i = 0; i < rules.Count; i++)
                    {
                        int index = currentGeneration.IndexOf(rules[i].state, 0);
                        while (index > -1)
                        {
                            nextGeneration = nextGeneration.Remove(index + 2, 1).Insert(index + 2, rules[i].change);
                            index = currentGeneration.IndexOf(rules[i].state, index + 1);
                        }
                    }
                    
                    currentGeneration = nextGeneration;
                }
            }

            int count = 0;
            for (int i = 0; i < currentGeneration.Length; i++)
            {
                if (currentGeneration[i] == '#')
                    count += i - 30;
            }

            Console.WriteLine(count.ToString());
            Console.ReadLine();
        }

    }

}
