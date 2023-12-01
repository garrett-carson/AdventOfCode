namespace AdventOfCode
{
    public abstract class DayBase : IDay
    {
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

            using var stream = assembly.GetManifestResourceStream($"{ns}.{filename}");
            using var streamReader = new StreamReader(stream ?? throw new FileNotFoundException(null, $"{ns}.{filename}"));
            var input = streamReader.ReadToEnd();

            return input;
        }
    }
}