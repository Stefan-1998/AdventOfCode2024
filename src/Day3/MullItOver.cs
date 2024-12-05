using System.Text.RegularExpressions;
using System.Reflection;
using System.Numerics;

namespace Day3;

static public class Day3Logic
{
    static public string Part1(string inputFilePath)
    {
        var corruptedInstructionsLines = ReadOutInputFile(inputFilePath).ToList();
        BigInteger multiplicationSum = 0;
        foreach (string corruptedInstructions in corruptedInstructionsLines)
        {
            MatchCollection validInstructions = new Regex(@"mul\((?<FirstDigit>\d{1,3}),(?<SecondDigit>\d{1,3})\)").Matches(corruptedInstructions);

            foreach (Match validInstruction in validInstructions)
            {
                multiplicationSum += (BigInteger)Int32.Parse(validInstruction.Groups["FirstDigit"].Value) * Int32.Parse(validInstruction.Groups["SecondDigit"].Value);
            }
        }
        return multiplicationSum.ToString();
    }
    static public string Part2(string inputFilePath)
    {
        var corruptedInstructionsLines = ReadOutInputFile(inputFilePath).ToList();
        BigInteger multiplicationSum = 0;
        bool isEnabled = true;
        foreach (string corruptedInstructions in corruptedInstructionsLines)
        {
            MatchCollection validInstructions = new Regex(@"(mul\((?<FirstDigit>\d{1,3}),(?<SecondDigit>\d{1,3})\)|do\(\)|don't\(\))").Matches(corruptedInstructions);

            foreach (Match validInstruction in validInstructions)
            {
                if (validInstruction.Value == "do()")
                {
                    isEnabled = true;
                    continue;
                }
                if (validInstruction.Value == "don't()")
                {
                    isEnabled = false;
                    continue;
                }
                if (isEnabled)
                {
                    multiplicationSum += (BigInteger)Int32.Parse(validInstruction.Groups["FirstDigit"].Value) * Int32.Parse(validInstruction.Groups["SecondDigit"].Value);
                }
            }
        }
        return multiplicationSum.ToString();
    }

    static private List<string> ReadOutInputFile(string inputFilePath)
    {
        string resolvedPath = Path.GetFullPath(inputFilePath);
        if (!Path.Exists(resolvedPath)) { throw new FileNotFoundException($"The file {resolvedPath} does not exists! It could not be loaded!."); }
        return File.ReadLines(resolvedPath).ToList();
    }
}

