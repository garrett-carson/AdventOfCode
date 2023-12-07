using AdventOfCode.Y2023.D07;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day07Test
{
	private readonly Solver _day;

	public Day07Test()
	{
		_day = new Day07();
	}

	[Test]
	public void Sample1()
	{
		Assert.That(_day.Q1("Sample1.txt"), Is.EqualTo("6440"));
	}

	[Test]
	public void Sample2()
	{
		Assert.That(_day.Q2("Sample2.txt"), Is.EqualTo("5905"));
	}

	[Test]
	public void Q1()
	{
		Assert.That(_day.Q1(), Is.EqualTo("249390788"));
	}

	[Test]
	public void Q2()
	{
		Assert.That(_day.Q2(), Is.EqualTo("248750248"));
	}
}