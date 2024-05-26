namespace Core.Interfaces;

public interface IBasicArithmeticHandler
{
    double Handle(string operation, List<object> args);
}