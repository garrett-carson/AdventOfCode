using AdventOfCode.Y2023.D08;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day08Test
{
	private readonly Solver _day;

	public Day08Test()
	{
		_day = new Day08();
	}

	[Test]
	public void Sample1()
	{
		Assert.That(_day.Q1("Sample1.txt"), Is.EqualTo("2"));
	}

	[Test]
	public void Sample2()
	{
		Assert.That(_day.Q1("Sample2.txt"), Is.EqualTo("6"));
	}

	[Test]
	public void Sample3()
	{
		Assert.That(_day.Q2("Sample3.txt"), Is.EqualTo("6"));
	}

	[Test]
	public void Q1()
	{
		Assert.That(_day.Q1(), Is.EqualTo("12083"));
	}

	[Test]
	public void Q2()
	{
		Assert.That(_day.Q2(), Is.EqualTo("13385272668829"));
	}
}