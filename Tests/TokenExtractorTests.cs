using Core;
using Core.Interfaces;

namespace Tests;

[TestFixture]
public class TokenExtractorTests
{
    private ITokenExtractor _extractor;

    [SetUp]
    public void Setup()
    {
        _extractor = new TokenExtractor();
    }

    [TestCase("(+ 2 3)", new[] { "(", "+", "2", "3", ")" })]
    [TestCase("(* 4 5)", new[] { "(", "*", "4", "5", ")" })]
    [TestCase("(* (+ 2 3) (- 5 2))", new[] { "(", "*", "(", "+", "2", "3", ")", "(", "-", "5", "2", ")", ")" })]
    [TestCase("(define a 10)", new[] { "(", "define", "a", "10", ")" })]
    public void ExtractTokens_ShouldReturnsCorrectTokens(string expression, string[] expectedTokens)
    {
        var result = _extractor.ExtractTokens(expression);
        Assert.AreEqual(expectedTokens, result);
    }
}