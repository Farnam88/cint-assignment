using System.Text;

RobotCleanerCommandDto robotCleanerCommandDto = new();
Console.WriteLine("Please Enter number of commands:");

Int32.TryParse(Console.ReadLine(), out int commandQuantity);

Console.WriteLine("Please Enter starting point:");

robotCleanerCommandDto.StartingPoint = Console.ReadLine()!;

Console.WriteLine("Please Enter Commands:");

var commandStringBuilder = new StringBuilder();
for (int i = 0; i < commandQuantity; i++)
{
    commandStringBuilder.Append(Console.ReadLine()!);
    commandStringBuilder.Append(" ");
}

robotCleanerCommandDto.Commands = commandStringBuilder.ToString();

BaseParser<IList<(char Direction, int Moves)>, char> commandParser = new CommandParser(' ');
BaseParser<List<int>, char> startingPointParser = new StartingPointParser(' ');
BaseCommandModelBuilder commandModelBuilder = new CommandModelBuilder(commandParser, startingPointParser);

commandModelBuilder.BuildStartingPoint(robotCleanerCommandDto.StartingPoint);
commandModelBuilder.BuildCommands(robotCleanerCommandDto.Commands);
var model = commandModelBuilder.Build();

Console.ReadKey();