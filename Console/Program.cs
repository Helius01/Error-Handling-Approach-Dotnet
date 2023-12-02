using EHA.Calculator;

var result = Calculator.Divide(1, 0);

result.Match(
    left => Console.WriteLine(left.Message),
    right => Console.WriteLine(right)
);
