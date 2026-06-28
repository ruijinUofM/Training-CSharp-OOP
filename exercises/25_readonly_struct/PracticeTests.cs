using Xunit;

public class ReadonlyStructTests
{
    [Fact]
    public void Constructor_SetsFields()
    {
        var v = new Vector2(3, 4);
        Assert.Equal(3, v.X);
        Assert.Equal(4, v.Y);
    }

    [Fact]
    public void Length_ThreeFourFive()
    {
        var v = new Vector2(3, 4);
        Assert.Equal(5.0, v.Length, precision: 10);
    }

    [Fact]
    public void Add_ReturnsNewVector()
    {
        var a = new Vector2(1, 2);
        var b = new Vector2(3, 4);
        var c = a.Add(b);
        Assert.Equal(4, c.X);
        Assert.Equal(6, c.Y);
    }

    [Fact]
    public void Scale_ReturnsNewVector()
    {
        var v = new Vector2(2, 3);
        var s = v.Scale(2.0);
        Assert.Equal(4, s.X);
        Assert.Equal(6, s.Y);
    }

    [Fact]
    public void Equals_SameValues_True()
    {
        var a = new Vector2(1, 2);
        var b = new Vector2(1, 2);
        Assert.True(a.Equals(b));
    }

    [Fact]
    public void Equals_DifferentValues_False()
    {
        var a = new Vector2(1, 2);
        var b = new Vector2(3, 4);
        Assert.False(a.Equals(b));
    }

    [Fact]
    public void Zero_IsOrigin()
    {
        var z = Vector2.Zero;
        Assert.Equal(0, z.X);
        Assert.Equal(0, z.Y);
    }

    [Fact]
    public void Vector2_IsValueType()
    {
        Assert.True(typeof(Vector2).IsValueType);
    }
}
