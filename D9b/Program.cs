using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D9b
{
    class Program
    {
        /// <summary>
        /// If the input is big enough, we must change List to LinkedList, because inserts and deletes are slow operations
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string[] input = File.ReadAllText("d:\\programming\\Advent of Code\\data\\D9a\\input.txt").Split(' ');
            int playerCount = Convert.ToInt32(input[0]);
            int marbleCount = 100 * Convert.ToInt32(input[6]);

            LinkedList<int> circle = new LinkedList<int>();
            circle.AddLast(0);
            int player = 1;
            var position = circle.First;
            Int64[] playerScore = new Int64[playerCount];

            for (int i = 1; i <= marbleCount; i++)
            {
                if (i % 23 != 0)
                {
                    position = position.Next;
                    if (position == null)
                        position = circle.First;
                    circle.AddAfter(position, i);
                    position = position.Next;
                }
                else
                {
                    for (int p = 0; p < 7; p++)
                    {
                        position = position.Previous;
                        if (position == null)
                            position = circle.Last;
                    }

                    playerScore[player - 1] += i + position.Value;
                    var next = position.Next;
                    circle.Remove(position);
                    if (next != null)
                        position = next;
                    else
                        position = circle.First;
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
