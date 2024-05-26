namespace Core.Interfaces;

public interface IExpressionParser
{
    object ParseToAbstractSyntaxTree(List<string> tokens);
}