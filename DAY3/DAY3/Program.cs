using System;
using System.Collections.Generic;
using System.Linq;

namespace DAY3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"));
            List<string> nums = new List<string>(input);
            Console.WriteLine($"Part one: {SolveOne(nums)}");
            //Console.WriteLine($"Part two: {SolveTwo(nums)}");
        }

        public static int SolveOne(List<string> task)
        {
            int[] zCount = new int[12];
            int[] oCount = new int[12];
            List<string> finalBinary = new List<string>();
            List<string> reverseBinary = new List<string>();
            foreach (string s in task)
            {
                for (int i = 0; i < s.Length; i++)
                    if (s[i] == '0')
                    {
                        zCount[i]++;
                    }
                    else
                    {
                        oCount[i]++;
                    }
            }

            for (int i = 0; i < zCount.Length; i++)
            {
                if (zCount[i] > oCount[i])
                {
                    finalBinary.Add("0");
                    reverseBinary.Add("1");
                }
                else
                {
                    finalBinary.Add("1");
                    reverseBinary.Add("0");
                }
            }

            var result = Convert.ToInt32(String.Join("", finalBinary.ToArray()), 2);
            var result2 = Convert.ToInt32(String.Join("", reverseBinary.ToArray()), 2);

            return result * result2;
        }


    }
}