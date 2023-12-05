using AdventOfCode.Day.Four;

namespace AdventOfCode.Test;

[TestClass]
public class Day4Test
{
	private readonly DayBase _day;

	public Day4Test()
	{
		_day = new Day4();
	}

	[TestMethod]
	public void Sample1()
	{
		Assert.AreEqual("13", _day.Q1("Sample1.txt"));
	}

	[TestMethod]
	public void Sample2()
	{
		Assert.AreEqual("30", _day.Q2("Sample2.txt"));
	}

	[TestMethod]
	public void Q1()
	{
		Assert.AreEqual("23028", _day.Q1());
	}

	[TestMethod]
	public void Q2()
	{
		Assert.AreEqual("9236992", _day.Q2());
	}
}