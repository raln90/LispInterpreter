using Core.Interfaces;

namespace Core;

public class TokenExtractor : ITokenExtractor
{
    public List<string> ExtractTokens(string expression)
    {
        expression = expression.Replace("(", " ( ").Replace(")", " ) ");
        var keyArray = expression.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        return keyArray.ToList();
    }
}