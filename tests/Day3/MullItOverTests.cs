namespace Day3.Tests;

public class Day2Tests
{
    [TestCase("ExampleInput.txt", "161")]
    [TestCase("Input.txt", "192767529")]
    public void Part1_Test(string input, string multiplicationSum)
    {
        Assert.That(Day3Logic.Part1(Path.GetFullPath(input)), Is.EqualTo(multiplicationSum));
    }
    [TestCase("ExampleInput.txt", "48")]
    [TestCase("Input.txt", "104083373")]
    public void Part2_Test(string input, string multiplicationSum)
    {
        Assert.That(Day3Logic.Part2(Path.GetFullPath(input)), Is.EqualTo(multiplicationSum));
    }
}
