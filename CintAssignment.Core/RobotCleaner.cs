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
            if (command.Direction == 'W')
            {
                _cleaningContext.SetStrategy(leftDirection);
                currentPoint = _cleaningContext.Execute(command.Moves, currentPoint, mapping);
                continue;
            }

            if (command.Direction == 'E')
            {
                _cleaningContext.SetStrategy(rightDirection);
                currentPoint = _cleaningContext.Execute(command.Moves, currentPoint, mapping);
                continue;
            }

            if (command.Direction == 'S')
            {
                _cleaningContext.SetStrategy(downDirection);
                currentPoint = _cleaningContext.Execute(command.Moves, currentPoint, mapping);
                continue;
            }

            if (command.Direction == 'N')
            {
                _cleaningContext.SetStrategy(upDirection);
                currentPoint = _cleaningContext.Execute(command.Moves, currentPoint, mapping);
            }
        }


        return $"=> Cleaned: {mapping.Count}";
    }
}