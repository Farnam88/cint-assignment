namespace CintAssignment.ConsoleApp.Services;

/// <summary>
/// Bridge implementation
/// </summary>
public class CommandParser : BaseParser<IList<(char Direction, int Moves)>, char>
{
    public CommandParser(char separator) : base(separator)
    {
    }

    public override IList<(char Direction, int Moves)> Pars(string input)
    {
        List<(char dir, int num)> commandDirections = new();
        int slow = 0, fast = 2;

        while (fast < input.Length)
        {
            char c = input[slow];

            while (fast < input.Length && input[fast] != Separator)
            {
                fast++;
            }

            var numStr = input[(slow + 2)..fast];
            int.TryParse(numStr, out int moves);

            commandDirections.Add((c, moves));

            slow = fast + 1;
            fast += 3;
        }

        return commandDirections;
    }
}