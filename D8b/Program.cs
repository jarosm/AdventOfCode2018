using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D8b
{
    class Program
    {
        public class Node
        {
            public List<Node> subNodes;
            public List<int> metaData;
            public int value;

            public Node()
            {
                subNodes = new List<Node>();
                metaData = new List<int>();
                value = 0;
            }
        }

        private static int index;
        private static string[] input;

        private static void ParseInput(Node node)
        {
            int subNodesCount = Convert.ToInt32(input[index]);
            index++;
            int metaDataCount = Convert.ToInt32(input[index]);

            for (int i = 0; i < subNodesCount; i++)
            {
                index++;
                Node subNode = new Node();
                ParseInput(subNode);
                node.subNodes.Add(subNode);
            }

            for (int i = 0; i < metaDataCount; i++)
            {
                index++;
                int meta = Convert.ToInt32(input[index]);
                node.metaData.Add(meta);

                if (subNodesCount == 0)
                    node.value += meta;
                else
                {
                    if ((meta > 0) && (meta <= subNodesCount))
                        node.value += node.subNodes[meta - 1].value;
                }
            }
        }

        static void Main(string[] args)
        {
            input = File.ReadAllText("d:\\programming\\Advent of Code\\data\\D8a\\input.txt").Split(' ');
            index = 0;

            Node root = new Node();
            ParseInput(root);

            Console.WriteLine(root.value.ToString());
            Console.ReadLine();
        }
    }
}