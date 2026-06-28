using Xunit;

public static class ParameterDemos
{
    // ref: caller must initialize; method can read and write
    public static void Swap(ref int a, ref int b)
    {
        throw new NotImplementedException();
    }

    // out: method must assign before returning; caller needn't initialize
    public static bool TryDouble(string s, out int result)
    {
        throw new NotImplementedException();
    }

    // ref accumulator: accumulate a sum in the caller's variable
    public static int SumWithRef(ref int accumulator, int value)
    {
        throw new NotImplementedException();
    }

    // in: read-only reference — avoids copy but cannot mutate
    public static int ReadOnly(in int value)
    {
        throw new NotImplementedException();
    }
}
