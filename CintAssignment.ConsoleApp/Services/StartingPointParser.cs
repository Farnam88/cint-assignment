namespace CintAssignment.ConsoleApp.Services;

/// <summary>
/// Bridge implementation
/// </summary>
public class StartingPointParser : BaseParser<List<int>, char>
{
    public StartingPointParser(char separator) : base(separator)
    {
    }

    public override List<int> Pars(string input)
    {
        List<int> result = new List<int>();
        int left = 0, right = 0;
        while (right < input.Length)
        {
            while (right < input.Length && input[right] != Separator)
            {
                right++;
            }

            var numStr = input[left..right];
            result.Add(Convert.ToInt32(numStr));
            left = right + 1;
            right = left;
        }

        return result;
    }
}