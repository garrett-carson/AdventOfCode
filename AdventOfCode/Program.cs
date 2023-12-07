// See https://aka.ms/new-console-template for more information
using AdventOfCode;
using AdventOfCode.Day.Five;
using AdventOfCode.Day.Four;
using AdventOfCode.Day.One;
using AdventOfCode.Day.Three;
using AdventOfCode.Day.Two;

foreach (var day in new IDay[]
{
	new Day1(),
	new Day2(),
	new Day3(),
	new Day4(),
	new Day5(),
})
{
	Console.WriteLine(day.GetType().Name + "Q1: " + await day.Q1());
	Console.WriteLine(day.GetType().Name + "Q2: " + await day.Q2());
}