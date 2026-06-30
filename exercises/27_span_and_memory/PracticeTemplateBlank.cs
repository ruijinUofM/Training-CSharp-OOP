using Xunit;

// Span<T> and Memory<T>
//
// Span<T> is a stack-only (ref struct) zero-allocation view over contiguous memory.
// Use AsSpan() instead of array/string slices to avoid allocations.
// stackalloc int[n] gives a stack buffer; wrap with Span<int>.
// Memory<T> is the heap-compatible cousin — can be stored in fields and used in async.
//
// Implement (all in static class SpanDemos):
//   Sum(read-only span of int) → int — sums elements without allocating.
//   Slice(int[] arr, int start, int length) → read-only span of int — returns a
//       zero-copy view over the specified range (no new array created).
//   ParseFirstInt(read-only span of char) → int — parses an int without creating
//       a string allocation.
//   StackAllocSum(int n) → int — allocates n ints on the stack, fills with 1..n,
//       returns their sum (no heap allocation).
//   MemorySum(heap-compatible span wrapper of int) → int — sums using the
//       synchronous span view of the memory.
//
// Note: look up Span<T>, ReadOnlySpan<T>, Memory<T>, and stackalloc.

// Write your implementation below.
