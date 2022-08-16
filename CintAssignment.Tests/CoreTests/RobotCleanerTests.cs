namespace CintAssignment.Tests.CoreTests;

public class RobotCleanerTests
{
    [Theory]
    [MemberData(nameof(RobotCleanerData))]
    public void RobotCleaner_ShouldOutputNumberOfUniquePlaces_OnSuccess(RobotCleanerCommandModel model, string expected)
    {
        //Arrange
        ICleaningContext cleaningContext = new CleaningContext();
        IRobotCleaner robotCleaner = new RobotCleaner(cleaningContext);

        //Act
        var actual = robotCleaner.UniqueCleanedPlaces(model);

        //Assert
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> RobotCleanerData => new List<object[]>
    {
        new object[]
        {
            new RobotCleanerCommandModel
            {
                StartingPoint = (10, 22),
                Commands = new List<(char Direction, int Moves)>
                {
                    ('E', 2),
                    ('N', 1),
                }
            },
            "=> Cleaned: 4"
        },
        new object[]
        {
            new RobotCleanerCommandModel
            {
                StartingPoint = (5, 2),
                Commands = new List<(char Direction, int Moves)>
                {
                    ('W', 3),
                    ('N', 2),
                    ('E', 1),
                    ('S', 2),
                }
            },
            "=> Cleaned: 8"
        },
        new object[]
        {
            new RobotCleanerCommandModel
            {
                StartingPoint = (-5, -2),
                Commands = new List<(char Direction, int Moves)>
                {
                    ('W', 3),
                    ('N', 2),
                    ('E', 1),
                    ('S', 2),
                }
            },
            "=> Cleaned: 8"
        },
        new object[]
        {
            new RobotCleanerCommandModel
            {
                StartingPoint = (0, 0),
                Commands = new List<(char Direction, int Moves)>
                {
                    ('W', 3),
                    ('N', 2),
                    ('E', 1),
                    ('S', 2),
                }
            },
            "=> Cleaned: 8"
        },
        new object[]
        {
            new RobotCleanerCommandModel
            {
                StartingPoint = (5, 2),
                Commands = new List<(char Direction, int Moves)>
                {
                    ('W', 3)
                }
            },
            "=> Cleaned: 4"
        }
    };
}