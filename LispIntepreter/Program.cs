using Microsoft.Extensions.DependencyInjection;

using Core;
using Core.Interfaces;

var serviceProvider = new ServiceCollection()
    .AddTransient<ISyntaxTreeProcessor, SyntaxTreeProcessor>()
    .AddTransient<IBasicArithmeticHandler, BasicArithmeticHandler>()
    .AddTransient<IExpressionParser, ExpressionParser>()
    .AddTransient<ILispInterpreterService, LispInterpreterService>()
    .AddTransient<ITokenExtractor, TokenExtractor>()
    .AddTransient<IPrimitiveParser, PrimitiveParser>()
    .BuildServiceProvider();

var interpreter = serviceProvider.GetService<ILispInterpreterService>();

// Test cases from description
Console.WriteLine(interpreter.Interpret("(+ 2 3)")); // Expected output: 5
Console.WriteLine(interpreter.Interpret("(* 4 5)")); // Expected output: 20
Console.WriteLine(interpreter.Interpret("(* (+ 2 3) (- 5 2))")); // Expected output: 15
interpreter.Interpret("(define a 10)");
Console.WriteLine(interpreter.Interpret("(+ a 5)")); // Expected output: 15