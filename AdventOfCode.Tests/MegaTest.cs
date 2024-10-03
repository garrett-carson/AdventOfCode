using AdventOfCode.Y2023.D03;

namespace AdventOfCode.Tests;

public class MegaTest
{
	[Theory]
	[InlineData(1, 1, "Sample1.txt", "142")]
	[InlineData(1, 2, "Sample2.txt", "281")]
	[InlineData(1, 1, "Input.txt", "55208")]
	[InlineData(1, 2, "Input.txt", "54578")]

	[InlineData(2, 1, "Sample1.txt", "8")]
	[InlineData(2, 2, "Sample2.txt", "2286")]
	[InlineData(2, 1, "Input.txt", "2176")]
	[InlineData(2, 2, "Input.txt", "63700")]

	[InlineData(3, 1, "Sample1.txt", "4361")]
	[InlineData(3, 2, "Sample2.txt", "467835")]
	[InlineData(3, 1, "Input.txt", "540212")]
	[InlineData(3, 2, "Input.txt", "87605697")]

	[InlineData(4, 1, "Sample1.txt", "13")]
	[InlineData(4, 2, "Sample2.txt", "30")]
	[InlineData(4, 1, "Input.txt", "21959")]
	[InlineData(4, 2, "Input.txt", "5132675")]

	[InlineData(5, 1, "Sample1.txt", "35")]
	[InlineData(5, 2, "Sample2.txt", "46")]
	[InlineData(5, 1, "Input.txt", "26273516")]
	[InlineData(5, 2, "Input.txt", "34039469")]

	[InlineData(6, 1, "Sample1.txt", "288")]
	[InlineData(6, 2, "Sample2.txt", "71503")]
	[InlineData(6, 1, "Input.txt", "2344708")]
	[InlineData(6, 2, "Input.txt", "30125202")]

	[InlineData(7, 1, "Sample1.txt", "6440")]
	[InlineData(7, 2, "Sample2.txt", "5905")]
	[InlineData(7, 1, "Input.txt", "249483956")]
	[InlineData(7, 2, "Input.txt", "252137472")]

	[InlineData(8, 1, "Sample1.txt", "2")]
	[InlineData(8, 2, "Sample2.txt", "6")]
	[InlineData(8, 2, "Sample3.txt", "6")]
	[InlineData(8, 1, "Input.txt", "15871")]
	[InlineData(8, 2, "Input.txt", "11283670395017")]

	[InlineData(9, 1, "Sample1.txt", "114")]
	[InlineData(9, 2, "Sample2.txt", "5")]
	[InlineData(9, 1, "Input.txt", "1842168671")]
	[InlineData(9, 2, "Input.txt", "903")]
	public async Task Test(int day, int question, string fileName, string expected)
	{
		var solver = Program.Days.Single(x => x.GetType().Name == $"Day{day:00}");
		string? result = question switch
		{
			1 => solver.Q1(fileName),
			2 => solver.Q2(fileName),
			_ => throw new InvalidOperationException(),
		};
		Assert.Equal(expected, result);
	}
}

public class Test03
{
	[Fact]
	public void Test()
	{
		var array = new string[] {
			"0123456789",
			"0me3456789",
			"0123456789",
		};

		var surround = Day03.GetSurrounding(array, 1, 1, 2);
		Assert.Equal("0123\n0me3\n0123", surround);
	}
}
