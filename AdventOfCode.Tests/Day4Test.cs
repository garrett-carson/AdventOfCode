using AdventOfCode.Day.Four;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day4Test
{
	private readonly DayBase _day;

	public Day4Test()
	{
		_day = new Day4();
	}

	[Test]
	public void Sample1()
	{
		Assert.That(_day.Q1("Sample1.txt"), Is.EqualTo("13"));
	}

	[Test]
	public void Sample2()
	{
		Assert.That(_day.Q2("Sample2.txt"), Is.EqualTo("30"));
	}

	[Test]
	public void Q1()
	{
		Assert.That(_day.Q1(), Is.EqualTo("23028"));
	}

	[Test]
	public void Q2()
	{
		Assert.That(_day.Q2(), Is.EqualTo("9236992"));
	}
}
