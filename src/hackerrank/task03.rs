// https://www.hackerrank.com/challenges/staircase/problem
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Result
{
    

    public static void staircase(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                Console.Write(" ");
            }
            for (int j = 0; j < i; j++)
            {
                Console.Write("#");
            }
            Console.WriteLine();
        }
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        Result.staircase(n);
    }
}
