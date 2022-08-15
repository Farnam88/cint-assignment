namespace CintAssignment.ConsoleApp.Services;
/// <summary>
/// Base bridge
/// </summary>
/// <typeparam name="TOutput"></typeparam>
/// <typeparam name="TSeparator"></typeparam>
public abstract class BaseParser<TOutput, TSeparator> where TOutput : class where TSeparator : struct
{
    protected readonly TSeparator Separator;

    protected BaseParser(TSeparator separator)
    {
        Separator = separator;
    }

    public abstract TOutput Pars(string input);
}