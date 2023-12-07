using AdventOfCode.Y2023.D06;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day06Test
{
	private readonly Solver _day;

	public Day06Test()
	{
		_day = new Day06();
	}

	[Test]
	public void Sample1()
	{
		Assert.That(_day.Q1("Sample1.txt"), Is.EqualTo("288"));
	}

	[Test]
	public void Sample2()
	{
		Assert.That(_day.Q2("Sample2.txt"), Is.EqualTo("71503"));
	}

	[Test]
	public void Q1()
	{
		Assert.That(_day.Q1(), Is.EqualTo("800280"));
	}

	[Test]
	public void Q2()
	{
		Assert.That(_day.Q2(), Is.EqualTo("45128024"));
	}
}