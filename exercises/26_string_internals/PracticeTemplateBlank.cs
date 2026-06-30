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
// Implement (all in static class StringInternals):
//   ContentEqual(string a, string b) → bool — true if both strings have the same content.
//   ReferenceEqual(string a, string b) → bool — true if both variables point to the
//       same object in memory.
//   InternString(string s) → string — ensures s is in the intern pool and returns it.
//   IsInterned(string s) → bool — true if s is already in the intern pool.
//   ConcatWithPlus(int n) → string — concatenate "0" through "{n-1}" using + in a loop.
//   ConcatWithBuilder(int n) → string — same but using the efficient mutable builder type.

// Write your implementation below.
