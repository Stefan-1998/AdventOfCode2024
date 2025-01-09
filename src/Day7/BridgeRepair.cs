using System.Numerics;
namespace Day7;

public class Day7Logic
{
    public string Part1(string inputFilePath)
    {
        var input = ReadOutInputFile(inputFilePath);
        var parsedInput = input.Select(line => ParseInput(line));

        BigInteger totalCalibrationResults = 0;
        foreach (var calibration in parsedInput)
        {
            if (IsCorrectCalibration(calibration.Result, new Queue<int>(calibration.Terms), 0))
            {
                totalCalibrationResults += calibration.Result;
            }
        }
        return totalCalibrationResults.ToString();
    }
    public string Part2(string inputFilePath)
    {
        return String.Empty;
    }

    private bool IsCorrectCalibration(long result, Queue<int> Terms, long currentSum)
    {
        if (currentSum > result) { return false; }
        if (currentSum == result) { return true; }

        if (Terms.Count == 0) { return false; }

        int item = Terms.Dequeue();
        //Add
        if (IsCorrectCalibration(result, new Queue<int>(Terms), currentSum + item)) { return true; }

        //Multiply
        return IsCorrectCalibration(result, new Queue<int>(Terms), currentSum * item);
    }

    private List<string> ReadOutInputFile(string inputFilePath)
    {
        string resolvedPath = Path.GetFullPath(inputFilePath);
        if (!Path.Exists(resolvedPath)) { throw new FileNotFoundException($"The file {resolvedPath} does not exists! It could not be loaded!."); }
        return File.ReadLines(resolvedPath).ToList();
    }
    private (long Result, List<int> Terms) ParseInput(string inputLine)
    {
        long result = long.Parse(inputLine.Split(':')[0]);
        List<int> terms = inputLine.Split(": ")[1].Split(' ').Select(number => Int32.Parse(number)).ToList();
        return (Result: result, Terms: terms);
    }

}

