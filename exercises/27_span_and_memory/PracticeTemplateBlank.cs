using Xunit;

// Zero-Allocation Memory Views — Span<T> and Memory<T>
//
// Implement (all in static class SpanDemos):
//   Sum(read-only span of int) → int — sums elements without allocating.
//   Slice(int[] arr, int start, int length) → read-only span of int — returns a
//       zero-copy view over the specified range (no new array created).
//   ParseFirstInt(read-only span of char) → int — parses an int without creating
//       a string allocation.
//   StackAllocSum(int n) → int — allocates n ints on the stack, fills with 1..n,
//       returns their sum (no heap allocation).
//   MemorySum(heap-compatible view of int) → int — sums using the
//       synchronous span view of the memory.
//
// Look up C# types for: stack-only zero-allocation memory views, their read-only
// variants, heap-compatible memory views, and stack allocation syntax.

// Write your implementation below.
