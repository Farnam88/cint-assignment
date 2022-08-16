namespace CintAssignment.Core;

public class RobotCleaner : IRobotCleaner
{
    private readonly ICleaningContext _cleaningContext;

    public RobotCleaner(ICleaningContext cleaningContext)
    {
        _cleaningContext = cleaningContext;
    }

    public string UniqueCleanedPlaces(RobotCleanerCommandModel input)
    {
        HashSet<(int x, int y)> mapping = new();
        mapping.Add(input.StartingPoint);
        var currentPoint = input.StartingPoint;

        IDirectionStrategy leftDirection = new LeftDirection();
        IDirectionStrategy rightDirection = new RightDirection();
        IDirectionStrategy upDirection = new UpDirection();
        IDirectionStrategy downDirection = new DownDirection();

        for (int i = 0; i < input.Commands.Count; i++)
        {
            var command = input.Commands[i];
            switch (command.Direction)
            {
                case 'W':
                    _cleaningContext.SetStrategy(leftDirection);
                    currentPoint = _cleaningContext.Execute(command.Moves, currentPoint, mapping);
                    break;
                case 'E':
                    _cleaningContext.SetStrategy(rightDirection);
                    currentPoint = _cleaningContext.Execute(command.Moves, currentPoint, mapping);
                    break;
                case 'S':
                    _cleaningContext.SetStrategy(downDirection);
                    currentPoint = _cleaningContext.Execute(command.Moves, currentPoint, mapping);
                    break;
                case 'N':
                    _cleaningContext.SetStrategy(upDirection);
                    currentPoint = _cleaningContext.Execute(command.Moves, currentPoint, mapping);
                    break;
            }
        }
        
        return $"=> Cleaned: {mapping.Count}";
    }
}