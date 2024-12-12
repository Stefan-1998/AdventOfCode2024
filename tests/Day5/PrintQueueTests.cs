namespace Day5.Tests;

public class Day5Tests
{
    [TestCase("ExampleInput.txt", "143")]
    [TestCase("Input.txt", "5991")]
    public void Part1_Test(string input, string sumOfMiddleNumbers)
    {
        Assert.That(new Day5Logic().Part1(Path.GetFullPath(input)), Is.EqualTo(sumOfMiddleNumbers));
    }
    [TestCase("ExampleInput.txt", "123")]
    [TestCase("Input.txt", "5479")]
    public void Part2_Test(string input, string multiplicationSum)
    {
        Assert.That(new Day5Logic().Part2(Path.GetFullPath(input)), Is.EqualTo(multiplicationSum));
    }
}
