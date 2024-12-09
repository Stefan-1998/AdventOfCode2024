using System.Text.RegularExpressions;
using System.Reflection;
using System.Numerics;

namespace Day4;

public class Day4Logic
{
    private int wordSearchWidth;
    private int wordSearchHeigth;

    private List<string> wordSearchPuzzle = new();
    public string Part1(string inputFilePath)
    {
        wordSearchPuzzle = ReadOutInputFile(inputFilePath).ToList();
        wordSearchHeigth = wordSearchPuzzle.Count;
        wordSearchWidth = wordSearchPuzzle[0].Length;

        var xLetterPositions = FilterOutXLetterPositions('X');

        int foundXmasStrings = 0;
        foreach (var foundX in xLetterPositions)
        {
            foundXmasStrings += CheckForXmasStringInAllDirections(foundX.X, foundX.Y);
        }
        return foundXmasStrings.ToString();
    }
    public string Part2(string inputFilePath)
    {
        wordSearchPuzzle = ReadOutInputFile(inputFilePath).ToList();
        wordSearchHeigth = wordSearchPuzzle.Count;
        wordSearchWidth = wordSearchPuzzle[0].Length;

        int amountOfMasInXForm = 0;
        var aLetterPositions = FilterOutXLetterPositions('A');
        foreach (var foundA in aLetterPositions)
        {
            if (IsMasInXForm(foundA.X, foundA.Y)) { amountOfMasInXForm++; }
        }

        return amountOfMasInXForm.ToString();
    }

    private List<(int X, int Y)> FilterOutXLetterPositions(char letterToFind)
    {
        var foundLetters = new List<(int, int)>();
        for (int i = 0; i < wordSearchPuzzle.Count; i++)
        {
            for (int j = 0; j < wordSearchPuzzle[i].Length; j++)
            {
                if (wordSearchPuzzle[i][j] == letterToFind)
                {
                    foundLetters.Add((j, i));
                }
            }
        }
        return foundLetters;
    }

    private bool IsMasInXForm(int x, int y)
    {
        if (IsXOutofBounds(x, y)) { return false; }
        if (HasXOrAInDiagonal(x, y)) { return false; }

        return HasCorrectDiagonalArms(x, y);
    }
    private bool HasCorrectDiagonalArms(int x, int y)
    {
        if (wordSearchPuzzle[y + 1][x + 1] == wordSearchPuzzle[y - 1][x - 1]) { return false; }
        if (wordSearchPuzzle[y - 1][x + 1] == wordSearchPuzzle[y + 1][x - 1]) { return false; }
        return true;

    }
    private bool IsXOutofBounds(int x, int y)
    {
        if (x - 1 < 0) { return true; }
        if (x + 1 >= wordSearchWidth) { return true; }
        if (y - 1 < 0) { return true; }
        if (y + 1 >= wordSearchHeigth) { return true; }
        return false;
    }

    private bool HasXOrAInDiagonal(int x, int y)
    {
        if (wordSearchPuzzle[y + 1][x + 1] == 'X') { return true; }
        if (wordSearchPuzzle[y - 1][x - 1] == 'X') { return true; }
        if (wordSearchPuzzle[y - 1][x + 1] == 'X') { return true; }
        if (wordSearchPuzzle[y + 1][x - 1] == 'X') { return true; }
        if (wordSearchPuzzle[y + 1][x + 1] == 'A') { return true; }
        if (wordSearchPuzzle[y - 1][x - 1] == 'A') { return true; }
        if (wordSearchPuzzle[y - 1][x + 1] == 'A') { return true; }
        if (wordSearchPuzzle[y + 1][x - 1] == 'A') { return true; }
        return false;
    }


