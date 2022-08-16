namespace CintAssignment.Core.Services;

public class CleaningContext : ICleaningContext
{
    private IDirectionStrategy _directionStrategy = null!;

    public (int X, int Y) Execute(int moves, (int X, int Y) currentPoint, HashSet<(int x, int y)> mapping)
    {
        _directionStrategy.ToDirection(moves, ref currentPoint, mapping);
        return currentPoint;
    }

    public void SetStrategy(IDirectionStrategy directionStrategy)
    {
        _directionStrategy = directionStrategy;
    }
}