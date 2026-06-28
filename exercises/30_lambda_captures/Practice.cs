using Xunit;

public static class LambdaDemos
{
    // Capture factor; return a multiplier function
    public static Func<int, int> MakeMultiplier(int factor)
    {
        throw new NotImplementedException();
    }

    // BUG: all lambdas share the same 'i' variable → all return 3
    public static List<Func<int>> LateBuggy()
    {
        throw new NotImplementedException();
    }

    // FIX: capture a copy in each iteration → return 0, 1, 2
    public static List<Func<int>> LateFixed()
    {
        throw new NotImplementedException();
    }

    // Counter using a mutable captured variable
    public static Func<int> MakeCounter(int start = 0)
    {
        throw new NotImplementedException();
    }

    // Compose f and g: return x => f(g(x))
    public static Func<int, int> Compose(Func<int, int> f, Func<int, int> g)
    {
        throw new NotImplementedException();
    }
}
