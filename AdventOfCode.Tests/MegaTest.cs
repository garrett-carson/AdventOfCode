using AdventOfCode.Y2023.D01;

namespace AdventOfCode.Tests;

public class MegaTest
{
	[Theory]
	[InlineData(1, 1, "Sample1.txt", "142")]
	[InlineData(1, 2, "Sample2.txt", "281")]
	[InlineData(1, 1, "Input.txt", "53386")]
	[InlineData(1, 2, "Input.txt", "53312")]

	[InlineData(2, 1, "Sample1.txt", "8")]
	[InlineData(2, 2, "Sample2.txt", "2286")]
	[InlineData(2, 1, "Input.txt", "2683")]
	[InlineData(2, 2, "Input.txt", "49710")]

	[InlineData(3, 1, "Sample1.txt", "4361")]
	[InlineData(3, 2, "Sample2.txt", "467835")]
	[InlineData(3, 1, "Input.txt", "527144")]
	[InlineData(3, 2, "Input.txt", "81463996")]

	[InlineData(4, 1, "Sample1.txt", "13")]
	[InlineData(4, 2, "Sample2.txt", "30")]
	[InlineData(4, 1, "Input.txt", "23028")]
	[InlineData(4, 2, "Input.txt", "9236992")]

	[InlineData(5, 1, "Sample1.txt", "35")]
	[InlineData(5, 2, "Sample2.txt", "46")]
	[InlineData(5, 1, "Input.txt", "3374647")]
	[InlineData(5, 2, "Input.txt", "6082852")]

	[InlineData(6, 1, "Sample1.txt", "288")]
	[InlineData(6, 2, "Sample2.txt", "71503")]
	[InlineData(6, 1, "Input.txt", "800280")]
	[InlineData(6, 2, "Input.txt", "45128024")]

	[InlineData(7, 1, "Sample1.txt", "6440")]
	[InlineData(7, 2, "Sample2.txt", "5905")]
	[InlineData(7, 1, "Input.txt", "249390788")]
	[InlineData(7, 2, "Input.txt", "248750248")]

	[InlineData(8, 1, "Sample1.txt", "2")]
	[InlineData(8, 2, "Sample2.txt", "6")]
	[InlineData(8, 2, "Sample3.txt", "6")]
	[InlineData(8, 1, "Input.txt", "12083")]
	[InlineData(8, 2, "Input.txt", "13385272668829")]
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
