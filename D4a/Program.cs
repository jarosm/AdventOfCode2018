using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D4a
{
    public struct Entry
    {
        public DateTime timestamp;
        public DateTime correctedTimestamp;
        public string text;
    }

    public class Shift
    {
        public int guardId;
        public int[] asleep;

        public Shift(int _guardId)
        {
            guardId = _guardId;
            asleep = new int[60];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Entry> entries = new List<Entry>();
            using (StreamReader input = File.OpenText("d:\\programming\\Advent of Code\\data\\D4a\\input.txt"))
            {
                string line = "";
                while ((line = input.ReadLine()) != null)
                {
                    Entry entry = new Entry();
                    entry.timestamp = DateTime.ParseExact(line.Substring(1, 16), "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                    if (entry.timestamp.Hour == 23)
                        entry.correctedTimestamp = entry.timestamp.AddDays(1).AddHours(-entry.timestamp.Hour).AddMinutes(-entry.timestamp.Minute);
                    else
                        entry.correctedTimestamp = entry.timestamp;
                    entry.text = line.Substring(19);
                    entries.Add(entry);
                }
            }
            entries = entries.OrderBy(x => x.timestamp).ToList();

            Shift shift = null;
            List<Shift> sList = new List<Shift>();
            for (int i = 0; i < entries.Count; i++)
            {
                if (entries[i].text.StartsWith("Guard"))
                {
                    shift = sList.Find(x => x.guardId == Convert.ToInt32(entries[i].text.Split(' ')[1].Substring(1)));
                    if (shift == null)
                    {
                        shift = new Shift(Convert.ToInt32(entries[i].text.Split(' ')[1].Substring(1)));
                        sList.Add(shift);
                    }
                }
                else
                {
                    bool asleep = (entries[i].text == "falls asleep" ? true : false);
                    if (asleep)
                    {
                        int toMinute = 60;
                        if ((i + 1 < entries.Count) && !entries[i + 1].text.StartsWith("Guard"))
                            toMinute = entries[i + 1].correctedTimestamp.Minute;
                        for (int m = entries[i].correctedTimestamp.Minute; m < toMinute; m++)
                            shift.asleep[m]++;
                    }
                }
            }

            int asleepMax = 0;
            int guardId = 0;
            for (int i = 0; i < sList.Count; i++)
            {
                shift = sList[i];
                int asleepCount = 0;
                for (int m = 0; m < 60; m++)
                    asleepCount += shift.asleep[m];
                if (asleepCount > asleepMax)
                {
                    asleepMax = asleepCount;
                    guardId = sList[i].guardId;
                }
            }

            shift = sList.Find(x => x.guardId == guardId);
            int max = shift.asleep.Max();

            Console.WriteLine((guardId * shift.asleep.ToList().IndexOf(max)).ToString());
            Console.ReadLine();
        }

    }

}
