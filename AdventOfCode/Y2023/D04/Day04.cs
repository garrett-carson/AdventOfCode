namespace AdventOfCode.Y2023.D04;

public class Day04 : Solver
{
	public override string Q1(string? filename = "Input.txt")
	{
		var lines = GetInputLines(filename);
		var answer = 0;

		var cards = lines.Select(ParseCard).ToDictionary(x => x.Number);

		foreach (var (cardNo, card) in cards)
		{
			var points = card.WinningNumbers.Aggregate(0, (x, y) => x == 0 ? 1 : x * 2);
			answer += points;
		}

		return answer.ToString("0");
	}

	public override string Q2(string? filename = "Input.txt")
	{
		var lines = GetInputLines(filename);
		var answer = 0;

		var cards = lines.Select(ParseCard).ToDictionary(x => x.Number);

		var cardsToCheck = new Queue<int>();
		foreach (var card in cards)
		{
			cardsToCheck.Enqueue(card.Key);
		}
		var max = cards.Keys.Max();

		while (cardsToCheck.Count != 0)
		{
			answer++;
			var toCheck = cardsToCheck.Dequeue();
			var linkedWinners = cards[toCheck];
			for (int i = 1; i <= linkedWinners.WinningNumbers.Count(); i++)
			{
				if (toCheck + i <= max)
					cardsToCheck.Enqueue(toCheck + i);
			}
		}

		return answer.ToString("0");
	}

	private Card ParseCard(string line)
	{
		var split = line.Split(':', '|');
		var cardNo = RegexUtility.ParseNumbers(split[0]).First();
		var winners = RegexUtility.ParseNumbers(split[1]);
		var values = RegexUtility.ParseNumbers(split[2]);

		var valuedWinners = winners.Intersect(values);

		return new Card(cardNo, valuedWinners.ToList());
	}

	private record Card(int Number, IEnumerable<int> WinningNumbers);
}