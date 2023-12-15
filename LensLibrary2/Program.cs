using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Solution
{
    public static string[] ReadArrayFromFile(string filePath)
    {
        return File.ReadAllLines(filePath).SelectMany(line => line.Split(',')).ToArray();
    }

    public static List<(string label, string operation, string focalLength)> ReadLabelOperationLens(string filePath)
    {
        var steps = File.ReadAllText(filePath).Trim().Split(',');
        var operations = new List<(string label, string operation, string focalLength)>();
        
        foreach (var step in steps)
        {
            foreach (var op in new[] { "=", "-" })
            {
                if (step.Contains(op))
                {
                    var parts = step.Split(op);
                    var label = parts[0];
                    var focalLength = parts.Length > 1 ? parts[1] : "";
                    operations.Add((label, op, focalLength));
                }
            }
        }

        return operations;
    }

    public static int HashAlgorithm(string a)
    {
        int num = 0;
        foreach (var ch in a)
        {
            num = ((num + ch) * 17) % 256;
        }
        return num;
    }

 

    public static void Main(string[] args)
    {
        // Part 1
        var inputList = ReadArrayFromFile(@"../../../input.txt");
        var part1Result = inputList.Select(HashAlgorithm).Sum();
        Console.WriteLine("Part 1 = " + part1Result);

     
    }
}
