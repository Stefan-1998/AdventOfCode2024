using System.Text.RegularExpressions;
using System.Reflection;

namespace Day1;

static public class Day1Logic
{
    static public int Part1(string inputFilePath)
    {
        string resolvedPath = Path.GetFullPath(inputFilePath);
        if (!Path.Exists(resolvedPath)) { throw new FileNotFoundException($"The file {resolvedPath} does not exists! It could not be loaded!."); }
        var rawLocationIDList = File.ReadLines(resolvedPath).ToList();

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
    static private (int First, int Second) ParseLocationIds(string locationId)
    {
        var locationIds = new Regex(@"\d+").Matches(locationId).Select(id => int.Parse(id.Value)).ToList();
        return (First: locationIds[0], Second: locationIds[1]);
    }

}
