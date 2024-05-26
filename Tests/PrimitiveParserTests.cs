using Core;
using Core.Interfaces;

namespace Tests;

[TestFixture]
public class PrimitiveParserTests
{
    private IPrimitiveParser _parser;

    [SetUp]
    public void Setup()
    {
        _parser = new PrimitiveParser();
    }

    [TestCase("42", 42.0)]
    [TestCase("3.14", 3.14)]
    [TestCase("-7.5", -7.5)]
    [TestCase("0", 0.0)]
    [TestCase("define", "define")]
    [TestCase("abc", "abc")]
    public void ParsePrimitive_ValidTokens_ReturnsExpectedResult(string token, object expected)
    {
        var result = _parser.ParsePrimitive(token);
        Assert.AreEqual(expected, result);
    }
}