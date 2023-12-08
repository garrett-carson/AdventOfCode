
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.D08;

public partial class Day08 : Solver
{
	public override string Q1(string? filename = "Input.txt")
	{
		var blocks = RegexUtility.Block.Split(GetInput(filename));

		var tree = RegexUtility.Line.Split(blocks[1].TrimEnd()).Select(ParseNode).ToDictionary();
		var current = "AAA";

		var steps = ParseSteps(blocks[0]);

		var count = 0;
		foreach (var step in steps)
		{
			count++;

			current = step switch
			{
				'L' => tree[current].Left,
				'R' => tree[current].Right,
				_ => throw new NotImplementedException(),
			};

			if(current.Equals("ZZZ", StringComparison.CurrentCultureIgnoreCase))
				return count.ToString("0");
		}
		throw new NotImplementedException("Steps is assumed to be infinite");
	}

	public override string Q2(string? filename = "Input.txt")
	{
		var blocks = RegexUtility.Block.Split(GetInput(filename));

		var tree = RegexUtility.Line.Split(blocks[1].TrimEnd()).Select(ParseNode).ToDictionary();

		var starts = tree.Keys.Where(x => x[2] == 'A').ToArray();

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
					'L' => tree[current].Left,
					'R' => tree[current].Right,
				};

				if (current[2] == 'Z')
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

