using AdventOfCode.Day.Three;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day3Test
{
	private readonly DayBase _day;

	public Day3Test()
	{
		_day = new Day3();
	}

	[Test]
	public void Sample1()
	{
		Assert.That(_day.Q1("Sample1.txt"), Is.EqualTo("4361"));
	}

	[Test]
	public void Sample2()
	{
		Assert.That(_day.Q2("Sample2.txt"), Is.EqualTo("467835"));
	}

	[Test]
	public void Q1()
	{
		Assert.That(_day.Q1(), Is.EqualTo("527144"));
	}

	[Test]
	public void Q2()
	{
		Assert.That(_day.Q2(), Is.EqualTo("81463996"));
	}
}