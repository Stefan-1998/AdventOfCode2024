using System.Numerics;
namespace Day22;

public class Day22Logic
{
    public string Part1(string inputFilePath)
    {
        List<string> initialSecretNumbers = ReadOutInputFile(inputFilePath);
        List<SecretNumber> number = new List<SecretNumber>();
        foreach (string initialSecretNumber in initialSecretNumbers)
        {
            number.Add(new SecretNumber(long.Parse(initialSecretNumber)));
        }
        while (number[0].Generation < 2000)
        {
            foreach (var secret in number)
            {
                secret.GenerateNewSequenze();
            }
        }
        long returnSum = 0;
        foreach (var secret in number)
        {
            returnSum += secret.Value;
        }

        return returnSum.ToString();
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

    public class SecretNumber
    {
        public long Value { get; set; }

        public long Generation { get; set; }
        public SecretNumber(long initialNumber)
        {
            Value = initialNumber;
            Generation = 0;
        }

        public void GenerateNewSequenze()
        {
            Generation++;
            firstSequenze();
            secondSequenze();
            thirdSequenze();
        }

        private void firstSequenze()
        {
            mix(Value * 64);
            prune();
        }
        private void secondSequenze()
        {
            mix(Value / 32);
            prune();
        }
        private void thirdSequenze()
        {
            mix(Value * 2048);
            prune();
        }

        private void mix(long givenNumber)
        {
            Value = Value ^ givenNumber;
        }
        private void prune()
        {
            Value = Value % 16777216;
        }
    }

}


