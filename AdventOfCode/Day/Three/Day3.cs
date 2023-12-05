using System.Text.RegularExpressions;

namespace AdventOfCode.Day.Three;


/// <summary>
/// --- Day 3: Gear Ratios ---
/// 
/// You and the Elf eventually reach a gondola lift station; he says the gondola lift will take you up to the water source, but this is as far as he can bring you. You go inside.
/// 
/// It doesn't take long to find the gondolas, but there seems to be a problem: they're not moving.
/// 
/// "Aaah!"
/// 
/// You turn around to see a slightly-greasy Elf with a wrench and a look of surprise. "Sorry, I wasn't expecting anyone! The gondola lift isn't working right now; it'll still be a while before I can fix it." You offer to help.
/// 
/// The engineer explains that an engine part seems to be missing from the engine, but nobody can figure out which one. If you can add up all the part numbers in the engine schematic, it should be easy to work out which part is missing.
/// 
/// The engine schematic (your puzzle input) consists of a visual representation of the engine. There are lots of numbers and symbols you don't really understand, but apparently any number adjacent to a symbol, even diagonally, is a "part number" and should be included in your sum. (Periods (.) do not count as a symbol.)
/// 
/// Here is an example engine schematic:
/// 
/// 467..114..
/// ...*......
/// ..35..633.
/// ......#...
/// 617*......
/// .....+.58.
/// ..592.....
/// ......755.
/// ...$.*....
/// .664.598..
/// 
/// In this schematic, two numbers are not part numbers because they are not adjacent to a symbol: 114 (top right) and 58 (middle right). Every other number is adjacent to a symbol and so is a part number; their sum is 4361.
/// 
/// Of course, the actual engine schematic is much larger. What is the sum of all of the part numbers in the engine schematic?
/// 
/// --- Part Two ---
/// 
/// The engineer finds the missing part and installs it in the engine! As the engine springs to life, you jump in the closest gondola, finally ready to ascend to the water source.
/// 
/// You don't seem to be going very fast, though. Maybe something is still wrong? Fortunately, the gondola has a phone labeled "help", so you pick it up and the engineer answers.
/// 
/// Before you can explain the situation, she suggests that you look out the window.There stands the engineer, holding a phone in one hand and waving with the other.You're going so slowly that you haven't even left the station.You exit the gondola.
/// 
/// The missing part wasn't the only issue - one of the gears in the engine is wrong. A gear is any * symbol that is adjacent to exactly two part numbers. Its gear ratio is the result of multiplying those two numbers together.
/// 
/// This time, you need to find the gear ratio of every gear and add them all up so that the engineer can figure out which gear needs to be replaced.
/// 
/// Consider the same engine schematic again:
/// 
/// 467..114..
/// ...*......
/// ..35..633.
/// ......#...
/// 617*......
/// .....+.58.
/// ..592.....
/// ......755.
/// ...$.*....
/// .664.598..
/// 
/// In this schematic, there are two gears. The first is in the top left; it has part numbers 467 and 35, so its gear ratio is 16345. The second gear is in the lower right; its gear ratio is 451490. (The* adjacent to 617 is not a gear because it is only adjacent to one part number.) Adding up all of the gear ratios produces 467835.
/// 
/// What is the sum of all of the gear ratios in your engine schematic?
/// </summary>
public class Day3 : DayBase
{
    private static readonly Regex _digits = new(@"\d+");
    private static readonly Regex _symbol = new(@"[^\d.]");
    private static readonly Regex _gear = new(@"\*");
    public override string Q1(string? filename = "Input.txt")
    {
        var lines = GetInputLines(filename);

        var answer = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var numbers = _digits.Matches(line);
            foreach (var match in numbers.Cast<Match>())
            {
                var matchIndex = match.Index;
                var matchLength = match.Length;
                var matchValue = int.Parse(match.Value);
                if (matchIndex > 0 && _symbol.IsMatch(line[matchIndex - 1].ToString()))
                {
                    answer += matchValue;
                    continue;
                }
                if (match.Length + matchIndex < line.Length && _symbol.IsMatch(line[matchIndex + matchLength].ToString()))
                {
                    answer += matchValue;
                    continue;
                }
                if (i > 0)
                {
                    if (lines[i - 1].Skip(matchIndex > 0 ? matchIndex - 1 : 0).Take(matchLength + 2).Any(x => _symbol.IsMatch(x.ToString())))
                    {
                        answer += matchValue;
                        continue;
                    }
                }
                if (i < lines.Length - 1)
                {
                    if (lines[i + 1].Skip(matchIndex > 0 ? matchIndex - 1 : 0).Take(matchLength + 2).Any(x => _symbol.IsMatch(x.ToString())))
                    {
                        answer += matchValue;
                        continue;
                    }
                }
            }
        }

        return answer.ToString("0");
    }

    public override string Q2(string? filename = "Input.txt")
    {
        var lines = GetInputLines(filename);
        var answer = 0;
        int lineNo = 0;
        var gears = new List<(int lineIndex, int characterIndex)>();
        foreach (var line in lines)
        {
            var lineGears = _gear.Matches(line);
            foreach (var gear in lineGears.Cast<Match>())
            {
                gears.Add((lineNo, gear.Index));
            }
            lineNo++;
        }

        foreach (var (lineIndex, characterIndex) in gears)
        {
            var numbersToCheck = new List<Match>();
            if (lineIndex > 0)
            {
                numbersToCheck.AddRange(_digits.Matches(lines[lineIndex - 1]).Cast<Match>());
            }
            numbersToCheck.AddRange(_digits.Matches(lines[lineIndex]).Cast<Match>());
            if (lineIndex < lines.Length - 1)
            {
                numbersToCheck.AddRange(_digits.Matches(lines[lineIndex + 1]).Cast<Match>());
            }

            var numbersToMult = new List<int>();
            var min = characterIndex - 1;
            var max = characterIndex + 1;
            foreach (var toCheck in numbersToCheck)
            {
                var start = toCheck.Index;
                var end = start + toCheck.Length - 1;

                if (min <= end && max >= start) // if ranges overlap, see for proof: https://stackoverflow.com/a/325964
                {
                    numbersToMult.Add(int.Parse(toCheck.Value));
                }
            }
            if (numbersToMult.Count >= 2)
            {
                answer += numbersToMult.Aggregate(1, (x, y) => x * y);
            }
        }
        return answer.ToString("0");
    }
}
