using Xunit;

public static class LambdaDemos
{
    public static Func<int, int> MakeMultiplier(int factor) => x => x * factor;

    public static List<Func<int>> LateBuggy()
    {
        var fns = new List<Func<int>>();
        for (int i = 0; i < 3; i++)
            fns.Add(() => i); // all share the same 'i' closure field
        return fns;
    }

    public static List<Func<int>> LateFixed()
    {
        var fns = new List<Func<int>>();
        for (int i = 0; i < 3; i++)
        {
            int captured = i; // new variable each iteration → new closure
            fns.Add(() => captured);
        }
        return fns;
    }

    public static Func<int> MakeCounter(int start = 0)
    {
        int count = start;
        return () => ++count;
    }

    public static Func<int, int> Compose(Func<int, int> f, Func<int, int> g)
        => x => f(g(x));
}
