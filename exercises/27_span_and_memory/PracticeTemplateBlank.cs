using Xunit;

// Span<T> and Memory<T>
//
// Span<T> is a stack-only (ref struct) zero-allocation view over contiguous memory.
// Use AsSpan() instead of array/string slices to avoid allocations.
// stackalloc int[n] gives a stack buffer; wrap with Span<int>.
// Memory<T> is the heap-compatible cousin — can be stored in fields and used in async.
//
// Implement:
//   public static class SpanDemos {
//       public static int Sum(ReadOnlySpan<int> span);
//           // int total = 0; foreach (int x in span) total += x; return total;
//       public static ReadOnlySpan<int> Slice(int[] arr, int start, int length);
//           // return arr.AsSpan(start, length);
//       public static int ParseFirstInt(ReadOnlySpan<char> chars);
//           // return int.Parse(chars);
//       public static int StackAllocSum(int n);
//           // Span<int> buf = stackalloc int[n]; fill 1..n; return Sum(buf);
//       public static int MemorySum(Memory<int> mem);
//           // return Sum(mem.Span);
//   }

// Write your implementation below.
