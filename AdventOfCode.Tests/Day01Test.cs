using AdventOfCode.Y2023.D01;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day01Test
{
	private readonly Solver _day;

	public Day01Test()
	{
		_day = new Day01();
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
