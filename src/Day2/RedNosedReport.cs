using System.Text.RegularExpressions;
using System.Reflection;

namespace Day2;

static public class Day2Logic
{
    static public int Part1(string inputFilePath)
    {
        var reports = ReadOutInputFile(inputFilePath);
        int amountOfSafeReports = 0;
        foreach (string report in reports)
        {
            var levels = ParseLevels(report);

            if (IsSafeReport(levels))
            {
                amountOfSafeReports++;
            }
        }

        return amountOfSafeReports;
    }
    static public int Part2(string inputFilePath)
    {
        var reports = ReadOutInputFile(inputFilePath);
        return 0;
    }

    static List<int> ParseLevels(string report)
    {
        return new Regex(@"\d+").Matches(report).Select(levelMatch => int.Parse(levelMatch.Value)).ToList();
    }
    static private List<string> ReadOutInputFile(string inputFilePath)
    {
        string resolvedPath = Path.GetFullPath(inputFilePath);
        if (!Path.Exists(resolvedPath)) { throw new FileNotFoundException($"The file {resolvedPath} does not exists! It could not be loaded!."); }
        return File.ReadLines(resolvedPath).ToList();
    }
    static private bool IsSafeReport(List<int> levels)
    {
        if (!(HasOnlyIncreasingLevels(levels) || HasOnlyDecreasingLevels(levels)))
        {
            return false;
        }
        if (HasEnougLevelDifferences(levels) && HasOnlySmallLevelDifferences(levels))
        {
            return true;
        }
        return false;
    }

    static private bool HasOnlyIncreasingLevels(List<int> levels)
    {
        for (int i = 0; i < levels.Count - 1; i++)
        {
            if (levels[i] > levels[i + 1])
                return false;
        }
        return true;
    }
    static private bool HasOnlyDecreasingLevels(List<int> levels)
    {
        for (int i = 0; i < levels.Count - 1; i++)
        {
            if (levels[i] < levels[i + 1])
                return false;
        }
        return true;
    }
    static private bool HasOnlySmallLevelDifferences(List<int> levels)
    {
        for (int i = 0; i < levels.Count - 1; i++)
        {
            if (Math.Abs(levels[i] - levels[i + 1]) < 1)
            { return false; }
        }
        return true;
    }
    static private bool HasEnougLevelDifferences(List<int> levels)
    {

        for (int i = 0; i < levels.Count - 1; i++)
        {
            if (Math.Abs(levels[i] - levels[i + 1]) > 3)
            { return false; }
        }
        return true;
    }
}
