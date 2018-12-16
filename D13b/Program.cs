using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D13b
{
    class Program
    {
        public class Track
        {
            public int dX;
            public int dY;
            public bool crossroad;
        }

        public class Cart
        {
            public int posX;
            public int posY;
            public int changeX;
            public int changeY;
            public int nextCrossroadDirection; // 0 - left, 1 - straight, 2 - right
        }

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("d:\\programming\\Advent of Code\\data\\D13a\\input.txt");
            Track[,] tracks = new Track[input.Length, input[0].Length];
            List<Cart> carts = new List<Cart>();

            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[0].Length; x++)
                {
                    Track track = null;

                    switch (input[y][x])
                    {
                        case '/':
                            if ((x == 0) || ((input[y][x - 1] != '-') && (input[y][x - 1] != '+') && (input[y][x - 1] != '>') && (input[y][x - 1] != '<')))
                                track = new Track() { dX = 1, dY = 1, crossroad = false };
                            else
                                track = new Track() { dX = -1, dY = -1, crossroad = false };
                            break;

                        case '\\':
                            if ((x == 0) || ((input[y][x - 1] != '-') && (input[y][x - 1] != '+') && (input[y][x - 1] != '>') && (input[y][x - 1] != '<')))
                                track = new Track() { dX = 1, dY = -1, crossroad = false };
                            else
                                track = new Track() { dX = -1, dY = 1, crossroad = false };
                            break;

                        case '+':
                            track = new Track() { dX = 0, dY = 0, crossroad = true };
                            break;

                        case '|':
                        case '-':
                        case '>':
                        case '<':
                        case '^':
                        case 'v':
                            track = new Track() { dX = 0, dY = 0, crossroad = false };

                            if (input[y][x] == '>')
                                carts.Add(new Cart() { posX = x, posY = y, changeX = 1, changeY = 0, nextCrossroadDirection = 0 });
                            if (input[y][x] == '<')
                                carts.Add(new Cart() { posX = x, posY = y, changeX = -1, changeY = 0, nextCrossroadDirection = 0 });
                            if (input[y][x] == '^')
                                carts.Add(new Cart() { posX = x, posY = y, changeX = 0, changeY = -1, nextCrossroadDirection = 0 });
                            if (input[y][x] == 'v')
                                carts.Add(new Cart() { posX = x, posY = y, changeX = 0, changeY = 1, nextCrossroadDirection = 0 });
                            break;
                    }

                    tracks[y, x] = track;
                }
            }
            
            while (carts.Count > 1)
            {
                int i = 0;
                while (i < carts.Count)
                {
                    Cart cart = carts.Find(c => (c.posX == carts[i].posX + carts[i].changeX) && (c.posY == carts[i].posY + carts[i].changeY));
                    if (cart != null)
                    {
                        carts.RemoveAt(i);
                        if (carts.FindIndex(c => c == cart) < i)
                            i--;
                        carts.Remove(cart);
                        continue;
                    }

                    carts[i].posX = carts[i].posX + carts[i].changeX;
                    carts[i].posY = carts[i].posY + carts[i].changeY;

                    if (!tracks[carts[i].posY, carts[i].posX].crossroad)
                    {
                        carts[i].changeX = carts[i].changeX + tracks[carts[i].posY, carts[i].posX].dX;
                        carts[i].changeY = carts[i].changeY + tracks[carts[i].posY, carts[i].posX].dY;
                    }
                    else
                    {
                        switch (carts[i].nextCrossroadDirection)
                        {
                            case 0: // left
                                carts[i].nextCrossroadDirection = 1;

                                if (carts[i].changeX == 0) // movement up/down
                                {
                                    if (carts[i].changeY == 1) // down
                                    {
                                        carts[i].changeX = 1;
                                        carts[i].changeY = 0;
                                    }
                                    else // up
                                    {
                                        carts[i].changeX = -1;
                                        carts[i].changeY = 0;
                                    }
                                }
                                else  // movement left/right
                                {
                                    if (carts[i].changeX == 1) // right
                                    {
                                        carts[i].changeX = 0;
                                        carts[i].changeY = -1;
                                    }
                                    else // left
                                    {
                                        carts[i].changeX = 0;
                                        carts[i].changeY = 1;
                                    }
                                }
                                break;

                            case 1: // straight
                                carts[i].nextCrossroadDirection = 2;
                                break;

                            case 2: // right
                                carts[i].nextCrossroadDirection = 0;

                                if (carts[i].changeX == 0) // movement up/down
                                {
                                    if (carts[i].changeY == 1) // down
                                    {
                                        carts[i].changeX = -1;
                                        carts[i].changeY = 0;
                                    }
                                    else // up
                                    {
                                        carts[i].changeX = 1;
                                        carts[i].changeY = 0;
                                    }
                                }
                                else  // movement left/right
                                {
                                    if (carts[i].changeX == 1) // right
                                    {
                                        carts[i].changeX = 0;
                                        carts[i].changeY = 1;
                                    }
                                    else // left
                                    {
                                        carts[i].changeX = 0;
                                        carts[i].changeY = -1;
                                    }
                                }
                                break;
                        }
                    }

                    i++;
                }

                carts = carts.OrderBy(c => c.posY).ThenBy(c => c.posX).ToList();
            }

            Console.WriteLine("last cart: X = " + carts[0].posX.ToString() + " , Y = " + carts[0].posY.ToString());
            Console.ReadLine();
        }

    }

}