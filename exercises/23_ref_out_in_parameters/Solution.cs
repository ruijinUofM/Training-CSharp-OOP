using Xunit;

public static class ParameterDemos
{
    public static void Swap(ref int a, ref int b)
    {
        int tmp = a;
        a = b;
        b = tmp;
    }

    public static bool TryDouble(string s, out int result)
    {
        if (int.TryParse(s, out int parsed))
        {
            result = parsed * 2;
            return true;
        }
        result = 0;
        return false;
    }

    public static int SumWithRef(ref int accumulator, int value)
    {
        accumulator += value;
        return accumulator;
    }

    public static int ReadOnly(in int value)
    {
        return value * 2;
    }
}
