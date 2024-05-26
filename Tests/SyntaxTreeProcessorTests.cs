using Core;
namespace Tests;

[TestFixture]
public class SyntaxTreeProcessorTests
{
    private SyntaxTreeProcessor _syntaxTreeProcessor;

    [SetUp]
    public void Setup()
    {
        _syntaxTreeProcessor = new SyntaxTreeProcessor(new BasicArithmeticHandler());
    }

    [Test]
    public void Process_UndefinedSymbolShouldThrowsException()
    {
        var ex = Assert.Throws<Exception>(() => _syntaxTreeProcessor.Process("x"));
        Assert.AreEqual("Undefined symbol: x", ex.Message);
    }

    [Test]
    public void Process_NestedArithmeticExpressionShouldReturnsCorrectResult()
    {
        var result = _syntaxTreeProcessor.Process(new List<object> { "*", new List<object> { "+", 2.0, 3.0 }, 2.0 });
        Assert.AreEqual(10.0, result);
    }

    [Test]
    public void Process_UseDefinedVariableInExpressionShouldReturnsCorrectResult()
    {
        _syntaxTreeProcessor.Process(new List<object> { "define", "a", 10.0 });
        var result = _syntaxTreeProcessor.Process(new List<object> { "+", "a", 5.0 });
        Assert.AreEqual(15.0, result);
    }
}