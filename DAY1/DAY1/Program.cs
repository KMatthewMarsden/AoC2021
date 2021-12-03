using System;
using System.Collections.Generic;
using System.Linq;

namespace DAY1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"));
            List<int> nums = (Array.ConvertAll(input, s => Int32.Parse(s))).ToList();
            Console.WriteLine($"Part one: {SolveOne(nums)}");
            Console.WriteLine($"Part two: {SolveTwo(nums)}");
        }

        public static int SolveOne(List<int> IncreaseDecrease)
        {
            int noLarger = 0;
            for(int i = 0; i < IncreaseDecrease.Count-1; i++)
            {
                if (IsLarger(IncreaseDecrease[i], IncreaseDecrease[i+1]))
                {
                    noLarger++;
                }
            }
            return noLarger;
        }

        public static bool IsLarger(int a, int b)
        {
            return b > a;
        }

        public static int SolveTwo(List<int> IncreaseDecrease)
        {
            int noLarger = 0;
            for (int i = 1; i < IncreaseDecrease.Count - 2; i++)
            {
                int frameA = SumTogether(IncreaseDecrease[i - 1], IncreaseDecrease[i], IncreaseDecrease[i + 1]);
                int frameB = SumTogether(IncreaseDecrease[i], IncreaseDecrease[i + 1], IncreaseDecrease[i + 2]);
                if(IsLarger(frameA, frameB))
                {
                    noLarger++;
                }
            }
            return noLarger;
        }

        public static int SumTogether(int a, int b, int c)
        {
            return a + b + c;
        }

    }
}