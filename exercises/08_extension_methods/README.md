# 08. Extension Methods

## Feature

Extension methods — adding methods to existing types without modifying or inheriting from them.

## When to use it / When to avoid it

Extension methods exist for adding behavior to a type you don't own (or can't/shouldn't subclass, e.g. a sealed BCL type like `string`), while keeping call-site syntax that reads like a normal method call.

- **Use it when**: you want fluent, chainable helper behavior on a type you don't control (framework/library types), or you're building a LINQ-style API over `IEnumerable<T>`.
- **Avoid it when**: you own the class — a real instance method is clearer, can access private state, and doesn't require the reader to go hunting for which static class defines the behavior. Overusing extension methods on your own types tends to scatter behavior away from the type it conceptually belongs to.

## Case study

`StringExtensions` adds `IsPalindrome`, `Truncate`, and `WordCount` to `string`. `IntExtensions` adds `IsEven` and `Times` to `int`.

## Required methods and behavior

- **StringExtensions** — methods callable directly on `string` values (e.g., `s.IsPalindrome()`).
  - `IsPalindrome(string)` → bool — ignores case and spaces; `"Race Car"` → true.
  - `Truncate(string, int maxLength)` → string — returns the string unchanged if short enough; otherwise first `maxLength` chars + `"..."`.
  - `WordCount(string)` → int — count of whitespace-separated words; `""` → 0.

- **IntExtensions** — methods callable directly on `int` values (e.g., `n.IsEven()`).
  - `IsEven(int)` → bool — `n % 2 == 0`.
  - `Times(int)` → sequence of ints — yields 0, 1, …, n-1.

Note: extension methods must live in a special class and use a specific first-parameter syntax so they can be called as if they belonged to the extended type.

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
// hosting class MUST be "static", methods MUST be "static", and the first
// parameter is prefixed with "this" — that's what makes it an extension method
static class StringExtensions
{
    public static bool IsShout(this string s) => s.ToUpper() == s;

    public static string Repeat(this string s, int times)
        => string.Concat(Enumerable.Repeat(s, times));
}

static class IntExtensions
{
    public static bool IsEven(this int n) => n % 2 == 0;

    // an extension method can also return an iterator via yield return
    public static IEnumerable<int> Times(this int n)
    {
        for (int i = 0; i < n; i++)
            yield return i;
    }
}

// call-site: looks like an instance method, even though it's really static
bool shout = "HELLO".IsShout();
bool even = 4.IsEven();

// still callable the "normal" static way too:
bool shout2 = StringExtensions.IsShout("HELLO");
```

</details>

## Things to watch for

- Extension methods live in a specific kind of class, and each method must also have a specific modifier. Look up what makes a class and its methods eligible to host extension methods.
- The first parameter uses a specific syntax that tells the compiler to treat the method as belonging to that type — called as `"hello".IsPalindrome()` even though it's defined differently.
- They can be called as regular static methods too: `StringExtensions.IsPalindrome("hello")`.
- `IsPalindrome`: remove spaces, lower-case both sides, compare with `SequenceEqual` or `string.Reverse()`.
- `Truncate`: if already short enough, return as-is; otherwise `s[..maxLength] + "..."`.
- `Times`: `for (int i = 0; i < n; i++) yield return i;`
- Extension methods cannot access private members — they're syntactic sugar for a static method call.
