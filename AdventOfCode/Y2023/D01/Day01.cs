using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.D01;

public class Day01 : Solver
{
	private static readonly Regex _enhancedFirstDigit;
	private static readonly Regex _enhancedLastDigit;
	private static readonly IDictionary<string, int> wordsToNumbers = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase)
	{
		{"zero", 0},
		{"one", 1},
		{"two", 2},
		{"three", 3},
		{"four", 4},
		{"five", 5},
		{"six", 6},
		{"seven", 7},
		{"eight", 8},
		{"nine", 9},
	};

	static Day01()
	{
		var pattern = @$"(\d|{string.Join("|", wordsToNumbers.Keys!)})";
		_enhancedFirstDigit = new(pattern);
		_enhancedLastDigit = new(pattern, RegexOptions.RightToLeft);
	}

	public override string Q1(string? fileName = "Input.txt")
	{
		var input = GetInputLines(fileName);
		int total = 0;
		foreach (var line in input)
		{
			var numbers = RegexUtility.Digit.Matches(line);
			var first = numbers.First();
			var last = numbers.Last();
			var value = Convert.ToInt32(string.Concat(first, last));
			total += value;
		}

		return total.ToString("0");
	}

	public override string Q2(string? fileName = "Input.txt")
	{
		var input = GetInputLines(fileName);
		int total = 0;
		foreach (var line in input)
		{
			var first = DigitToInt(_enhancedFirstDigit.Match(line).Value);
			var last = DigitToInt(_enhancedLastDigit.Match(line).Value);
			var value = Convert.ToInt32(string.Concat(first.ToString("0"), last.ToString("0")));
			total += value;
		}

		return total.ToString("0");
	}

	private static int DigitToInt(string value)
	{
		return wordsToNumbers.TryGetValue(value, out var parsed) ? parsed : int.Parse(value);
	}
}
