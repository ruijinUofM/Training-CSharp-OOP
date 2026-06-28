// Extension Methods -- StringExtensions + IntExtensions, written from scratch.
//
// Required API:
//
//   static class StringExtensions
//   {
//       public static bool IsPalindrome(this string s)
//           // ignores case and spaces; "Race Car" -> true
//
//       public static string Truncate(this string s, int maxLength)
//           // "Hello World".Truncate(5) -> "Hello..."
//           // "Hi".Truncate(5) -> "Hi"
//
//       public static int WordCount(this string s)
//           // "hello world" -> 2, "" -> 0
//   }
//
//   static class IntExtensions
//   {
//       public static bool IsEven(this int n)     // n % 2 == 0
//       public static IEnumerable<int> Times(this int n)  // yields 0..n-1
//   }

namespace Kata;

// Write your implementation below.
