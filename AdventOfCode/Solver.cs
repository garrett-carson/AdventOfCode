﻿using System.Text.RegularExpressions;

namespace AdventOfCode;

public abstract class Solver : IDay
{
	protected static readonly Regex x = new(@"\r?\n");
	public abstract string Q1(string? filename = "Input.txt");
	public abstract string Q2(string? filename = "Input.txt");

	public string GetInput(string? filename)
	{
		filename ??= "Input.txt";

		if (filename.Equals("Input.txt", StringComparison.CurrentCultureIgnoreCase))
			return DownloadInput(filename);

		var type = GetType();
		var assembly = type.Assembly;
		var ns = type.Namespace;

		return File.ReadAllText(Path.Combine(ns.Split('.').SkipWhile(x => x != "AdventOfCode").Skip(1).Concat(new[] { filename }).ToArray()));
	}

	private string DownloadInput(string filename)
	{
		//TODO: Download input. For now, just save it manually

		var type = GetType();
		var assembly = type.Assembly;
		var ns = type.Namespace;

		return File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", type.Name + ".txt"));
	}

	public string[] GetInputLines(string? filename)
	{
		var input = GetInput(filename);
		return x.Split(input.Trim());
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