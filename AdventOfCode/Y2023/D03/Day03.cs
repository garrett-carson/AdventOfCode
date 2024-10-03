using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.D03;

public class Day03 : Solver
{
	private static readonly Regex _symbol = new(@"[^\d\n.]");
	private static readonly Regex _gear = new(@"\*");
	public override string Q1(string? filename = "Input.txt")
	{
		var lines = GetInputLines(filename);

		var answer = 0;
		for (int i = 0; i < lines.Length; i++)
		{
			var line = lines[i];
			var numbers = RegexUtility.UnsignedDigits.Matches(line).Cast<Match>();
			foreach (var match in numbers)
			{
				var matchIndex = match.Index;
				var matchLength = match.Length;
				var matchValue = int.Parse(match.Value);
				var surround = GetSurrounding(lines, i, matchIndex, matchLength);

				if (_symbol.IsMatch(surround))
				{
					answer += matchValue;
					continue;
				}
			}
		}

		return answer.ToString("0");
	}

	public static string GetSurrounding(string[] lines, int lineNo, int charNo, int length)
	{
		string? prevLine = null;
		string? currLine = null;
		string? nextLine = null;

		var maxX = lines[lineNo].Length - 1;

		var startx = charNo - 1;
		startx = startx < 0 ? 0 : startx;
		var endx = charNo + length + 1;
		endx = endx > maxX ? maxX : endx;

        if (lineNo > 0)
        {
			prevLine = lines[lineNo - 1].Substring(startx, endx - startx);
        }

		currLine = lines[lineNo].Substring(startx, endx - startx);

		if (lineNo + 1 < lines.Length)
		{
			nextLine = lines[lineNo+1].Substring(startx, endx - startx);
		}

        return $"{prevLine}\n{currLine}\n{nextLine}";
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
				numbersToCheck.AddRange(RegexUtility.UnsignedDigits.Matches(lines[lineIndex - 1]).Cast<Match>());
			}
			numbersToCheck.AddRange(RegexUtility.UnsignedDigits.Matches(lines[lineIndex]).Cast<Match>());
			if (lineIndex < lines.Length - 1)
			{
				numbersToCheck.AddRange(RegexUtility.UnsignedDigits.Matches(lines[lineIndex + 1]).Cast<Match>());
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
