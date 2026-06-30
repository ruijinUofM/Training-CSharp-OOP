# 08. Extension Methods

## Feature

Extension methods — adding methods to existing types without modifying or inheriting from them.

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

Note: extension methods must live in a static class and use a special first-parameter syntax so they can be called as if they belonged to the extended type.

## Things to watch for

- Extension methods must be in a `static class` with `static` methods. The first parameter uses `this TypeName paramName`.
- Called as `"hello".IsPalindrome()` even though they're defined as `IsPalindrome(this string s)`.
- They can be called as regular static methods too: `StringExtensions.IsPalindrome("hello")`.
- `IsPalindrome`: remove spaces, lower-case both sides, compare with `SequenceEqual` or `string.Reverse()`.
- `Truncate`: if already short enough, return as-is; otherwise `s[..maxLength] + "..."`.
- `Times`: `for (int i = 0; i < n; i++) yield return i;`
- Extension methods cannot access private members — they're syntactic sugar for a static method call.
