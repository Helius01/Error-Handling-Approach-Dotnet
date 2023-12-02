using EHA;
using EHA.ErrorHandler;

namespace EHA.Calculator;
public class Calculator
{
    public static Either<Exception, int> Divide(int x, int y)
    {
        var result = 0;
        try
        {
            result = x / y;
        }
        catch (DivideByZeroException ex)
        {
            return Either<Exception, int>.Left(ex);
        }

        return Either<Exception, int>.Right(result);
    }
}
