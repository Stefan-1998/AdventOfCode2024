using System.Text.RegularExpressions;
using System.Reflection;
using System.Numerics;

namespace Day5;

public class Day5Logic
{
    private Dictionary<string, HashSet<string>> pageOrderRules = new();
    public string Part1(string inputFilePath)
    {
        var pageNumberAndRulesList = ReadOutInputFile(inputFilePath).ToList();
        ParsePageOrderRules(pageNumberAndRulesList);
        int sumOfMiddleNumbersOfCorrectPages = 0;
        foreach (var line in pageNumberAndRulesList)
        {
            if (line.Contains('|') || String.IsNullOrEmpty(line)) { continue; }
            var pageNumbers = line.Split(',').ToList();
            if (HasCorrectPageOrder(pageNumbers))
            {
                sumOfMiddleNumbersOfCorrectPages += Int32.Parse(pageNumbers[pageNumbers.Count / 2]);
            }
        }
        return sumOfMiddleNumbersOfCorrectPages.ToString();
    }
    public string Part2(string inputFilePath)
    {
        var pageNumberAndRulesList = ReadOutInputFile(inputFilePath).ToList();
        ParsePageOrderRules(pageNumberAndRulesList);
        int sumOfMiddleNumbersOfCorrectPages = 0;
        foreach (var line in pageNumberAndRulesList)
        {
            if (line.Contains('|') || String.IsNullOrEmpty(line)) { continue; }
            var pageNumbers = line.Split(',').ToList();
            if (!HasCorrectPageOrder(pageNumbers))
            {
                sumOfMiddleNumbersOfCorrectPages += GetMiddleNumberOfSortedList(pageNumbers);
            }
        }
        return sumOfMiddleNumbersOfCorrectPages.ToString();
    }

    private int GetMiddleNumberOfSortedList(List<string> unorderPageNumbers)
    {
        while (!HasCorrectPageOrder(unorderPageNumbers))
        {

            for (int i = unorderPageNumbers.Count - 1; i >= 0; i--)
            {
                if (!pageOrderRules.ContainsKey(unorderPageNumbers[i])) { continue; }
                var followingNumbersAfterRules = pageOrderRules[unorderPageNumbers[i]];
                if (unorderPageNumbers.Take(i).Intersect(followingNumbersAfterRules).Any())
                {
                    var item = unorderPageNumbers[i];
                    unorderPageNumbers.RemoveAt(i);
                    unorderPageNumbers.Insert(i - 1, item);
                }
            }
        }
        return Int32.Parse(unorderPageNumbers[unorderPageNumbers.Count / 2]);
    }

    private void ParsePageOrderRules(List<string> rawOrderRules)
    {
        foreach (string rawOrderRule in rawOrderRules)
        {
            if (String.IsNullOrEmpty(rawOrderRule)) { continue; }
            if (!rawOrderRule.Contains('|')) { continue; }

            string predecesorNumber = rawOrderRule.Split('|')[0];
            string postdecesorNumber = rawOrderRule.Split('|')[1];
            if (!pageOrderRules.ContainsKey(predecesorNumber)) { pageOrderRules[predecesorNumber] = new HashSet<string>(); }
            (pageOrderRules[predecesorNumber]).Add(postdecesorNumber);
        }
    }

    private bool HasCorrectPageOrder(List<string> pageNumberList)
    {
        for (int i = pageNumberList.Count - 1; i >= 0; i--)
        {
            if (!pageOrderRules.ContainsKey(pageNumberList[i])) { continue; }
            var followingNumbersAfterRules = pageOrderRules[pageNumberList[i]];
            if (pageNumberList.Take(i).Intersect(followingNumbersAfterRules).Any()) { return false; }
        }
        return true;
    }

    private List<string> ParsePageNumberList(string pageList) => pageList.Split(',').ToList();

    private List<string> ReadOutInputFile(string inputFilePath)
    {
        string resolvedPath = Path.GetFullPath(inputFilePath);
        if (!Path.Exists(resolvedPath)) { throw new FileNotFoundException($"The file {resolvedPath} does not exists! It could not be loaded!."); }
        return File.ReadLines(resolvedPath).ToList();
    }
}

