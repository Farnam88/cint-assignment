namespace CintAssignment.ConsoleApp.Services;

public class CommandModelBuilder : BaseCommandModelBuilder
{
    public CommandModelBuilder(BaseParser<IList<(char Direction, int Moves)>, char> commandParser,
        BaseParser<List<int>, char> startingPointParser) : base(commandParser, startingPointParser)
    {
    }

    public override void BuildStartingPoint(string startingPoint)
    {
        var result = StartingPointParser.Pars(startingPoint);
        RobotCleanerCommandModel.StartingPoint = (result[0], result[1]);
    }

    public override void BuildCommands(string commands)
    {
        RobotCleanerCommandModel.Commands = CommandParser.Pars(commands);
    }

    public override RobotCleanerCommandModel Build()
    {
        var model = RobotCleanerCommandModel;
        Reset();
        return model;
    }
}