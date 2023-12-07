using AdventOfCode.Y2023.D05;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day05Test
{
	private readonly Solver _day;

	public Day05Test()
	{
		_day = new Day05();
	}

	[Test]
	public void Sample1()
	{
		Assert.That(_day.Q1("Sample1.txt"), Is.EqualTo("35"));
	}

	[Test]
	public void Sample2()
	{
		Assert.That(_day.Q2("Sample2.txt"), Is.EqualTo("46"));
	}

	[Test]
	public void Q1()
	{
		Assert.That(_day.Q1(), Is.EqualTo("3374647"));
	}

	[Test]
	public void Q2()
	{
		Assert.That(_day.Q2(), Is.EqualTo("6082852"));
	}
}