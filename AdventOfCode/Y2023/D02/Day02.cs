using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.D02;

public class Day02 : Solver
{
	private readonly Regex _game = new(@"(?i)^Game (?<GameNo>\d+):\s+(?<Data>.+)$");
	private readonly Regex _data = new(@"(\d+)\s+(\w+)");

	public override string Q1(string? filename = "Input.txt")
	{
		var input = GetInputLines(filename);
		var answer = 0;
		var @params = JsonConvert.DeserializeObject<IDictionary<string, int>>(GetInput(Path.GetFileNameWithoutExtension(filename) + ".param.json"))!;

		foreach (var line in input)
		{
			var gameMatch = _game.Match(line);
			Debug.Assert(gameMatch.Success);

			var gameNo = int.Parse(gameMatch.Groups["GameNo"].Value);
			var data = gameMatch.Groups["Data"].Value;
			var maxPerColor = new Dictionary<string, int>();

			foreach (var match in _data.Matches(data).Cast<Match>())
			{
				var color = match.Groups[2].Value;
				var number = int.Parse(match.Groups[1].Value);

				if (!maxPerColor.TryGetValue(color, out var existing) || existing < number)
				{
					maxPerColor[color] = number;
				}
			}

			if (@params.All(x => maxPerColor[x.Key] <= x.Value))
				answer += gameNo;
		}

		return answer.ToString("0");
	}

	public override string Q2(string? filename = "Input.txt")
	{
		var input = GetInputLines(filename);
		var answer = 0;

		foreach (var line in input)
		{
			var gameMatch = _game.Match(line);
			Debug.Assert(gameMatch.Success);

			var gameNo = int.Parse(gameMatch.Groups["GameNo"].Value);
			var data = gameMatch.Groups["Data"].Value;
			var maxPerColor = new Dictionary<string, int>();

			foreach (var match in _data.Matches(data).Cast<Match>())
			{
				var color = match.Groups[2].Value;
				var number = int.Parse(match.Groups[1].Value);

				if (!maxPerColor.TryGetValue(color, out var existing) || existing < number)
				{
					maxPerColor[color] = number;
				}
			}

			var power = maxPerColor.Aggregate(1, (x, y) => x * y.Value);

			answer += power;
		}

		return answer.ToString("0");
	}
}