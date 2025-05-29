using Day22;

namespace Day22.Tests;

public class Day22Tests
{
    [TestCase("ExampleInput.txt", "37327623")]
    [TestCase("Input.txt", "20401393616")]
    public void Part1_Test(string input, string totalCelibrationResult)
    {
        Assert.That(new Day22Logic().Part1(Path.GetFullPath(input)), Is.EqualTo(totalCelibrationResult));
    }
    [TestCase("ExampleInput.txt", "11387")]
    [TestCase("Input.txt", "5479")]
    public void Part2_Test(string input, string totalCelibrationResult)
    {
        Assert.That(new Day22Logic().Part2(Path.GetFullPath(input)), Is.EqualTo(totalCelibrationResult));
    }
}
