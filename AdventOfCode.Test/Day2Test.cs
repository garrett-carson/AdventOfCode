using AdventOfCode.Day.Two;

namespace AdventOfCode.Test;

[TestClass]
public class Day2Test
{
	private readonly DayBase _day;

	public Day2Test()
	{
		_day = new Day2();
	}

	[TestMethod]
	public async Task Sample1Async()
	{
		Assert.AreEqual("8", await _day.Q1("Sample1.txt"));
	}

	[TestMethod]
	public async Task Sample2Async()
	{
		Assert.AreEqual("2286", await _day.Q2("Sample2.txt"));
	}

	[TestMethod]
	public async Task Q1Async()
	{
		Assert.AreEqual("2683", await _day.Q1());
	}

	[TestMethod]
	public async Task Q2Async()
	{
		Assert.AreEqual("49710", await _day.Q2());
	}
}