    private int CheckForXmasStringInAllDirections(int x, int y)
    {
        int xmasStringsFound = 0;
        if (IsXmasStringLeftToRight(x, y)) { xmasStringsFound++; }
        if (IsXmasStringRightToLeft(x, y)) { xmasStringsFound++; }

        if (IsXmasStringTopToBottom(x, y)) { xmasStringsFound++; }
        if (IsXmasStringBottomToTop(x, y)) { xmasStringsFound++; }

        if (IsXmasStringToTopRight(x, y)) { xmasStringsFound++; }
        if (IsXmasStringToTopLeft(x, y)) { xmasStringsFound++; }
        if (IsXmasStringToBottomLeft(x, y)) { xmasStringsFound++; }
        if (IsXmasStringToBottomRight(x, y)) { xmasStringsFound++; }

        return xmasStringsFound;
    }
    private bool IsXmasStringLeftToRight(int x, int y)
    {
        if (x + 3 >= wordSearchWidth) { return false; }
        return IsCompleteXmasString(wordSearchPuzzle[y][x], wordSearchPuzzle[y][x + 1], wordSearchPuzzle[y][x + 2], wordSearchPuzzle[y][x + 3]);
    }
    private bool IsXmasStringRightToLeft(int x, int y)
    {
        if (x - 3 < 0) { return false; }
        return IsCompleteXmasString(wordSearchPuzzle[y][x], wordSearchPuzzle[y][x - 1], wordSearchPuzzle[y][x - 2], wordSearchPuzzle[y][x - 3]);
    }
    private bool IsXmasStringTopToBottom(int x, int y)
    {
        if (y + 3 >= wordSearchHeigth) { return false; }
        return IsCompleteXmasString(wordSearchPuzzle[y][x], wordSearchPuzzle[y + 1][x], wordSearchPuzzle[y + 2][x], wordSearchPuzzle[y + 3][x]);
    }
    private bool IsXmasStringBottomToTop(int x, int y)
    {
        if (y - 3 < 0) { return false; }
        return IsCompleteXmasString(wordSearchPuzzle[y][x], wordSearchPuzzle[y - 1][x], wordSearchPuzzle[y - 2][x], wordSearchPuzzle[y - 3][x]);
    }

    private bool IsXmasStringToTopRight(int x, int y)
    {
        if (x + 3 >= wordSearchWidth) { return false; }
        if (y + 3 >= wordSearchHeigth) { return false; }
        return IsCompleteXmasString(wordSearchPuzzle[y][x], wordSearchPuzzle[y + 1][x + 1], wordSearchPuzzle[y + 2][x + 2], wordSearchPuzzle[y + 3][x + 3]);
    }
    private bool IsXmasStringToBottomLeft(int x, int y)
    {
        if (x - 3 < 0) { return false; }
        if (y - 3 < 0) { return false; }
        return IsCompleteXmasString(wordSearchPuzzle[y][x], wordSearchPuzzle[y - 1][x - 1], wordSearchPuzzle[y - 2][x - 2], wordSearchPuzzle[y - 3][x - 3]);
    }
    private bool IsXmasStringToTopLeft(int x, int y)
    {
        if (x - 3 < 0) { return false; }
        if (y + 3 >= wordSearchHeigth) { return false; }
        return IsCompleteXmasString(wordSearchPuzzle[y][x], wordSearchPuzzle[y + 1][x - 1], wordSearchPuzzle[y + 2][x - 2], wordSearchPuzzle[y + 3][x - 3]);
    }
    private bool IsXmasStringToBottomRight(int x, int y)
    {
        if (x + 3 >= wordSearchWidth) { return false; }
        if (y - 3 < 0) { return false; }
        return IsCompleteXmasString(wordSearchPuzzle[y][x], wordSearchPuzzle[y - 1][x + 1], wordSearchPuzzle[y - 2][x + 2], wordSearchPuzzle[y - 3][x + 3]);
    }
    private bool IsCompleteXmasString(char firstLetter, char secondLetter, char thirdLetter, char fourthLetter)
    {
        if (firstLetter != 'X')
        {
            return false;
        }
        if (secondLetter != 'M')
        {
            return false;
        }
        if (thirdLetter != 'A')
        {
            return false;
        }
        if (fourthLetter != 'S')
        {
            return false;
        }
        return true;
    }

    private List<string> ReadOutInputFile(string inputFilePath)
    {
        string resolvedPath = Path.GetFullPath(inputFilePath);
        if (!Path.Exists(resolvedPath)) { throw new FileNotFoundException($"The file {resolvedPath} does not exists! It could not be loaded!."); }
        return File.ReadLines(resolvedPath).ToList();
    }
}

