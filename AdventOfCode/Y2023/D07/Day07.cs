namespace AdventOfCode.Y2023.D07;

public class Day07 : Solver
{
	public override string Q1(string? filename = "Input.txt")
	{
		return Solve(filename!, GetHandType, PRIORITY);
	}

	public override string Q2(string? filename = "Input.txt")
	{
		return Solve(filename!, GetHandType2, PRIORITY2);
	}

	private const string PRIORITY = "23456789TJQKA";
	private const string PRIORITY2 = "J23456789TQKA";

	private string Solve(string filename, Func<string, HandType> getHandType, string priority)
	{
		var lines = GetInputLines(filename);
		var hands = lines.Select(line =>
		{
			var split = RegexUtility.Whitespace.Split(line);
			return new Hand(split[0], int.Parse(split[1]), getHandType(split[0]), HandToPriority(priority, split[0]));
		});
		var ordered = hands.OrderBy(x => x.Type)
			.ThenBy(x => x.PriorityArray[0])
			.ThenBy(x => x.PriorityArray[1])
			.ThenBy(x => x.PriorityArray[2])
			.ThenBy(x => x.PriorityArray[3])
			.ThenBy(x => x.PriorityArray[4])
			.ToList();

		return ordered
			.Select((hand, rank) => (long)(rank + 1) * hand.Bid)
			.Sum()
			.ToString("0");
	}

	private int[] HandToPriority(string priorityList, string cards)
	{
		return cards.Select(x => priorityList.IndexOf(x)).ToArray();
	}

	private HandType GetHandType(string hand)
	{
		var occurence = hand.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
		if (occurence.Any(x => x.Value == 5))
			return HandType.FiveOfAKind;
		if (occurence.Any(x => x.Value == 4))
			return HandType.FourOfAKind;
		var pairs = occurence.Count(x => x.Value == 2);
		if (occurence.Any(x => x.Value == 3))
		{
			if(pairs == 1)
				return HandType.FullHouse;
			return HandType.ThreeOfAKind;
		}
		if (pairs == 2)
			return HandType.TwoPair;
		if (pairs == 1)
			return HandType.OnePair;

		return HandType.HighCard;
	}

	private HandType GetHandType2(string hand)
	{
		var possibleHands = new List<string>();
		var handsToCheck = new Queue<string>();
		handsToCheck.Enqueue(hand);
		while (handsToCheck.Any())
		{
			var toCheck = handsToCheck.Dequeue();
			
			if (!toCheck.Contains('J'))
			{
				possibleHands.Add(toCheck);
				continue;
			}

			var split = toCheck.Split(['J'], 2);
			foreach(var c in PRIORITY2.Skip(1))
			{
				handsToCheck.Enqueue($"{split[0]}{c}{split[1]}");
			}
		}
		return possibleHands.Select(GetHandType).Max();
	}

	private record Hand(string Cards, int Bid, HandType Type, int[] PriorityArray);

	private enum HandType
	{
		HighCard,
		OnePair,
		TwoPair,
		ThreeOfAKind,
		FullHouse,
		FourOfAKind,
		FiveOfAKind,
	}
}

