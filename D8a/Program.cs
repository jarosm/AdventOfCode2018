using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D8a
{
    class Program
    {
        public class Node
        {
            public List<Node> subNodes;
            public List<int> metaData;

            public Node()
            {
                subNodes = new List<Node>();
                metaData = new List<int>();
            }
        }
        
        private static int index;
        private static int grandTotal;
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
                node.metaData.Add(Convert.ToInt32(input[index]));
                grandTotal += Convert.ToInt32(input[index]);
            }
        }

        static void Main(string[] args)
        {
            input = File.ReadAllText("d:\\programming\\Advent of Code\\data\\D8a\\input.txt").Split(' ');
            index = 0;
            grandTotal = 0;

            Node root = new Node();
            ParseInput(root);

            Console.WriteLine(grandTotal.ToString());
            Console.ReadLine();
        }
    }
}
