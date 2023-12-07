namespace AdventOfCode.Utility;

public static class RangeExtensions
{
	public static bool Intersects(this Range r1, Range r2) => r1.From <= r2.To && r2.From <= r1.To;
}