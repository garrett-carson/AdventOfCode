// See https://aka.ms/new-console-template for more information
using AdventOfCode.Y2023.D01;
using AdventOfCode.Y2023.D02;
using AdventOfCode.Y2023.D03;
using AdventOfCode.Y2023.D04;
using AdventOfCode.Y2023.D05;
using AdventOfCode.Y2023.D06;
using AdventOfCode.Y2023.D07;
using AdventOfCode.Y2023.D08;

namespace AdventOfCode
{
	public class Program
	{
		public static readonly IDay[] Days =
		[
			new Day01(),
			new Day02(),
			new Day03(),
			new Day04(),
			new Day05(),
			new Day06(),
			new Day07(),
			new Day08(),
		];

		public static void Main(string[] args)
		{
			foreach (var day in Days)
			{
				Console.WriteLine(day.GetType().Name + "Q1: " + day.Q1());
				Console.WriteLine(day.GetType().Name + "Q2: " + day.Q2());
			}
		}
	}
}