using Xunit;

public class SpanAndMemoryTests
{
    [Fact]
    public void Sum_CorrectTotal()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        Assert.Equal(15, SpanDemos.Sum(arr));
    }

    [Fact]
    public void Sum_EmptySpan_ReturnsZero()
    {
        Assert.Equal(0, SpanDemos.Sum(ReadOnlySpan<int>.Empty));
    }

    [Fact]
    public void Slice_ReturnsCorrectElements()
    {
        int[] arr = { 10, 20, 30, 40, 50 };
        var slice = SpanDemos.Slice(arr, 1, 3);
        Assert.Equal(3, slice.Length);
        Assert.Equal(20, slice[0]);
        Assert.Equal(40, slice[2]);
    }

    [Fact]
    public void ParseFirstInt_ParsesDigits()
    {
        ReadOnlySpan<char> chars = "12345".AsSpan();
        Assert.Equal(12345, SpanDemos.ParseFirstInt(chars));
    }

    [Fact]
    public void StackAllocSum_SumsOneThroughN()
    {
        Assert.Equal(15, SpanDemos.StackAllocSum(5));  // 1+2+3+4+5
        Assert.Equal(55, SpanDemos.StackAllocSum(10)); // 1..10
    }

    [Fact]
    public void MemorySum_CorrectTotal()
    {
        Memory<int> mem = new int[] { 5, 10, 15 };
        Assert.Equal(30, SpanDemos.MemorySum(mem));
    }
}
