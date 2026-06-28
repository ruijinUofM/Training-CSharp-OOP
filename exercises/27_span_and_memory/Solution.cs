using Xunit;

public static class SpanDemos
{
    public static int Sum(ReadOnlySpan<int> span)
    {
        int total = 0;
        foreach (int x in span) total += x;
        return total;
    }

    public static ReadOnlySpan<int> Slice(int[] arr, int start, int length)
        => arr.AsSpan(start, length);

    public static int ParseFirstInt(ReadOnlySpan<char> chars)
        => int.Parse(chars);

    public static int StackAllocSum(int n)
    {
        Span<int> buf = stackalloc int[n];
        for (int i = 0; i < n; i++) buf[i] = i + 1;
        return Sum(buf);
    }

    public static int MemorySum(Memory<int> mem)
        => Sum(mem.Span);
}
