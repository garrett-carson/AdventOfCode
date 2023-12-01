using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Text;

namespace AdventOfCode.Day.One;

public class Day1 : DayBase
{
    private static readonly Regex line = new(@"\r?\n", RegexOptions.Compiled);
    private static readonly Regex digits = new(@"\d", RegexOptions.Compiled);
    private static readonly IDictionary<string, string> numberWords = new Dictionary<string, string>()
    {
        {"zero", "0"},
        {"one", "1"},
        {"two", "2"},
        {"three", "3"},
        {"four", "4"},
        {"five", "5"},
        {"six", "6"},
        {"seven", "7"},
        {"eight", "8"},
        {"nine", "9"},
    };

    public override string Q1(string? fileName = "Input.txt")
    {
        var input = GetInput(fileName);
        int total = 0;
        foreach (var line in line.Split(input))
        {
            total += LineValue(line);
        }

        return total.ToString();
    }

    public override string Q2(string? fileName = "Input.txt")
    {
        var input = GetInput(fileName);
        int total = 0;
        foreach (var line in line.Split(input.Trim()))
        {
            var preParsed = PreParse(line);
            total += LineValue(preParsed);
        }

        return total.ToString();
    }

    private static string PreParse(string line)
    {
        string lineWithDigitsReplaced = line;
        foreach (var number in numberWords)
        {
            lineWithDigitsReplaced = lineWithDigitsReplaced.Replace(number.Key, string.Concat(number.Key, number.Value, number.Key));
        }
        return lineWithDigitsReplaced;

    }

    private static int LineValue(string line)
    {
        var numbers = digits.Matches(line).Select(x => x.Value);
        Debug.Assert(numbers.Any());
        var first = numbers.First();
        var last = numbers.Last();
        var value = Convert.ToInt32(string.Concat(first, last));
        return value;
    }
}
