using AdventOfCode.Day.Two;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day2Test
{
	private readonly DayBase _day;

	public Day2Test()
	{
		_day = new Day2();
	}

	[Test]
	public void Sample1()
	{
		Assert.That(_day.Q1("Sample1.txt"), Is.EqualTo("8"));
	}

	[Test]
	public void Sample2()
	{
		Assert.That(_day.Q2("Sample2.txt"), Is.EqualTo("2286"));
	}

	[Test]
	public void Q1()
	{
		Assert.That(_day.Q1(), Is.EqualTo("2683"));
	}

	[Test]
	public void Q2()
	{
		Assert.That(_day.Q2(), Is.EqualTo("49710"));
	}
}