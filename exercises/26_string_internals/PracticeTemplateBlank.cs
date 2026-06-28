using Xunit;
using System.Text;

// String Internals
//
// string is immutable and its == compares content (not reference).
// String literals are automatically interned (same object in memory).
// string.Intern(s) adds s to the intern pool.
// string.IsInterned(s) returns the interned version or null.
// Use StringBuilder for O(n) concatenation instead of O(n²) + operator.
//
// Implement:
//   public static class StringInternals {
//       public static bool ContentEqual(string a, string b);    // a == b
//       public static bool ReferenceEqual(string a, string b);  // ReferenceEquals(a, b)
//       public static string InternString(string s);             // string.Intern(s)
//       public static bool IsInterned(string s);                 // string.IsInterned(s) != null
//       public static string ConcatWithPlus(int n);              // += in a loop
//       public static string ConcatWithBuilder(int n);           // StringBuilder.Append in loop
//   }

// Write your implementation below.
