namespace Core.Interfaces;

public interface ITokenExtractor
{
    List<string> ExtractTokens(string expression);
}