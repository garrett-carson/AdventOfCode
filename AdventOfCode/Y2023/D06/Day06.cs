namespace AdventOfCode.Y2023.D06;

public class Day06 : Solver
{
	public override string Q1(string? filename = "Input.txt")
	{
		var lines = GetInputLines(filename);
		var times = RegexUtility.ParseNumbers(lines[0]).ToList();
		var distancesToBeat = RegexUtility.ParseNumbers(lines[1]).ToList();
		var answer = 1;
		for (int raceNumber = 0; raceNumber < times.Count; raceNumber++)
		{
			var raceTime = times[raceNumber];
			var raceDistanceToBeat = distancesToBeat[raceNumber];
			var raceOptions = 0;

			for(int timeHolding = 0; timeHolding <= raceTime; timeHolding++)
			{
				var speed = timeHolding;
				var timeToTravel = raceTime - timeHolding;
				var travelled = timeToTravel * speed;
				if(travelled > raceDistanceToBeat)
				{
					raceOptions++;
				}
			}
			answer *= raceOptions;
		}
		return answer.ToString("0");
	}

	public override string Q2(string? filename = "Input.txt")
	{
		var lines = GetInputLines(filename);
		var raceTime = long.Parse(string.Join(string.Empty, RegexUtility.Digits.Matches(lines[0])));
		var raceDistanceToBeat = long.Parse(string.Join(string.Empty, RegexUtility.Digits.Matches(lines[1])));

		var raceOptions = 0;

		for(int timeHolding = 0; timeHolding <= raceTime; timeHolding++)
		{
			var speed = timeHolding;
			var timeToTravel = raceTime - timeHolding;
			var travelled = timeToTravel * speed;
			if(travelled > raceDistanceToBeat)
			{
				raceOptions++;
			}
		}
		return raceOptions.ToString("0");
	}
}
