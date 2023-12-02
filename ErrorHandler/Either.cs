namespace EHA.ErrorHandler;
public class Either<L, R>
{
    private readonly L? left;
    private readonly R? right;
    public bool IsLeft { get; }
    public bool IsRight => !IsLeft;

    private Either(L left)
    {
        this.left = left;
        IsLeft = true;
    }

    private Either(R right)
    {
        this.right = right;
        IsLeft = false;
    }

    public L? LeftOrDefault()
    {
        return Match(
            left => left,
            right => default(L)
        );
    }
    public R? RightOrDefault()
    {
        return Match(
            left => default(R),
            right => right
        );
    }

    public static Either<L, R> Left(L left) => new(left);
    public static Either<L, R> Right(R right) => new(right);

    public T Match<T>(Func<L, T> leftFunc, Func<R, T> rightFunc)
    {
        if (leftFunc == null) throw new ArgumentNullException(nameof(leftFunc));
        if (rightFunc == null) throw new ArgumentNullException(nameof(rightFunc));

        return IsLeft ? leftFunc(left!) : rightFunc(right!);
    }

    public void Match(Action<L> leftFunc, Action<R> rightFunc)
    {
        if (leftFunc == null) throw new ArgumentNullException(nameof(leftFunc));
        if (rightFunc == null) throw new ArgumentNullException(nameof(rightFunc));

        if (IsLeft)
            leftFunc(left!);
        else
            rightFunc(right!);
    }
}
