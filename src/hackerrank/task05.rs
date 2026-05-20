// https://www.hackerrank.com/challenges/apple-and-orange/problem
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    static int LCM(int a, int b)
    {
        return a / GCD(a, b) * b;
    }

    static int getTotalX(List<int> a, List<int> b)
    {
        int lcm = a[0];
        foreach (int x in a)
            lcm = LCM(lcm, x);

        int gcd = b[0];
        foreach (int x in b)
            gcd = GCD(gcd, x);

        int count = 0;
        for (int i = lcm; i <= gcd; i += lcm)
        {
            if (gcd % i == 0)
                count++;
        }

        return count;
    }

    static void Main()
    {
        var nm = Console.ReadLine().Split();
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);

        var a = Console.ReadLine().Split().Select(int.Parse).ToList();
        var b = Console.ReadLine().Split().Select(int.Parse).ToList();

        Console.WriteLine(getTotalX(a, b));
    }
}
