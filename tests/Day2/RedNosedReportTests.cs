namespace Day2.Tests;

public class Day2Tests
{
    [TestCase("ExampleInput.txt", 2)]
    [TestCase("Input.txt", 220)]
    public void Part1_Test(string input, int totalDistanceSolution)
    {
        Assert.That(Day2Logic.Part1(Path.GetFullPath(input)), Is.EqualTo(totalDistanceSolution));
    }
    [TestCase("ExampleInput.txt", 31)]
    [TestCase("Input.txt", 22545250)]
    public void Part2_Test(string input, int similarityScore)
    {
        Assert.That(Day2Logic.Part2(Path.GetFullPath(input)), Is.EqualTo(similarityScore));
    }
}
