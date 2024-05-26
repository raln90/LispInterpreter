using Core.Interfaces;

namespace Core;

public class SyntaxTreeProcessor(IBasicArithmeticHandler basicArithmeticHandler) : ISyntaxTreeProcessor
{
    private readonly Dictionary<string, object> _varBindings = new();
    public object Process(object syntaxTree)
    {
        return syntaxTree switch
        {
            double i => i,
            string s => _varBindings.TryGetValue(s, out var value) ? value : throw new Exception($"Undefined symbol: {s}"),
            List<object> list => ProcessExpressionList(list),
            _ => throw new Exception("Invalid syntax")
        };
    }
    
    private object ProcessExpressionList(List<object> list)
    {
        var operation = list[0].ToString();
        var args = new List<object>();

        if (operation == "define")
        {
            return DefineVariable(list);
        }

        args.AddRange(list.Skip(1).Select(Process));
        
        return basicArithmeticHandler.Handle(operation, args);
    }

    private object DefineVariable(List<object> args)
    {
        var variable = args[1].ToString();
        var value = Process(args[2]);
        _varBindings[variable] = value;
        return value;
    }
}