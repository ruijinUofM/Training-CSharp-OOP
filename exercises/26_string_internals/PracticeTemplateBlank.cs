using Xunit;
using System.Text;

// String Internals
//
// Implement (all in static class StringInternals):
//   ContentEqual(string a, string b) → bool — true if both strings have the same content.
//   ReferenceEqual(string a, string b) → bool — true if both variables point to the
//       same object in memory.
//   InternString(string s) → string — ensures s is in the intern pool and returns it.
//       (Look up the C# string API for interning.)
//   IsInterned(string s) → bool — true if s is already in the intern pool.
//   ConcatWithPlus(int n) → string — concatenate "0" through "{n-1}" using + in a loop.
//   ConcatWithBuilder(int n) → string — same but using the efficient mutable builder type
//       (avoids the O(n²) allocations of repeated +).

// Write your implementation below.
