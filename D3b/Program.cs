using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D3b
{
    public struct Claim
    {
        public string id;
        public int left;
        public int top;
        public int width;
        public int height;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Claim> claims = new List<Claim>();
            int maxWidth = 1000, maxHeight = 1000;
            using (StreamReader input = File.OpenText("d:\\programming\\Advent of Code\\data\\D3a\\input.txt"))
            {
                string line = "";
                while ((line = input.ReadLine()) != null)
                {
                    Claim c = new Claim();
                    string[] t1 = line.Split(' ');
                    c.id = t1[0].Substring(1);
                    string[] t2 = t1[2].Split(',');
                    c.left = Convert.ToInt32(t2[0]);
                    c.top = Convert.ToInt32(t2[1].TrimEnd(':'));
                    t2 = t1[3].Split('x');
                    c.width = Convert.ToInt32(t2[0]);
                    c.height = Convert.ToInt32(t2[1]);
                    claims.Add(c);
                }
            }

            int[,] cloth = new int[maxWidth, maxHeight];
            for (int i = 0; i < claims.Count; i++)
            {
                for (int h = claims[i].top; h < (claims[i].top + claims[i].height); h++)
                {
                    for (int w = claims[i].left; w < (claims[i].left + claims[i].width); w++)
                    {
                        cloth[w, h]++;
                    }
                }
            }

            string id = "";
            for (int i = 0; i < claims.Count; i++)
            {
                bool overlap = false;
                for (int h = claims[i].top; h < (claims[i].top + claims[i].height); h++)
                {
                    for (int w = claims[i].left; w < (claims[i].left + claims[i].width); w++)
                    {
                        if (cloth[w, h] > 1)
                            overlap = true;
                        if (overlap)
                            break;
                    }
                    if (overlap)
                        break;
                }

                if (!overlap)
                    id = claims[i].id;
            }

            Console.WriteLine(id);
            Console.ReadLine();
        }

    }
}
