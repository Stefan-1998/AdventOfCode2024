namespace Day4.Tests;

public class Day4Tests
{
    [TestCase("ExampleInput.txt", "18")]
    [TestCase("Input.txt", "2493")]
    public void Part1_Test(string input, string multiplicationSum)
    {
        Assert.That(new Day4Logic().Part1(Path.GetFullPath(input)), Is.EqualTo(multiplicationSum));
    }
    [TestCase("ExampleInputPart2.txt", "9")]
    [TestCase("Input.txt", "104083373")]
    public void Part2_Test(string input, string multiplicationSum)
    {
        Assert.That(new Day4Logic().Part2(Path.GetFullPath(input)), Is.EqualTo(multiplicationSum));
    }
}
