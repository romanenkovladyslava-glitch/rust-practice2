// https://www.hackerrank.com/challenges/between-two-sets/problem
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
     * Complete the 'migratoryBirds' function below.
     */
    public static int migratoryBirds(List<int> arr)
    {
        int[] counts = new int[6];

        foreach (int birdId in arr)
        {
            counts[birdId]++;
        }

        int maxFrequency = 0;
        int answer = 0;

        for (int i = 1; i <= 5; i++)
        {
            if (counts[i] > maxFrequency)
            {
                maxFrequency = counts[i];
                answer = i;
            }
        }

        return answer;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        string outputPath = Environment.GetEnvironmentVariable("OUTPUT_PATH");
        TextWriter textWriter = new StreamWriter(outputPath, true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ')
            .ToList()
            .Select(arrTemp => Convert.ToInt32(arrTemp))
            .ToList();

        int result = Result.migratoryBirds(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
