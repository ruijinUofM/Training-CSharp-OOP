using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void Shape_IsAbstract()
    {
        Assert.True(typeof(Shape).IsAbstract);
    }

    [Fact]
    public void Circle_Area_IsCorrect()
    {
        var c = new Circle(5);
        Assert.Equal(Math.PI * 25, c.Area(), precision: 10);
    }

    [Fact]
    public void Circle_Perimeter_IsCorrect()
    {
        var c = new Circle(3);
        Assert.Equal(2 * Math.PI * 3, c.Perimeter(), precision: 10);
    }

    [Fact]
    public void Rectangle_Area_IsCorrect()
    {
        var r = new Rectangle(3, 4);
        Assert.Equal(12.0, r.Area());
    }

    [Fact]
    public void Rectangle_Perimeter_IsCorrect()
    {
        var r = new Rectangle(3, 4);
        Assert.Equal(14.0, r.Perimeter());
    }

    [Fact]
    public void Circle_Describe_ContainsTypeName()
    {
        var c = new Circle(1);
        Assert.Contains("Circle", c.Describe());
    }

    [Fact]
    public void Rectangle_Describe_ContainsArea()
    {
        var r = new Rectangle(2, 3);
        Assert.Contains("6", r.Describe());
    }

    [Fact]
    public void Circle_IsA_Shape()
    {
        Assert.IsAssignableFrom<Shape>(new Circle(1));
    }
}
