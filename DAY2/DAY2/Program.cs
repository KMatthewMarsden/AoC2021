using System;
using System.Collections.Generic;
using System.Linq;

namespace DAY2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"));
            List<Instructions> nums = new List<Instructions>();
            for (int i = 0; i < input.Length; i++)
            {
                string[] tokens = input[i].Split();
                nums.Add(new Instructions(tokens[0], tokens[1]));
            }
            Console.WriteLine($"Part one: {SolveOne(nums)}");
            Console.WriteLine($"Part two: {SolveTwo(nums)}");
        }

        public static int SolveOne(List<Instructions> instructions)
        {
            int depth = 0;
            int horizontal = 0;

            for(int i = 0; i < instructions.Count; i++)
            {
                if(instructions[i].token == "forward")
                {
                    horizontal += instructions[i].movement;
                }
                else if(instructions[i].token == "down")
                {
                    depth += instructions[i].movement;
                }
                else if(instructions[i].token == "up")
                {
                    depth -= instructions[i].movement;
                }
            }

            return horizontal * depth;
        }

        public static int SolveTwo(List<Instructions> instructions)
        {
            int depth = 0;
            int horizontal = 0;
            int aim = 0;

            for (int i = 0; i < instructions.Count; i++)
            {
                if (instructions[i].token == "forward")
                {
                    horizontal += instructions[i].movement;
                    depth += instructions[i].movement * aim; 
                }
                else if (instructions[i].token == "down")
                {
                    aim += instructions[i].movement;
                }
                else if (instructions[i].token == "up")
                {
                    aim -= instructions[i].movement;
                }
            }

            return horizontal * depth;
        }

    }

    public class Instructions
    {
        public Instructions(string token, string movement)
        {
            this.token = token.Trim();
            this.movement = Int32.Parse(movement.Trim());
        }

        public string token { get; set; }
        public int movement { get; set; }
    }
}