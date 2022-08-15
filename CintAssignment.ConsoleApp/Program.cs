using System.Text;

Console.WriteLine("Please Enter number of commands:");

Int32.TryParse(Console.ReadLine(), out int commandQuantity);

Console.WriteLine("Please Enter starting point:");

string startingPoint = Console.ReadLine()!;

Console.WriteLine("Please Enter Commands:");

var command = new StringBuilder();
for (int i = 0; i < commandQuantity; i++)
{
    command.Append(Console.ReadLine()!);
    command.Append(" ");
}