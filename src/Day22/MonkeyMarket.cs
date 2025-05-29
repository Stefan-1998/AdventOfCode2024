using System.Numerics;
namespace Day22;

public class Day22Logic
{
    public string Part1(string inputFilePath)
    {
        var input = ReadOutInputFile(inputFilePath);
        return string.Empty;
    }
    public string Part2(string inputFilePath)
    {
        return string.Empty;
    }


    private List<string> ReadOutInputFile(string inputFilePath)
    {
        string resolvedPath = Path.GetFullPath(inputFilePath);
        if (!Path.Exists(resolvedPath)) { throw new FileNotFoundException($"The file {resolvedPath} does not exists! It could not be loaded!."); }
        return File.ReadLines(resolvedPath).ToList();
    }
}


