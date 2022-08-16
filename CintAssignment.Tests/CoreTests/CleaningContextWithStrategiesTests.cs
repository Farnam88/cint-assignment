

namespace CintAssignment.Tests.CoreTests;

public class CleaningContextWithStrategiesTests
{
    private readonly ICleaningContext _sut;

    public CleaningContextWithStrategiesTests()
    {
        _sut = new CleaningContext();
    }

    #region + CleaningContextRightDirection

    [Theory]
    [MemberData(nameof(CleaningContextRightDirectionData))]
    public void
        CleaningContext_ShouldMovePointToRight_WithRightDirectionStrategy(
            int moves, (int X, int Y) point, (int X, int Y) expected)
    {
        //Arrange
        var mapping = new HashSet<(int x, int y)>();
        IDirectionStrategy eastDirection = new RightDirection();
        _sut.SetStrategy(eastDirection);

        //Act
        var actual = _sut.Execute(moves, point, mapping);

        //Assert
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> CleaningContextRightDirectionData => new List<object[]>
    {
        new object[] { 2, (1, 2), (3, 2) },
        new object[] { 3, (3, 5), (6, 5) },
        new object[] { 10, (3, 5), (13, 5) },
    };

    #endregion

    #region + CleaningContextleftDirection

    [Theory]
    [MemberData(nameof(CleaningContextLeftDirectionData))]
    public void
        CleaningContext_ShouldMovePointToLeft_WithLeftDirectionStrategy(
            int moves, (int X, int Y) point, (int X, int Y) expected)
    {
        //Arrange
        var mapping = new HashSet<(int x, int y)>();
        IDirectionStrategy eastDirection = new LeftDirection();
        _sut.SetStrategy(eastDirection);

        //Act
        var actual = _sut.Execute(moves, point, mapping);

        //Assert
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> CleaningContextLeftDirectionData => new List<object[]>
    {
        new object[] { 2, (1, 2), (-1, 2) },
        new object[] { 3, (3, 5), (0, 5) },
        new object[] { 10, (3, 5), (-7, 5) },
    };

    #endregion

    #region + CleaningContextUpDirection

    [Theory]
    [MemberData(nameof(CleaningContextUpDirectionData))]
    public void
        CleaningContext_ShouldMovePointToUp_WithUpDirectionStrategy(
            int moves, (int X, int Y) point, (int X, int Y) expected)
    {
        //Arrange
        var mapping = new HashSet<(int x, int y)>();
        IDirectionStrategy eastDirection = new UpDirection();
        _sut.SetStrategy(eastDirection);

        //Act
        var actual = _sut.Execute(moves, point, mapping);

        //Assert
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> CleaningContextUpDirectionData => new List<object[]>
    {
        new object[] { 2, (1, 2), (1, 4) },
        new object[] { 3, (3, 5), (3, 8) },
        new object[] { 10, (3, 5), (3, 15) },
    };

    #endregion

    #region + CleaningContextDownDirection

    [Theory]
    [MemberData(nameof(CleaningContextDownDirectionData))]
    public void
        CleaningContext_ShouldMovePointToDown_WithDownDirectionStrategy(
            int moves, (int X, int Y) point, (int X, int Y) expected)
    {
        //Arrange
        var mapping = new HashSet<(int x, int y)>();
        IDirectionStrategy eastDirection = new DownDirection();
        _sut.SetStrategy(eastDirection);

        //Act
        var actual = _sut.Execute(moves, point, mapping);

        //Assert
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> CleaningContextDownDirectionData => new List<object[]>
    {
        new object[] { 2, (1, 2), (1, 0) },
        new object[] { 3, (3, 5), (3, 2) },
        new object[] { 10, (3, 5), (3, -5) },
    };

    #endregion

    #region + CleaningContexUniquePointAnyDirections

    [Theory]
    [MemberData(nameof(CleaningContextUniquePointsData))]
    public void
        CleaningContext_ShouldAddUniquePointToHashSet_WithAnyDirectionStrategy(IDirectionStrategy directionStrategy,
            int moves, (int X, int Y) point, HashSet<(int X, int Y)> mapping, HashSet<(int X, int Y)> expected)
    {
        //Arrange
        _sut.SetStrategy(directionStrategy);

        //Act
        _sut.Execute(moves, point, mapping);

        //Assert
        mapping.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> CleaningContextUniquePointsData => new List<object[]>
    {
        new object[]
        {
            new LeftDirection(),
            2,
            (1, 2),
            new HashSet<(int x, int y)>
            {
                { (1, 2) },
                { (0, 2) }
            },
            new HashSet<(int x, int y)>
            {
                { (1, 2) },
                { (0, 2) },
                { (-1, 2) }
            }
        },
        new object[]
        {
            new RightDirection(),
            2,
            (1, 2),
            new HashSet<(int x, int y)>
            {
                { (1, 2) },
                { (2, 2) }
            },
            new HashSet<(int x, int y)>
            {
                { (1, 2) },
                { (2, 2) },
                { (3, 2) }
            }
        },
        new object[]
        {
            new UpDirection(),
            2,
            (1, 2),
            new HashSet<(int x, int y)>
            {
                { (1, 2) }
            },
            new HashSet<(int x, int y)>
            {
                { (1, 2) },
                { (1, 3) },
                { (1, 4) }
            }
        },
        new object[]
        {
            new DownDirection(),
            2,
            (1, 2),
            new HashSet<(int x, int y)>
            {
                { (1, 2) }
            },
            new HashSet<(int x, int y)>
            {
                { (1, 2) },
                { (1, 1) },
                { (1, 0) }
            }
        },
    };

    #endregion
}