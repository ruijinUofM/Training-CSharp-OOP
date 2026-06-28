using Xunit;

public static class SpanDemos
{
    // Sum elements of a span without allocating a new array
    public static int Sum(ReadOnlySpan<int> span)
    {
        throw new NotImplementedException();
    }

    // Return a zero-copy slice of arr
    public static ReadOnlySpan<int> Slice(int[] arr, int start, int length)
    {
        throw new NotImplementedException();
    }

    // Parse an integer from a span of chars — no string allocation
    public static int ParseFirstInt(ReadOnlySpan<char> chars)
    {
        throw new NotImplementedException();
    }

    // Allocate a temp buffer on the stack, fill with 1..n, return sum
    public static int StackAllocSum(int n)
    {
        throw new NotImplementedException();
    }

    // Sum via Memory<int> (heap-compatible span wrapper)
    public static int MemorySum(Memory<int> mem)
    {
        throw new NotImplementedException();
    }
}
