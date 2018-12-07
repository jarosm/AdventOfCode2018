using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D7b
{
    class Program
    {
        public class Step
        {
            public string id;
            public List<string> prev;
            public List<string> next;
            public int counter;

            public Step(string _id)
            {
                id = _id;
                prev = new List<string>();
                next = new List<string>();
                counter = 0;
            }
        }

        static void Main(string[] args)
        {
            List<Step> steps = new List<Step>();
            for (int c = 65; c <= 90; c++)
                steps.Add(new Step(((char)c).ToString()));

            // read instructions
            using (StreamReader input = File.OpenText("d:\\programming\\Advent of Code\\data\\D7a\\input.txt"))
            {
                string line = "";
                while ((line = input.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');
                    steps.Find(x => x.id == words[1]).next.Add(words[7]);
                    steps.Find(x => x.id == words[7]).prev.Add(words[1]);
                }
            }

            // sort next steps alphabetically
            for (int i = 0; i < steps.Count; i++)
            {
                steps[i].next.Sort();
                steps[i].prev.Sort();
            }

            // modified Kahn's algorithm
            List<Step> list = steps.FindAll(x => x.prev.Count == 0);
            List<Step> result = new List<Step>();
            List<Step> queue = new List<Step>();
            int time = -1;
            while ((list.Count > 0) || (queue.Count > 0))
            {
                time++;
                int q = 0;
                while (q < queue.Count)
                {
                    queue[q].counter--;
                    if (queue[q].counter == 0)
                    {
                        result.Add(queue[q]);
                        queue.RemoveAt(q);
                        Step last = result[result.Count - 1];
                        steps.Remove(steps.Find(x => x.id == last.id));
                        for (int i = 0; i < last.next.Count; i++)
                        {
                            Step next = steps.Find(x => x.id == last.next[i]);
                            next.prev.Remove(last.id);
                            if (next.prev.Count == 0)
                                list.Add(next);
                        }
                    }
                    else
                        q++;
                }

                list.Sort((x, y) => string.Compare(x.id, y.id));
                int j = 0;
                while (j < list.Count)
                {
                    if ((queue.Count < 5) && (queue.Find(x => x.next.Contains(list[j].id)) == null))
                    {
                        queue.Add(list[j]);
                        queue[queue.Count - 1].counter = 61 + (int)list[j].id[0] - (int)('A');
                        list.RemoveAt(j);
                    }
                    else
                        j++;
                }

                queue.Sort((x, y) => string.Compare(x.id, y.id));
            }

            Console.WriteLine(time.ToString());
            Console.ReadLine();
        }

    }

}