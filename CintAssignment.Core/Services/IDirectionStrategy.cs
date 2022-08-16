namespace CintAssignment.Core.Services;

public interface IDirectionStrategy
{
    void ToDirection(int moves, ref (int X, int Y) currentPoint, HashSet<(int x, int y)> mapping);
}