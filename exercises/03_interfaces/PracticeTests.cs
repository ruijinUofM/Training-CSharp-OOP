using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void Circle_Implements_IDrawable()
    {
        Assert.IsAssignableFrom<IDrawable>(new Circle(5));
    }

    [Fact]
    public void Circle_Implements_IResizable()
    {
        Assert.IsAssignableFrom<IResizable>(new Circle(5));
    }

    [Fact]
    public void Circle_Resize_ChangesRadius()
    {
        var c = new Circle(10);
        c.Resize(2.0);
        Assert.Equal(20.0, c.Radius);
    }

    [Fact]
    public void Square_Resize_ChangesSide()
    {
        var s = new Square(4);
        s.Resize(0.5);
        Assert.Equal(2.0, s.Side);
    }

    [Fact]
    public void IResizable_Resize_WorksThroughInterface()
    {
        IResizable r = new Circle(8);
        r.Resize(3);
        Assert.Equal(24.0, ((Circle)r).Radius);
    }

    [Fact]
    public void Draw_DoesNotThrow()
    {
        var c = new Circle(1);
        var ex = Record.Exception(() => c.Draw());
        Assert.Null(ex);
    }

    [Fact]
    public void Square_Implements_IDrawable()
    {
        Assert.IsAssignableFrom<IDrawable>(new Square(3));
    }
}
