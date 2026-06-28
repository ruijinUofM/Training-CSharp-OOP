using Xunit;

public class RefOutInTests
{
    [Fact]
    public void Swap_SwapsValues()
    {
        int a = 3, b = 7;
        ParameterDemos.Swap(ref a, ref b);
        Assert.Equal(7, a);
        Assert.Equal(3, b);
    }

    [Fact]
    public void TryDouble_ValidString_ReturnsDoubled()
    {
        bool ok = ParameterDemos.TryDouble("5", out int result);
        Assert.True(ok);
        Assert.Equal(10, result);
    }

    [Fact]
    public void TryDouble_InvalidString_ReturnsFalse()
    {
        bool ok = ParameterDemos.TryDouble("abc", out int result);
        Assert.False(ok);
        Assert.Equal(0, result);
    }

    [Fact]
    public void SumWithRef_AccumulatesCorrectly()
    {
        int total = 0;
        ParameterDemos.SumWithRef(ref total, 10);
        ParameterDemos.SumWithRef(ref total, 5);
        Assert.Equal(15, total);
    }

    [Fact]
    public void ReadOnly_ReturnsDoubled()
    {
        int n = 6;
        Assert.Equal(12, ParameterDemos.ReadOnly(in n));
    }
}
