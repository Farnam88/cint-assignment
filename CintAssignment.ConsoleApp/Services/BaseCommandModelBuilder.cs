namespace CintAssignment.ConsoleApp.Services;

public abstract class BaseCommandModelBuilder
{
    protected readonly BaseParser<IList<(char Direction, int Moves)>, char> CommandParser;
    protected readonly BaseParser<List<int>, char> StartingPointParser;
    protected RobotCleanerCommandModel RobotCleanerCommandModel;

    protected BaseCommandModelBuilder(BaseParser<IList<(char Direction, int Moves)>, char> commandParser,
        BaseParser<List<int>, char> startingPointParser)
    {
        CommandParser = commandParser;
        StartingPointParser = startingPointParser;
        RobotCleanerCommandModel = new RobotCleanerCommandModel();
    }

    public void Reset()
    {
        RobotCleanerCommandModel = new RobotCleanerCommandModel();
    }

    public abstract void BuildStartingPoint(string startingPoint);
    public abstract void BuildCommands(string commands);
    public abstract RobotCleanerCommandModel Build();
}