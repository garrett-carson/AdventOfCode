using System.Text.RegularExpressions;

namespace AdventOfCode;

public abstract class DayBase : IDay
{
	protected static readonly Regex line = new(@"\r?\n", RegexOptions.Compiled);
	Task<string> IDay.Q1() => Q1();
	Task<string> IDay.Q2() => Q2();
	public abstract Task<string> Q1(string? filename = "Input.txt");
	public abstract Task<string> Q2(string? filename = "Input.txt");

	public string GetInput(string? filename)
	{
		filename ??= "Input.txt";

		var type = GetType();
		var assembly = type.Assembly;
		var ns = type.Namespace;

		using var stream = assembly.GetManifestResourceStream($"{ns}.{filename}");
		using var streamReader = new StreamReader(stream ?? throw new FileNotFoundException(null, $"{ns}.{filename}"));
		var input = streamReader.ReadToEnd();

		return input;
	}

	public string[] GetInputLines(string? filename)
	{
		var input = GetInput(filename);
		return line.Split(input.Trim());
	}
}