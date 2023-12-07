using System.Text.RegularExpressions;

namespace AdventOfCode.Utility;

public static class RegexUtility
{

	public static readonly Regex Digit = new(@"\d", RegexOptions.Compiled);
	public static readonly Regex Digits = new(@"\d+", RegexOptions.Compiled);
	public static readonly Regex Line = new(@"\r?\n", RegexOptions.Compiled);

	public static IEnumerable<int> ParseNumbers(string input) => ParseNumbers<int>(input);

	public static IEnumerable<T> ParseNumbers<T>(string input) where T : IParsable<T> =>
		Digits.Matches(input).Select(x => x.Value).Select(x => T.Parse(x, null)).ToList();
}
