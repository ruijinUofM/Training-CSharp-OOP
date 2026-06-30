// Extension Methods -- StringExtensions + IntExtensions, written from scratch.
//
// Required methods and behavior:
//
//   StringExtensions — methods callable directly on string values (e.g., s.IsPalindrome()).
//       IsPalindrome(string) → bool — ignores case and spaces; "Race Car" → true.
//       Truncate(string, int maxLength) → string — returns the string unchanged if
//           short enough; otherwise first maxLength chars + "...".
//       WordCount(string) → int — count of whitespace-separated words; "" → 0.
//
//   IntExtensions — methods callable directly on int values (e.g., n.IsEven()).
//       IsEven(int) → bool — n % 2 == 0.
//       Times(int) → sequence of ints — yields 0, 1, …, n-1.
//
// Note: extension methods must live in a static class and use a special first-parameter
//       syntax so they can be called as if they belonged to the extended type.

namespace Kata;

// Write your implementation below.
