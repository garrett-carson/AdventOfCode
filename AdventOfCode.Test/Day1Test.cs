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
	public void Sample1()
	{
		Assert.AreEqual("142", _day.Q1("Sample1.txt"));
	}

	[TestMethod]
	public void Sample2()
	{
		Assert.AreEqual("281", _day.Q2("Sample2.txt"));
	}

	[TestMethod]
	public void Q1()
	{
		Assert.AreEqual("53386", _day.Q1());
	}

	[TestMethod]
	public void Q2()
	{
		Assert.AreEqual("53312", _day.Q2());
	}
}
