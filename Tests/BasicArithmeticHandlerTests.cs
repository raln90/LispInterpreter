using Core;
using Core.Interfaces;

namespace Tests;

[TestFixture]
public class BasicArithmeticHandlerTests
{
    private IBasicArithmeticHandler _handler;

    [SetUp]
    public void Setup()
    {
        _handler = new BasicArithmeticHandler();
    }

    [TestCase("+", 1.0, 2.0, ExpectedResult = 3.0)]
    [TestCase("-", 5.0, 3.0, ExpectedResult = 2.0)]
    [TestCase("*", 2.0, 3.0, ExpectedResult = 6.0)]
    [TestCase("/", 6.0, 2.0, ExpectedResult = 3.0)]
    public double Handle_ShoulsReturnsCorrectResult(string operation, double arg1, double arg2)
    {
        return _handler.Handle(operation, [arg1, arg2]);
    }

    [TestCase("%", 1.0, 2.0)]
    public void Handle_ShouldThrowsException(string operation, double arg1, double arg2)
    {
        Assert.Throws<Exception>(() => _handler.Handle(operation, [arg1, arg2]));
    }

    [TestCase("/", 1.0, 0.0)]
    public void Handle_ShouldThrowsExceptionDivisionByZero(string operation, double arg1, double arg2)
    {
        Assert.Throws<DivideByZeroException>(() => _handler.Handle(operation, [arg1, arg2]));
    }
}