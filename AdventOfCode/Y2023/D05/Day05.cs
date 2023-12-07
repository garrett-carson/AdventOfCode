using System.Text.RegularExpressions;
using Range = AdventOfCode.Utility.Range;

namespace AdventOfCode.Y2023.D05;

public class Day05 : Solver
{
	public override string Q1(string? filename = "Input.txt")
	{
		return Solve(GetInput(filename), PartOneRanges).ToString("0");
	}

	public override string Q2(string? filename = "Input.txt")
	{
		return Solve(GetInput(filename), PartTwoRanges).ToString("0");
	}

	private long Solve(string input, Func<IEnumerable<long>, IEnumerable<Range>> parseSeeds)
	{
		var blocks = Regex.Split(input, @"\r?\n\r?\n");
		var seedRanges = parseSeeds(RegexUtility.ParseNumbers<long>(blocks[0])).ToArray();
		var maps = blocks.Skip(1).Select(ParseMap).ToArray();

		// Project each range through the series of maps, this will result some
		// new ranges. Return the leftmost value (minimum) of these.
		return maps.Aggregate(seedRanges, Project).Select(r => r.From).Min();
	}

	private Range[] Project(Range[] inputRanges, Dictionary<Range, Range> map)
	{
		var todo = new Queue<Range>();
		foreach (var range in inputRanges)
		{
			todo.Enqueue(range);
		}

		var outputRanges = new List<Range>();
		while (todo.Count != 0)
		{
			var range = todo.Dequeue();
			// If no entry intersects our range -> just add it to the output. 
			// If an entry completely contains the range -> add after mapping.
			// Otherwise, some entry partly covers the range. In this case 'chop' 
			// the range into two halfs getting rid of the intersection. The new 
			// pieces are added back to the queue for further processing and will be 
			// ultimately consumed by the first two cases.
			var src = map.Keys.FirstOrDefault(src => src.Intersects(range));
			if (src == null)
			{
				outputRanges.Add(range);
			}
			else if (src.From <= range.From && range.To <= src.To)
			{
				var dst = map[src];
				var shift = dst.From - src.From;
				outputRanges.Add(new Range(range.From + shift, range.To + shift));
			}
			else if (range.From < src.From)
			{
				todo.Enqueue(new Range(range.From, src.From - 1));
				todo.Enqueue(new Range(src.From, range.To));
			}
			else
			{
				todo.Enqueue(new Range(range.From, src.To));
				todo.Enqueue(new Range(src.To + 1, range.To));
			}
		}
		return [.. outputRanges];
	}

	// consider each number as a range of 1 length
	private IEnumerable<Range> PartOneRanges(IEnumerable<long> numbers) =>
		from n in numbers select new Range(n, n);

	// chunk is a great way to iterate over the pairs of numbers
	private IEnumerable<Range> PartTwoRanges(IEnumerable<long> numbers) =>
		from c in numbers.Chunk(2) select new Range(c[0], c[0] + c[1] - 1);

	private Dictionary<Range, Range> ParseMap(string input) => (
		from line in RegexUtility.Line.Split(input).Skip(1)
		let parts = line.Split(" ").Select(long.Parse).ToArray()
		let dstStart = parts[0]
		let srcStart = parts[1]
		let rangeLength = parts[2]
		let src = new Range(srcStart, rangeLength + srcStart - 1)
		let dst = new Range(dstStart, rangeLength + dstStart - 1)
		select new KeyValuePair<Range, Range>(src, dst)
	).ToDictionary();
}
