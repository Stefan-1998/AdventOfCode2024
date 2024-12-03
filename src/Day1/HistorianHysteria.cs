using System.Text.RegularExpressions;
using System.Reflection;

namespace Day1;

static public class Day1Logic
{
    static public int Part1(string inputFilePath)
    {
        var rawLocationIDList = ReadOutInputFile(inputFilePath);

        List<int> locationIdsOfFirstHistorien = new();
        List<int> locationIdsOfSecondHistorien = new();

        foreach (string line in rawLocationIDList)
        {
            var parsedIds = ParseLocationIds(line);
            locationIdsOfFirstHistorien.Add(parsedIds.First);
            locationIdsOfSecondHistorien.Add(parsedIds.Second);
        }
        locationIdsOfFirstHistorien.Sort();
        locationIdsOfSecondHistorien.Sort();

        int totalDistance = 0;
        for (int i = 0; i < locationIdsOfFirstHistorien.Count(); i++)
        {
            totalDistance += Math.Abs(locationIdsOfFirstHistorien[i] - locationIdsOfSecondHistorien[i]);
        }

        return totalDistance;
    }
    static public int Part2(string inputFilePath)
    {
        var rawLocationIDList = ReadOutInputFile(inputFilePath);

        List<int> locationIdsOfFirstHistorien = new();
        List<int> locationIdsOfSecondHistorien = new();

        foreach (string line in rawLocationIDList)
        {
            var parsedIds = ParseLocationIds(line);
            locationIdsOfFirstHistorien.Add(parsedIds.First);
            locationIdsOfSecondHistorien.Add(parsedIds.Second);
        }

        locationIdsOfFirstHistorien.Sort();
        int similarityScore = 0;

        var idAmountMap = CreateIdAmountMap(locationIdsOfSecondHistorien);

        foreach (int id in locationIdsOfFirstHistorien)
        {
            if (idAmountMap.ContainsKey(id))
            {
                similarityScore += id * idAmountMap[id];
            }
        }
        return similarityScore;
    }
    static private List<string> ReadOutInputFile(string inputFilePath)
    {
        string resolvedPath = Path.GetFullPath(inputFilePath);
        if (!Path.Exists(resolvedPath)) { throw new FileNotFoundException($"The file {resolvedPath} does not exists! It could not be loaded!."); }
        return File.ReadLines(resolvedPath).ToList();
    }
    static private (int First, int Second) ParseLocationIds(string locationId)
    {
        var locationIds = new Regex(@"\d+").Matches(locationId).Select(id => int.Parse(id.Value)).ToList();
        return (First: locationIds[0], Second: locationIds[1]);
    }
    static private Dictionary<int, int> CreateIdAmountMap(List<int> ids)
    {
        Dictionary<int, int> idAmountMap = new();

        foreach (int id in ids)
        {
            if (!idAmountMap.ContainsKey(id))
            {
                idAmountMap[id] = 1;
                continue;
            }
            idAmountMap[id]++;
        }
        return idAmountMap;
    }
}
