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
    public static void HashMap(string label, string operation, string focalLength, Dictionary<int, List<(string, int)>> boxes)
    {
        int boxNum = HashAlgorithm(label);
        if (!boxes.ContainsKey(boxNum))
        {
            boxes[boxNum] = new List<(string, int)>();
        }

        if (operation == "=")
        {
            var lens = (label, int.Parse(focalLength));
            boxes[boxNum] = boxes[boxNum].Select(l => l.Item1 == label ? lens : l).ToList();
            if (boxes[boxNum].All(l => l.Item1 != label))
            {
                boxes[boxNum].Add(lens);
            }
        }
        else if (operation == "-")
        {
            boxes[boxNum] = boxes[boxNum].Where(l => l.Item1 != label).ToList();
        }
    }
 

    public static void Main(string[] args)
    {
        // Part 1
        var inputList = ReadArrayFromFile(@"../../../input.txt");
        var part1Result = inputList.Select(HashAlgorithm).Sum();
        Console.WriteLine("Part 1 = " + part1Result);

        
        // Part 2
        var labelOperations = ReadLabelOperationLens("../../../input.txt");
        var boxes = new Dictionary<int, List<(string, int)>>();
        foreach (var (label, operation, focalLength) in labelOperations)
        {
            HashMap(label, operation, focalLength, boxes);
        }

        int totalFocusingPower = boxes.Sum(box =>
            box.Value.Select((lens, slotIndex) => (box.Key + 1) * (slotIndex + 1) * lens.Item2).Sum());

        Console.WriteLine("Part 2 = " + totalFocusingPower);
     
    }
}
