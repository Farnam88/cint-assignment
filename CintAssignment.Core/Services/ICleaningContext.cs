namespace CintAssignment.Core.Services;

public interface ICleaningContext
{
    (int X, int Y) Execute(int moves, (int X, int Y) currentPoint, HashSet<(int x, int y)> mapping);

    void SetStrategy(IDirectionStrategy directionStrategy);
}