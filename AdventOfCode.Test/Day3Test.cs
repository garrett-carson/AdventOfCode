using AdventOfCode.Three;

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
	public void Sample1()
	{
		Assert.AreEqual("4361", _day.Q1("Sample1.txt"));
	}

	[TestMethod]
	public void Sample2()
	{
		Assert.AreEqual("467835", _day.Q2("Sample2.txt"));
	}

	[TestMethod]
	public void Q1()
	{
		Assert.AreEqual("527144", _day.Q1());
	}

	[TestMethod]
	public void Q2()
	{
		Assert.AreEqual("81463996", _day.Q2());
	}
}