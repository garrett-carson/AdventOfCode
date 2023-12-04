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
	public void Sample1()
	{
		Assert.AreEqual("8", _day.Q1("Sample1.txt"));
	}

	[TestMethod]
	public void Sample2()
	{
		Assert.AreEqual("2286", _day.Q2("Sample2.txt"));
	}

	[TestMethod]
	public void Q1()
	{
		Assert.AreEqual("2683", _day.Q1());
	}

	[TestMethod]
	public void Q2()
	{
		Assert.AreEqual("49710", _day.Q2());
	}
}