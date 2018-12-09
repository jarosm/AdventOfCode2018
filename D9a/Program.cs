using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D9a
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllText("d:\\programming\\Advent of Code\\data\\D9a\\input.txt").Split(' ');
            int playerCount = Convert.ToInt32(input[0]);
            int marbleCount = Convert.ToInt32(input[6]);

            List<int> circle = new List<int>();
            circle.Add(0);
            int player = 1;
            int position = 0;
            int[] playerScore = new int[playerCount];
            
            for (int i = 1; i <= marbleCount; i++)
            {
                if (i % 23 != 0)
                {
                    position++;
                    if (position >= circle.Count)
                        position = 0;
                    position++;
                    circle.Insert(position, i);
                }
                else
                {
                    position -= 7;
                    if (position < 0)
                        position = circle.Count + position;

                    playerScore[player - 1] += i + circle[position];
                    circle.RemoveAt(position);
                    if (position == circle.Count)
                        position = 0;
                }

                player++;
                if (player > playerCount)
                    player = 1;
            }

            Console.WriteLine(playerScore.Max().ToString());
            Console.ReadLine();
        }

    }

}
