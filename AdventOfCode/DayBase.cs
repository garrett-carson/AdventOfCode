using System.Text.RegularExpressions;

namespace AdventOfCode;

public abstract class DayBase : IDay
{
	protected static readonly Regex line = new(@"\r?\n");
	string IDay.Q1() => Q1();
	string IDay.Q2() => Q2();
	public abstract string Q1(string? filename = "Input.txt");
	public abstract string Q2(string? filename = "Input.txt");

	public string GetInput(string? filename)
	{
		filename ??= "Input.txt";

		var type = GetType();
		var assembly = type.Assembly;
		var ns = type.Namespace;

		return File.ReadAllText(Path.Combine("Day", ns.Split('.').Last(), filename));
	}

	public string[] GetInputLines(string? filename)
	{
		var input = GetInput(filename);
		return line.Split(input.Trim());
	}

	public class Old
	{
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
	}
}