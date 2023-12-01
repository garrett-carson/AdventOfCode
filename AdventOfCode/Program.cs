// See https://aka.ms/new-console-template for more information
using AdventOfCode.Day.One;

foreach (var day in new[] { new Day1() })
{
    Console.WriteLine(day.GetType().Name + "Q1: " + day.Q1());
    Console.WriteLine(day.GetType().Name + "Q2: " + day.Q2());
}