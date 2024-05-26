using Core.Interfaces;

namespace Core;

public class PrimitiveParser : IPrimitiveParser
{
    public object ParsePrimitive(string token)
    {
        if (IsNumber(token, out var number))
        {
            return number;
        }
        return token;
    }

    private static bool IsNumber(string token, out double number)
    {
        return double.TryParse(token, out number);
    }
}