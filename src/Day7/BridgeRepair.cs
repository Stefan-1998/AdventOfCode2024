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
            if (IsCorrectCalibration(calibration.Result, new Queue<long>(calibration.Terms), 0))
            {
                totalCalibrationResults += calibration.Result;
            }
        }
        return totalCalibrationResults.ToString();
    }
    public string Part2(string inputFilePath)
    {
        var input = ReadOutInputFile(inputFilePath);
        var parsedInput = input.Select(line => ParseInput(line));

        BigInteger totalCalibrationResults2 = 0;
        foreach (var calibration in parsedInput)
        {
            if (IsCorrectCalibrationWithConcatination(calibration.Result, new Queue<long>(calibration.Terms), 0))
            {
                totalCalibrationResults2 += calibration.Result;
            }
        }
        return totalCalibrationResults2.ToString();
    }

    private bool IsCorrectCalibration(long result, Queue<long> Terms, long currentSum)
    {
        if (currentSum > result) { return false; }
        if (currentSum == result) { return true; }

        if (Terms.Count == 0) { return false; }

        long item = Terms.Dequeue();
        //Add
        if (IsCorrectCalibration(result, new Queue<long>(Terms), currentSum + item)) { return true; }

        //Multiply
        return IsCorrectCalibration(result, new Queue<long>(Terms), currentSum * item);
    }

    private bool IsCorrectCalibrationWithConcatination(long result, Queue<long> Terms, long currentSum)
    {
        if (currentSum > result) { return false; }
        if (currentSum == result) { return true; }

        if (Terms.Count == 0) { return false; }

        long item = Terms.Dequeue();
        //Add
        if (IsCorrectCalibrationWithConcatination(result, new Queue<long>(Terms), currentSum + item)) { return true; }

        //Multiply
        if (IsCorrectCalibrationWithConcatination(result, new Queue<long>(Terms), currentSum * item)) { return true; }

        return IsCorrectCalibrationWithConcatination(result, new Queue<long>(Terms), long.Parse($"{currentSum}{item}"));
    }

    private List<string> ReadOutInputFile(string inputFilePath)
    {
        string resolvedPath = Path.GetFullPath(inputFilePath);
        if (!Path.Exists(resolvedPath)) { throw new FileNotFoundException($"The file {resolvedPath} does not exists! It could not be loaded!."); }
        return File.ReadLines(resolvedPath).ToList();
    }
    private (long Result, List<long> Terms) ParseInput(string inputLine)
    {
        long result = long.Parse(inputLine.Split(':')[0]);
        List<long> terms = inputLine.Split(": ")[1].Split(' ').Select(number => long.Parse(number)).ToList();
        return (Result: result, Terms: terms);
    }
}


