using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D5b
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = File.ReadAllText("d:\\programming\\Advent of Code\\data\\D5a\\input.txt");
            int minLen = inputString.Length;
            string[] chars = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            for (int i = 0; i < chars.Length; i++)
            {
                string input = inputString.Replace(chars[i], "").Replace(chars[i].ToUpper(), "");
                int before = 0, after = input.Length;

                while (before != after)
                {
                    before = after;

                    input = input.Replace("aA", "").Replace("Aa", "");
                    input = input.Replace("bB", "").Replace("Bb", "");
                    input = input.Replace("cC", "").Replace("Cc", "");
                    input = input.Replace("dD", "").Replace("Dd", "");
                    input = input.Replace("eE", "").Replace("Ee", "");
                    input = input.Replace("fF", "").Replace("Ff", "");
                    input = input.Replace("gG", "").Replace("Gg", "");
                    input = input.Replace("hH", "").Replace("Hh", "");
                    input = input.Replace("iI", "").Replace("Ii", "");
                    input = input.Replace("jJ", "").Replace("Jj", "");
                    input = input.Replace("kK", "").Replace("Kk", "");
                    input = input.Replace("lL", "").Replace("Ll", "");
                    input = input.Replace("mM", "").Replace("Mm", "");
                    input = input.Replace("nN", "").Replace("Nn", "");
                    input = input.Replace("oO", "").Replace("Oo", "");
                    input = input.Replace("pP", "").Replace("Pp", "");
                    input = input.Replace("qQ", "").Replace("Qq", "");
                    input = input.Replace("rR", "").Replace("Rr", "");
                    input = input.Replace("sS", "").Replace("Ss", "");
                    input = input.Replace("tT", "").Replace("Tt", "");
                    input = input.Replace("uU", "").Replace("Uu", "");
                    input = input.Replace("vV", "").Replace("Vv", "");
                    input = input.Replace("wW", "").Replace("Ww", "");
                    input = input.Replace("xX", "").Replace("Xx", "");
                    input = input.Replace("yY", "").Replace("Yy", "");
                    input = input.Replace("zZ", "").Replace("Zz", "");

                    after = input.Length;
                }

                minLen = Math.Min(minLen, after);
            }

            Console.WriteLine(minLen.ToString());
            Console.ReadLine();
        }

    }

}
