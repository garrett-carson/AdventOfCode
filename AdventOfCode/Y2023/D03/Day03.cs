using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.D03;

public class Day03 : Solver
{
	private static readonly Regex _symbol = new(@"[^\d.]");
	private static readonly Regex _gear = new(@"\*");
	public override string Q1(string? filename = "Input.txt")
	{
		var lines = GetInputLines(filename);

		var answer = 0;
		for (int i = 0; i < lines.Length; i++)
		{
			var line = lines[i];
			var numbers = RegexUtility.Digits.Matches(line);
			foreach (var match in numbers.Cast<Match>())
			{
				var matchIndex = match.Index;
				var matchLength = match.Length;
				var matchValue = int.Parse(match.Value);
				if (matchIndex > 0 && _symbol.IsMatch(line[matchIndex - 1].ToString()))
				{
					answer += matchValue;
					continue;
				}
				if (match.Length + matchIndex < line.Length && _symbol.IsMatch(line[matchIndex + matchLength].ToString()))
				{
					answer += matchValue;
					continue;
				}
				if (i > 0)
				{
					if (lines[i - 1].Skip(matchIndex > 0 ? matchIndex - 1 : 0).Take(matchLength + 2).Any(x => _symbol.IsMatch(x.ToString())))
					{
						answer += matchValue;
						continue;
					}
				}
				if (i < lines.Length - 1)
				{
					if (lines[i + 1].Skip(matchIndex > 0 ? matchIndex - 1 : 0).Take(matchLength + 2).Any(x => _symbol.IsMatch(x.ToString())))
					{
						answer += matchValue;
						continue;
					}
				}
			}
		}

		return answer.ToString("0");
	}

	public override string Q2(string? filename = "Input.txt")
	{
		var lines = GetInputLines(filename);
		var answer = 0;
		int lineNo = 0;
		var gears = new List<(int lineIndex, int characterIndex)>();
		foreach (var line in lines)
		{
			var lineGears = _gear.Matches(line);
			foreach (var gear in lineGears.Cast<Match>())
			{
				gears.Add((lineNo, gear.Index));
			}
			lineNo++;
		}

		foreach (var (lineIndex, characterIndex) in gears)
		{
			var numbersToCheck = new List<Match>();
			if (lineIndex > 0)
			{
				numbersToCheck.AddRange(RegexUtility.Digits.Matches(lines[lineIndex - 1]).Cast<Match>());
			}
			numbersToCheck.AddRange(RegexUtility.Digits.Matches(lines[lineIndex]).Cast<Match>());
			if (lineIndex < lines.Length - 1)
			{
				numbersToCheck.AddRange(RegexUtility.Digits.Matches(lines[lineIndex + 1]).Cast<Match>());
			}

			var numbersToMult = new List<int>();
			var min = characterIndex - 1;
			var max = characterIndex + 1;
			foreach (var toCheck in numbersToCheck)
			{
				var start = toCheck.Index;
				var end = start + toCheck.Length - 1;

				if (min <= end && max >= start) // if ranges overlap, see for proof: https://stackoverflow.com/a/325964
				{
					numbersToMult.Add(int.Parse(toCheck.Value));
				}
			}
			if (numbersToMult.Count >= 2)
			{
				answer += numbersToMult.Aggregate(1, (x, y) => x * y);
			}
		}
		return answer.ToString("0");
	}
}
