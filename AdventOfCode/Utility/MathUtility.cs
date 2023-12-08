namespace AdventOfCode.Utility;

public class MathUtility
{
	public static long LeastCommonMultiple(long a, long b) => a * b / GreatestCommonDenominator(a, b);
	public static long GreatestCommonDenominator(long a, long b) => b == 0 ? a : GreatestCommonDenominator(b, a % b);
}
