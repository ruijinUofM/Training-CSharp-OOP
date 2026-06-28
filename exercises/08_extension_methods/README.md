# 08. Extension Methods

## Feature

Extension methods — adding methods to existing types without modifying or inheriting from them.

## Case study

`StringExtensions` adds `IsPalindrome`, `Truncate`, and `WordCount` to `string`. `IntExtensions` adds `IsEven` and `Times` to `int`.

## Required API

```csharp
static class StringExtensions
{
    public static bool IsPalindrome(this string s)
    // true if s equals its reverse (ignore case, ignore spaces)

    public static string Truncate(this string s, int maxLength)
    // if s.Length <= maxLength, return s
    // else return s[..maxLength] + "..."

    public static int WordCount(this string s)
    // count of whitespace-separated words (empty string = 0)
}

static class IntExtensions
{
    public static bool IsEven(this int n)       // n % 2 == 0

    public static IEnumerable<int> Times(this int n)  // yields 0, 1, ..., n-1
}
```

## Things to watch for

- Extension methods must be in a `static class` with `static` methods. The first parameter uses `this TypeName paramName`.
- Called as `"hello".IsPalindrome()` even though they're defined as `IsPalindrome(this string s)`.
- They can be called as regular static methods too: `StringExtensions.IsPalindrome("hello")`.
- `IsPalindrome`: remove spaces, lower-case both sides, compare with `SequenceEqual` or `string.Reverse()`.
- `Truncate`: if already short enough, return as-is; otherwise `s[..maxLength] + "..."`.
- `Times`: `for (int i = 0; i < n; i++) yield return i;`
- Extension methods cannot access private members — they're syntactic sugar for a static method call.
