using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void Point_ValueEquality()
    {
        Assert.Equal(new Point(1, 2), new Point(1, 2));
    }

    [Fact]
    public void Point_DifferentValues_NotEqual()
    {
        Assert.NotEqual(new Point(1, 2), new Point(3, 4));
    }

    [Fact]
    public void Point_With_Expression()
    {
        var p = new Point(1, 2);
        var p2 = p with { Y = 99 };
        Assert.Equal(1.0, p2.X);
        Assert.Equal(99.0, p2.Y);
        Assert.Equal(2.0, p.Y); // original unchanged
    }

    [Fact]
    public void Point_DistanceTo_345Triangle()
    {
        var a = new Point(0, 0);
        var b = new Point(3, 4);
        Assert.Equal(5.0, a.DistanceTo(b), precision: 10);
    }

    [Fact]
    public void Point_Deconstruct()
    {
        var (x, y) = new Point(7, 8);
        Assert.Equal(7.0, x);
        Assert.Equal(8.0, y);
    }

    [Fact]
    public void Color_ToHex_Red()
    {
        var c = new Color(255, 0, 0);
        Assert.Equal("#FF0000", c.ToHex());
    }

    [Fact]
    public void Color_ToHex_White()
    {
        Assert.Equal("#FFFFFF", new Color(255, 255, 255).ToHex());
    }

    [Fact]
    public void Color_ValueEquality()
    {
        Assert.Equal(new Color(1, 2, 3), new Color(1, 2, 3));
    }
}
