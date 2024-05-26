using Core.Interfaces;

namespace Core;

public class ExpressionParser(IPrimitiveParser primitiveParser) : IExpressionParser
{
    public object ParseToAbstractSyntaxTree(List<string> tokens)
    {
        if (tokens.Count == 0)
        {
            throw new Exception("Unexpected end of list");
        }
        var token = tokens[0];
        tokens.RemoveAt(0);

        return token switch
        {
            "(" => ParseTokenList(tokens),
            ")" => throw new Exception("Unexpected closing parenthesis ')'"),
            _ => primitiveParser.ParsePrimitive(token)
        };
    }

    private List<object> ParseTokenList(List<string> tokens)
    {
        if (tokens.Count == 0)
        {
            throw new Exception("Missing closing parenthesis ')'");
        }
        var parsedList = new List<object>();

        while (tokens.Count > 0 && tokens[0] != ")")
        {
            parsedList.Add(ParseToAbstractSyntaxTree(tokens));
        }
        tokens.RemoveAt(0); // Remove ')'
        return parsedList;
    }
}