using Xunit;
using System.Text;

public static class StringInternals
{
    public static bool ContentEqual(string a, string b) => a == b;

    public static bool ReferenceEqual(string a, string b) => ReferenceEquals(a, b);

    public static string InternString(string s) => string.Intern(s);

    public static bool IsInterned(string s) => string.IsInterned(s) != null;

    public static string ConcatWithPlus(int n)
    {
        string s = "";
        for (int i = 0; i < n; i++) s += i;
        return s;
    }

    public static string ConcatWithBuilder(int n)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < n; i++) sb.Append(i);
        return sb.ToString();
    }
}
