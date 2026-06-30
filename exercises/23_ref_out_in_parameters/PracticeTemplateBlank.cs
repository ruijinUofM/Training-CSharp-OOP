using Xunit;

// ref / out / in Parameters
//
// ref: caller initializes; method reads and writes caller's variable.
// out: method must write before returning; caller doesn't need to initialize.
// in:  read-only reference (avoids copy for large structs; cannot mutate).
//
// Implement (all in static class ParameterDemos):
//   Swap(int a, int b) — exchanges the caller's two int variables in place.
//       (Both parameters must let the method write back to the caller's variables.)
//   TryDouble(string s, int result) → bool — parses s as int; if successful,
//       result = parsed * 2 and returns true; else result = 0 and returns false.
//       (result is set by the method; caller does not need to initialize it first.)
//   SumWithRef(int accumulator, int value) → int — adds value to the caller's
//       accumulator variable directly and returns the new total.
//       (accumulator is both read and written through the caller's variable.)
//   ReadOnly(int value) → int — returns value * 2; value is passed by reference
//       but the method is not allowed to modify it.

// Write your implementation below.
