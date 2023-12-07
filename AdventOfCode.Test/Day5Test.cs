using AdventOfCode.Day.Five;

namespace AdventOfCode.Test;

[TestClass]
public class Day5Test
{
	private readonly DayBase _day;

	public Day5Test()
	{
		_day = new Day5();
	}

	[TestMethod]
	public async Task Sample1Async()
	{
		Assert.AreEqual("35", await _day.Q1("Sample1.txt"));
	}

	[TestMethod]
	public async Task Sample2Async()
	{
		Assert.AreEqual("46", await _day.Q2("Sample2.txt"));
	}

	[TestMethod]
	public async Task Q1Async()
	{
		Assert.AreEqual("3374647", await _day.Q1());
	}

	[TestMethod]
	public async Task Q2Async()
	{
		Assert.AreEqual("6082852", await _day.Q2());
	}
}