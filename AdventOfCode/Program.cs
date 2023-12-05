// See https://aka.ms/new-console-template for more information
using AdventOfCode;
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
})
{
	Console.WriteLine(day.GetType().Name + "Q1: " + day.Q1());
	Console.WriteLine(day.GetType().Name + "Q2: " + day.Q2());
}