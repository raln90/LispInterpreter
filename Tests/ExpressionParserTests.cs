using Core;
using Core.Interfaces;

namespace Tests;

[TestFixture]
public class ExpressionParserTests
{
    private IExpressionParser _expressionParser;

    [SetUp]
    public void Setup()
    { 
        _expressionParser = new ExpressionParser(new PrimitiveParser());
    }

[Test]
    public void ParseToAbstractSyntaxTree_ShouldThrowsException()
    {
        var tokens = new List<string>();
        var ex = Assert.Throws<Exception>(() => _expressionParser.ParseToAbstractSyntaxTree(tokens));
        Assert.AreEqual("Unexpected end of list", ex.Message);
    }

    [Test]
    public void ParseToAbstractSyntaxTree_Should_ThrowsExceptionUnexpectedClosingParenthesis()
    {
        var tokens = new List<string> { ")" };
        var ex = Assert.Throws<Exception>(() => _expressionParser.ParseToAbstractSyntaxTree(tokens));
        Assert.AreEqual("Unexpected closing parenthesis ')'", ex.Message);
    }
    
    [Test]
    public void ParseToAbstractSyntaxTree_MissingClosingParenthesisShouldThrowsException()
    {
        var tokens = new List<string> { "(" };
        var ex = Assert.Throws<Exception>(() => _expressionParser.ParseToAbstractSyntaxTree(tokens));
        Assert.AreEqual("Missing closing parenthesis ')'", ex.Message);
    }
    

    [Test]
    public void ParseToAbstractSyntaxTree_ValidExpressionShouldReturnsAbstractSyntaxTree()
    {
        var tokens = new List<string> { "(", "+", "42", "13", ")" };
        var result = _expressionParser.ParseToAbstractSyntaxTree(tokens) as List<object>;
        Assert.AreEqual(new List<object>(){"+", 42.0, 13.0}, result);
    }
}