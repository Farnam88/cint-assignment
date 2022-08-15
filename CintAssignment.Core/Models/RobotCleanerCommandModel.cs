namespace CintAssignment.Core.Models;

public class RobotCleanerCommandModel
{
    public (int X, int Y) StartingPoint { get; set; }
    public IList<(char Direction, int Moves)> Commands { get; set; }
}