using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void Stack_PushPop_ReturnsLastIn()
    {
        var s = new Stack<int>();
        s.Push(1);
        s.Push(2);
        Assert.Equal(2, s.Pop());
    }

    [Fact]
    public void Stack_Pop_Empty_Throws()
    {
        var s = new Stack<string>();
        Assert.Throws<InvalidOperationException>(() => s.Pop());
    }

    [Fact]
    public void Stack_Peek_DoesNotRemove()
    {
        var s = new Stack<int>();
        s.Push(99);
        Assert.Equal(99, s.Peek());
        Assert.Equal(1, s.Count);
    }

    [Fact]
    public void Stack_IsEmpty_AfterAllPops()
    {
        var s = new Stack<int>();
        s.Push(1);
        s.Pop();
        Assert.True(s.IsEmpty);
    }

    [Fact]
    public void Stack_Count_IsCorrect()
    {
        var s = new Stack<string>();
        s.Push("a");
        s.Push("b");
        Assert.Equal(2, s.Count);
    }

    [Fact]
    public void Pair_First_And_Second()
    {
        var p = new Pair<int, string>(1, "hello");
        Assert.Equal(1, p.First);
        Assert.Equal("hello", p.Second);
    }

    [Fact]
    public void Pair_Swap_ReturnsReversed()
    {
        var p = new Pair<int, string>(42, "world");
        var swapped = p.Swap();
        Assert.Equal("world", swapped.First);
        Assert.Equal(42, swapped.Second);
    }
}
