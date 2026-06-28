using Xunit;

public class BoxingUnboxingTests
{
    [Fact]
    public void BoxInt_ReturnsObject()
    {
        object boxed = BoxingDemos.BoxInt(42);
        Assert.IsType<int>(boxed);
        Assert.Equal(42, (int)boxed);
    }

    [Fact]
    public void UnboxInt_ReturnsOriginalValue()
    {
        object boxed = 99;
        Assert.Equal(99, BoxingDemos.UnboxInt(boxed));
    }

    [Fact]
    public void UnboxInt_WrongType_Throws()
    {
        object boxed = "not an int";
        Assert.Throws<InvalidCastException>(() => BoxingDemos.UnboxInt(boxed));
    }

    [Fact]
    public void BoxMany_ContainsAllValues()
    {
        var list = BoxingDemos.BoxMany(new[] { 1, 2, 3 });
        Assert.Equal(3, list.Count);
        Assert.Equal(1, (int)list[0]!);
    }

    [Fact]
    public void NoBoxing_ContainsAllValues()
    {
        var list = BoxingDemos.NoBoxing(new[] { 10, 20, 30 });
        Assert.Equal(3, list.Count);
        Assert.Equal(10, list[0]);
    }

    [Fact]
    public void GetBoxedType_ReturnsInt()
    {
        object boxed = 7;
        Assert.Equal(typeof(int), BoxingDemos.GetBoxedType(boxed));
    }

    [Fact]
    public void IsBoxedInt_TrueForBoxedInt()
    {
        Assert.True(BoxingDemos.IsBoxedInt(42));
    }

    [Fact]
    public void IsBoxedInt_FalseForString()
    {
        Assert.False(BoxingDemos.IsBoxedInt("hello"));
    }
}
