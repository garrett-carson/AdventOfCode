using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.D10;

public partial class Day10 : Solver
{
	private static readonly Regex _animalRegex = new Regex("s", RegexOptions.Compiled | RegexOptions.IgnoreCase);
	public override string Q1(string? filename = "Input.txt")
	{
		int?[,] distances = GetDistances(filename);

		return distances.OfType<int>().Max().ToString("0");
	}

	private int?[,] GetDistances(string? filename)
	{
		var input = GetInput(filename);

		var lines = RegexUtility.Line.Split(input)
			.Where(x => !string.IsNullOrWhiteSpace(x))
			.Select(x => x.ToCharArray())
			.ToArray();

		var rows = lines.Count();
		var cols = lines.First().Length;

		Point? animal = null;

		for (var i = 0; i <= cols; i++)
		{
			var line = lines[i];
			var animalMatch = _animalRegex.Match(new string(line));
			if (animalMatch.Success)
			{
				animal = new Point(i, animalMatch.Index);
				break;
			}
		}

		if (animal == null) throw new InvalidOperationException("Could not determine starting point");

		var distances = new int?[rows, cols];
		var pointsToCheck = new Queue<(Point Point, Direction From, int CountSoFar)>([(animal, Direction.Self, 0)]);

		while (pointsToCheck.Any())
		{
			var toCheck = pointsToCheck.Dequeue();
			var point = toCheck.Point;
			var from = toCheck.From;
			var countSoFar = toCheck.CountSoFar;
			var value = lines[point.Row][point.Column];
			var isValid =
				(value == 'S' & from == Direction.Self)

				|| (value == '-' && (from == Direction.East || from == Direction.West))
				|| (value == '|' && (from == Direction.North || from == Direction.South))

				|| (value == 'L' && (from == Direction.North || from == Direction.East))
				|| (value == 'J' && (from == Direction.North || from == Direction.West))
				|| (value == '7' && (from == Direction.South || from == Direction.West))
				|| (value == 'F' && (from == Direction.South || from == Direction.East));

			if (!isValid)
			{
				continue;
			}

			if (distances[point.Row, point.Column] == null || distances[point.Row, point.Column].Value > countSoFar)
			{
				distances[point.Row, point.Column] = countSoFar;

				var exits = Exits[value];

				if (point.Column - 1 >= 0 && exits.Contains(Direction.West))
					pointsToCheck.Enqueue((new Point(point.Row, point.Column - 1), Direction.East, countSoFar + 1));

				if (point.Column + 1 < rows && exits.Contains(Direction.East))
					pointsToCheck.Enqueue((new Point(point.Row, point.Column + 1), Direction.West, countSoFar + 1));

				if (point.Row - 1 >= 0 && exits.Contains(Direction.North))
					pointsToCheck.Enqueue((new Point(point.Row - 1, point.Column), Direction.South, countSoFar + 1));

				if (point.Row + 1 < cols && exits.Contains(Direction.South))
					pointsToCheck.Enqueue((new Point(point.Row + 1, point.Column), Direction.North, countSoFar + 1));
			}
		}

		return distances;
	}

	public enum Direction
	{
		Self,
		North,
		South,
		East,
		West,
	}

	static readonly Dictionary<char, Direction[]> Exits = new Dictionary<char, Direction[]>{
		{'7', [Direction.West, Direction.South] },
		{'F', [Direction.East, Direction.South]},
		{'L', [Direction.North, Direction.East]},
		{'J', [Direction.North, Direction.West]},
		{'|', [Direction.North, Direction.South]},
		{'-', [Direction.East, Direction.West]},
		{'S', [Direction.North, Direction.East, Direction.South, Direction.West]},
		{'.', []},
	};

	public override string Q2(string? filename = "Input.txt")
	{
		var input = GetInput(filename);

		var lines = RegexUtility.Line.Split(input)
			.Where(x => !string.IsNullOrWhiteSpace(x))
			.Select(x => x.ToCharArray())
			.ToArray();

		var rows = lines.Count();
		var cols = lines.First().Length;

		var distances = GetDistances(filename);

		for(var row = 0; row < rows; row++)
		{
			for(var col = 0; col < cols; col++)
			{
				lines[row][col] = distances[row, col] == null ? '.' : lines[row][col];
			}
		}

		var insideArea = 0;
		var sValid = filename switch //todo: determine programmatically
		{
			"Input.txt" => true,
			"Sample3.txt" => false,
			_ => throw new NotImplementedException(),
		}; 

		for (var row = 0; row < rows; row++)
		{
			var verticalBars = 0;
			for (var col = 0; col < cols; col++)
			{
				var value = lines[row][col];
				if (value == '|' || value == 'J' || value == 'L' || (value == 'S' && sValid))
				{
					verticalBars++;
					continue;
				}
				if (verticalBars % 2 == 1 && value == '.')
				{
					insideArea++;
				}
			}
		}

		return insideArea.ToString("0");
	}

	private record Point(int Row, int Column);
}

