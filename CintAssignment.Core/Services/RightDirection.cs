namespace CintAssignment.Core.Services;

public class RightDirection : IDirectionStrategy
{
    public void ToDirection(int moves, ref (int X, int Y) currentPoint, HashSet<(int x, int y)> mapping)
    {
        for (int j = 0; j < moves; j++)
        {
            currentPoint.X += 1;
            if (!mapping.Contains(currentPoint))
            {
                mapping.Add(currentPoint);
            }
        }
    }
}