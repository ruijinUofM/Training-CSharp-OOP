namespace Kata;

static class StringExtensions
{
    public static bool IsPalindrome(this string s)
    {
        var clean = s.Replace(" ", "").ToLower();
        var reversed = new string(clean.Reverse().ToArray());
        return clean == reversed;
    }

    public static string Truncate(this string s, int maxLength)
        => s.Length <= maxLength ? s : s[..maxLength] + "...";

    public static int WordCount(this string s)
        => string.IsNullOrWhiteSpace(s) ? 0 : s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
}

static class IntExtensions
{
    public static bool IsEven(this int n) => n % 2 == 0;

    public static IEnumerable<int> Times(this int n)
    {
        for (int i = 0; i < n; i++)
            yield return i;
    }
}
