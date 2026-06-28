using Xunit;

public static class BoxingDemos
{
    // Boxing: value type → object (heap allocation)
    public static object BoxInt(int value)
    {
        throw new NotImplementedException();
    }

    // Unboxing: object → value type (must be exact type match)
    public static int UnboxInt(object obj)
    {
        throw new NotImplementedException();
    }

    // Pre-generics: ArrayList stores object → every int gets boxed
    public static System.Collections.ArrayList BoxMany(IEnumerable<int> values)
    {
        throw new NotImplementedException();
    }

    // Generics: List<int> stores int directly → no boxing
    public static List<int> NoBoxing(IEnumerable<int> values)
    {
        throw new NotImplementedException();
    }

    public static Type GetBoxedType(object obj)
    {
        throw new NotImplementedException();
    }

    public static bool IsBoxedInt(object obj)
    {
        throw new NotImplementedException();
    }
}
