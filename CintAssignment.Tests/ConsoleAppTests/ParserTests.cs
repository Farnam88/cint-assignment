namespace CintAssignment.Tests.ConsoleAppTests;

public class ParserTests
{
    #region + StartingPointParser

    [Theory]
    [MemberData(nameof(StartingPointParserData))]
    public void StartingPointParser_ShouldExtractNums_WithAnySeparator(string input, char separator, List<int> expected)
    {
        //Arrange
        BaseParser<List<int>, char> sut = new StartingPointParser(separator);

        //Act
        var actual = sut.Pars(input);

        //Assert
        actual.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> StartingPointParserData => new List<object[]>
    {
        new object[]
        {
            "10 12", ' ', new List<int>() { 10, 12 },
        },
        new object[]
        {
            "4,5", ',', new List<int>() { 4, 5 },
        },
        new object[]
        {
            "1254#1200", '#', new List<int>() { 1254, 1200 },
        }
    };

    #endregion

    #region + CommandParser

    [Theory]
    [MemberData(nameof(CommandParserData))]
    public void CommandParser_ShouldExtractCommands_WithAnySeparator(string input, char separator,
        List<(char Direction, int Moves)> expected)
    {
        //Arrange
        BaseParser<IList<(char Direction, int Moves)>, char> sut = new CommandParser(separator);

        //Act
        var actual = sut.Pars(input);

        //Assert
        actual.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> CommandParserData => new List<object[]>
    {
        new object[]
        {
            "E 2 N 1", ' ', new List<(char Direction, int Moves)>() { ('E', 2), ('N', 1) },
        },
        new object[]
        {
            "E,2,N,1", ',', new List<(char Direction, int Moves)>() { ('E', 2), ('N', 1) },
        },
        new object[]
        {
            "E$2$N$1", '$', new List<(char Direction, int Moves)>() { ('E', 2), ('N', 1) },
        },
    };

    #endregion
}