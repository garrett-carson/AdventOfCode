using AdventOfCode.Day.Three;

namespace AdventOfCode.Test;

[TestClass]
public class Day3Test
{
	private readonly DayBase _day;

	public Day3Test()
	{
		_day = new Day3();
	}

	[TestMethod]
	public async Task Sample1Async()
	{
		Assert.AreEqual("4361", await _day.Q1("Sample1.txt"));
	}

	[TestMethod]
	public async Task Sample2Async()
	{
		Assert.AreEqual("467835", await _day.Q2("Sample2.txt"));
	}

	[TestMethod]
	public async Task Q1Async()
	{
		Assert.AreEqual("527144", await _day.Q1());
	}

	[TestMethod]
	public async Task Q2Async()
	{
		Assert.AreEqual("81463996", await _day.Q2());
	}
}