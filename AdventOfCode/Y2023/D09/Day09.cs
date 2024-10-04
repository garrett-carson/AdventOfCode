namespace AdventOfCode.Y2023.D09;

public partial class Day09 : Solver
{
	public override string Q1(string? filename = "Input.txt") => Solve(filename);

	public override string Q2(string? filename = "Input.txt") => Solve(filename, true);

	private string Solve(string? filename, bool reverse = false)
	{
		var lines = RegexUtility.Line
			.Split(GetInput(filename))
			.Where(x => !string.IsNullOrWhiteSpace(x))
			.Select(RegexUtility.ParseNumbers<long>)
			.Select(x => reverse ? x.Reverse() : x)
			.ToList();

		long sum = 0;
		foreach (var line in lines)
		{
			sum += PredictNextNumber(line);
		}

		return sum.ToString("0");
	}

	private long PredictNextNumber(IEnumerable<long> numbers)
	{
		if(!numbers.Any())
			return 0;

		var current = numbers.Last();
		var predictionFromNextLine = PredictNextNumber(Diff(numbers));

		return current + predictionFromNextLine;
	}

	public static IEnumerable<long> Diff(IEnumerable<long> numbers) =>
		numbers.Zip(numbers.Skip(1)).Select(p => p.Second - p.First).ToList();
}

