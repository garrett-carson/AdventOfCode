using AdventOfCode.Day.One;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day1Test
{
	private readonly DayBase _day;

	public Day1Test()
	{
		_day = new Day1();
	}

	[Test]
	public void Sample1()
	{
		Assert.That(_day.Q1("Sample1.txt"), Is.EqualTo("142"));
	}

	[Test]
	public void Sample2()
	{
		Assert.That(_day.Q2("Sample2.txt"), Is.EqualTo("281"));
	}

	[Test]
	public void Q1()
	{
		Assert.That(_day.Q1(), Is.EqualTo("53386"));
	}

	[Test]
	public void Q2()
	{
		Assert.That(_day.Q2(), Is.EqualTo("53312"));
	}
}
