using AdventOfCode.Y2023.D04;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day04Test
{
	private readonly Solver _day;

	public Day04Test()
	{
		_day = new Day04();
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
