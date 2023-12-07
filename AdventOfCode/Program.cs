// See https://aka.ms/new-console-template for more information
using AdventOfCode;
using AdventOfCode.Y2023.D01;
using AdventOfCode.Y2023.D02;
using AdventOfCode.Y2023.D03;
using AdventOfCode.Y2023.D04;
using AdventOfCode.Y2023.D05;

foreach (var day in new IDay[]
{
	new Day01(),
	new Day02(),
	new Day03(),
	new Day04(),
	new Day05(),
})
{
	Console.WriteLine(day.GetType().Name + "Q1: " + day.Q1());
	Console.WriteLine(day.GetType().Name + "Q2: " + day.Q2());
}