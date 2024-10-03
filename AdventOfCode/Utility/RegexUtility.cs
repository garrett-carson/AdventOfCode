using System.Text.RegularExpressions;

namespace AdventOfCode.Utility;

public static class RegexUtility
{

	public static readonly Regex Digit = new(@"\d", RegexOptions.Compiled);
	public static readonly Regex Digits = new(@"-?\d+", RegexOptions.Compiled);
	public static readonly Regex UnsignedDigits = new(@"\d+", RegexOptions.Compiled);
	public static readonly Regex Line = new(@"\r?\n", RegexOptions.Compiled);
	public static readonly Regex Block = new(@"\r?\n\r?\n", RegexOptions.Compiled);
	public static readonly Regex Whitespace = new(@"(?s)\s+", RegexOptions.Compiled);
	public static readonly Regex Words = new(@"[a-zA-Z0-9]+", RegexOptions.Compiled);

	public static int[] ParseNumbers(string input) => ParseNumbers<int>(input);

	public static T[] ParseNumbers<T>(string input) where T : IParsable<T> =>
		Digits.Matches(input).Select(x => x.Value).Select(x => T.Parse(x, null)).ToArray();
}
