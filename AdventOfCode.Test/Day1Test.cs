using AdventOfCode.Day.One;

namespace AdventOfCode.Test;

[TestClass]
public class Day1Test
{
	private readonly DayBase _day;

	public Day1Test()
	{
		_day = new Day1();
	}

	[TestMethod]
	public async Task Sample1()
	{
		Assert.AreEqual("142", await _day.Q1("Sample1.txt"));
	}

	[TestMethod]
	public async Task Sample2Async()
	{
		Assert.AreEqual("281", await _day.Q2("Sample2.txt"));
	}

	[TestMethod]
	public async Task Q1Async()
	{
		Assert.AreEqual("53386", await _day.Q1());
	}

	[TestMethod]
	public async Task Q2Async()
	{
		Assert.AreEqual("53312", await _day.Q2());
	}
}
