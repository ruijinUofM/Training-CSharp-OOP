using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void Circle_Area_IsCorrect()
    {
        Assert.Equal(Math.PI * 25, ShapeMath.Area(new Circle(5)), precision: 10);
    }

    [Fact]
    public void Rectangle_Area_IsCorrect()
    {
        Assert.Equal(12.0, ShapeMath.Area(new Rectangle(3, 4)));
    }

    [Fact]
    public void Triangle_Area_IsCorrect()
    {
        // 3-4-5 right triangle: area = 6
        Assert.Equal(6.0, ShapeMath.Area(new Triangle(3, 4, 5)), precision: 10);
    }

    [Fact]
    public void Classify_Negative()
    {
        Assert.Equal("negative", ShapeMath.Classify(-5));
    }

    [Fact]
    public void Classify_Zero()
    {
        Assert.Equal("zero", ShapeMath.Classify(0));
    }

    [Fact]
    public void Classify_Small()
    {
        Assert.Equal("small", ShapeMath.Classify(5));
    }

    [Fact]
    public void Classify_Large()
    {
        Assert.Equal("large", ShapeMath.Classify(100));
    }

    [Fact]
    public void Classify_BoundaryNine_IsSmall()
    {
        Assert.Equal("small", ShapeMath.Classify(9));
    }

    [Fact]
    public void Classify_BoundaryTen_IsLarge()
    {
        Assert.Equal("large", ShapeMath.Classify(10));
    }
}
