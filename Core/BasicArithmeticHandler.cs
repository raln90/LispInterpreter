using Core.Interfaces;

namespace Core;

public class BasicArithmeticHandler : IBasicArithmeticHandler
{
    public double Handle(string operation, List<object> args)
    {
        return operation switch
        {
            "+" => (double) args[0] + (double) args[1],
            "-" => (double) args[0] - (double) args[1],
            "/" => (double)args[1] == 0 ? throw new DivideByZeroException() : (double)args[0] / (double)args[1],
            "*" => (double) args[0] * (double) args[1],
            _ => throw new Exception($"Unknown operation: {operation}")
        };
    }
}