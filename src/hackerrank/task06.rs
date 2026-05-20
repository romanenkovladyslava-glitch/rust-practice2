// https://www.hackerrank.com/challenges/kangaroo/problem
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    /*
     * Complete the 'breakingRecords' function below.
     */
    public static List<int> breakingRecords(List<int> scores)
    {
        int highest = scores[0];
        int lowest = scores[0];
        
        int countMax = 0;
        int countMin = 0;

        for (int i = 1; i < scores.Count; i++)
        {
            if (scores[i] > highest)
            {
                highest = scores[i];
                countMax++;
            }
            else if (scores[i] < lowest)
            {
                lowest = scores[i];
                countMin++;
            }
        }

        return new List<int> { countMax, countMin };
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> scores = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(scoresTemp => Convert.ToInt32(scoresTemp)).ToList();

        List<int> result = Result.breakingRecords(scores);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
