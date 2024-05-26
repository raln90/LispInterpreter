namespace Core.Interfaces;

public interface ILispInterpreterService
{
    object Interpret(string expression);
}