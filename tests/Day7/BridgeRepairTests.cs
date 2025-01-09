using Day7;

namespace Day7.Tests;

public class Day7Tests
{
    [TestCase("ExampleInput.txt", "3749")]
    [TestCase("Input.txt", "4998764814652")]
    public void Part1_Test(string input, string totalCelibrationResult)
    {
        Assert.That(new Day7Logic().Part1(Path.GetFullPath(input)), Is.EqualTo(totalCelibrationResult));
    }
    /*[TestCase("ExampleInput.txt", "123")]
    [TestCase("Input.txt", "5479")]
    public void Part2_Test(string input, string multiplicationSum)
    {
        Assert.That(new Day7Logic().Part2(Path.GetFullPath(input)), Is.EqualTo(multiplicationSum));
    }*/
}
