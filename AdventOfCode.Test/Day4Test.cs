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
	public async Task Sample1Async()
	{
		Assert.AreEqual("13", await _day.Q1("Sample1.txt"));
	}

	[TestMethod]
	public async Task Sample2Async()
	{
		Assert.AreEqual("30", await _day.Q2("Sample2.txt"));
	}

	[TestMethod]
	public async void Q1()
	{
		Assert.AreEqual("23028", await _day.Q1());
	}

	[TestMethod]
	public async Task Q2Async()
	{
		Assert.AreEqual("9236992", await _day.Q2());
	}
}
