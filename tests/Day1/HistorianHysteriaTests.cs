namespace Day1.Tests;

public class Day1Tests
{
    [TestCase("ExampleInput.txt", 11)]
    [TestCase("Input.txt", 1222801)]
    public void Part1_Test(string input, int totalDistanceSolution)
    {
        Assert.That(Day1Logic.Part1(Path.GetFullPath(input)), Is.EqualTo(totalDistanceSolution));
    }
}
