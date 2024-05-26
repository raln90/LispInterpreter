using Core.Interfaces;

namespace Core;

public class LispInterpreterService(ITokenExtractor tokenExtractor, ISyntaxTreeProcessor syntaxTreeProcessor, IExpressionParser expressionParser)
    : ILispInterpreterService
{
    public object Interpret(string expression)
    {
        var tokens = tokenExtractor.ExtractTokens(expression);
        var syntaxTree = expressionParser.ParseToAbstractSyntaxTree(tokens);
        return syntaxTreeProcessor.Process(syntaxTree);
    }
}