using AdventOfCode.Y2023.D02;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day02Test
{
	private readonly Solver _day;

	public Day02Test()
	{
		_day = new Day02();
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