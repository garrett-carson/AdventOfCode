
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.D08;

public partial class Day08 : Solver
{
	public override string Q1(string? filename = "Input.txt") =>
		Solve(filename!, "^AAA$", "^ZZZ$");

	public override string Q2(string? filename = "Input.txt") =>
		Solve(filename!, "A$", "Z$");

	private string Solve(string filename, string startPattern, string endPattern)
	{
		var blocks = RegexUtility.Block.Split(GetInput(filename));

		var nodes = RegexUtility.Line.Split(blocks[1].TrimEnd()).Select(ParseNode).ToDictionary();

		var starts = nodes.Keys.Where(x => Regex.IsMatch(x, startPattern)).ToArray();
		var endRegex = new Regex(endPattern, RegexOptions.Compiled);

		var steps = ParseSteps(blocks[0]);

		var results = new List<long>();
		foreach (var start in starts)
		{
			var count = 0;
			var current = start;
			foreach (var step in steps)
			{
				count++;

				current = step switch
				{
					'L' => nodes[current].Left,
					'R' => nodes[current].Right,
				};

				if (endRegex.IsMatch(current))
					break;
			}
			results.Add(count);
		}

		return results.Aggregate(1L, MathUtility.LeastCommonMultiple).ToString("0");
	}

	private KeyValuePair<string, (string Left, string Right)> ParseNode(string line)
	{
		var split = RegexUtility.Words.Matches(line).Select(x => x.Value).ToList();
		return new KeyValuePair<string, (string, string)>(split[0], (split[1], split[2]));
	}

	private IEnumerable<char> ParseSteps(string input)
	{
		while(true)
		{
			foreach(var character in input)
				yield return character;
		}
	}
}

