namespace CintAssignment.Tests.ConsoleAppTests;

public class CommandModelBuilderTests
{
    [Theory]
    [MemberData(nameof(CommandModelBuilderData))]
    public void CommandModelBuilder_ShouldBuildRobotCleanerCommandModel_WithValidInputData(RobotCleanerCommandDto dto,
        RobotCleanerCommandModel expected)
    {
        //Arrange
        BaseParser<IList<(char Direction, int Moves)>, char> commandParser = new CommandParser(' ');
        BaseParser<List<int>, char> startingPointParser = new StartingPointParser(' ');
        BaseCommandModelBuilder sut = new CommandModelBuilder(commandParser, startingPointParser);

        //Act
        sut.BuildStartingPoint(dto.StartingPoint);
        sut.BuildCommands(dto.Commands);
        var actual = sut.Build();

        //Assert
        actual.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> CommandModelBuilderData => new List<object[]>
    {
        new object[]
        {
            new RobotCleanerCommandDto
            {
                StartingPoint = "10 12",
                Commands = "E 2 N 1"
            },
            new RobotCleanerCommandModel
            {
                StartingPoint = (10, 12),
                Commands = new List<(char Direction, int Moves)>
                {
                    ('E', 2),
                    ('N', 1)
                }
            }
        },
        new object[]
        {
            new RobotCleanerCommandDto
            {
                StartingPoint = "-5 -10",
                Commands = "W 122 S 12"
            },
            new RobotCleanerCommandModel
            {
                StartingPoint = (-5, -10),
                Commands = new List<(char Direction, int Moves)>
                {
                    ('W', 122),
                    ('S', 12)
                }
            }
        }
    };
}