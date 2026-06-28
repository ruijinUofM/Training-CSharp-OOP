using Xunit;

public static class BoxingDemos
{
    public static object BoxInt(int value) => value;

    public static int UnboxInt(object obj) => (int)obj;

    public static System.Collections.ArrayList BoxMany(IEnumerable<int> values)
    {
        var list = new System.Collections.ArrayList();
        foreach (var v in values) list.Add(v);
        return list;
    }

    public static List<int> NoBoxing(IEnumerable<int> values) => new List<int>(values);

    public static Type GetBoxedType(object obj) => obj.GetType();

    public static bool IsBoxedInt(object obj) => obj is int;
}
