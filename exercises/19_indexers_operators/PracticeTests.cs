using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void Indexer_SetAndGet()
    {
        var m = new Matrix(2, 2);
        m[0, 0] = 1.0;
        m[1, 1] = 4.0;
        Assert.Equal(1.0, m[0, 0]);
        Assert.Equal(4.0, m[1, 1]);
        Assert.Equal(0.0, m[0, 1]);
    }

    [Fact]
    public void Addition_ElementWise()
    {
        var a = new Matrix(2, 2);
        a[0, 0] = 1; a[0, 1] = 2;
        a[1, 0] = 3; a[1, 1] = 4;

        var b = new Matrix(2, 2);
        b[0, 0] = 5; b[0, 1] = 6;
        b[1, 0] = 7; b[1, 1] = 8;

        var c = a + b;
        Assert.Equal(6.0, c[0, 0]);
        Assert.Equal(8.0, c[0, 1]);
        Assert.Equal(10.0, c[1, 0]);
        Assert.Equal(12.0, c[1, 1]);
    }

    [Fact]
    public void ScalarMultiplication()
    {
        var m = new Matrix(1, 2);
        m[0, 0] = 3; m[0, 1] = 5;
        var scaled = m * 2.0;
        Assert.Equal(6.0, scaled[0, 0]);
        Assert.Equal(10.0, scaled[0, 1]);
    }

    [Fact]
    public void Equality_SameValues()
    {
        var a = new Matrix(2, 2);
        a[0, 0] = 1;
        var b = new Matrix(2, 2);
        b[0, 0] = 1;
        Assert.True(a == b);
    }

    [Fact]
    public void Inequality_DifferentValues()
    {
        var a = new Matrix(2, 2);
        a[0, 0] = 1;
        var b = new Matrix(2, 2);
        b[0, 0] = 2;
        Assert.True(a != b);
    }

    [Fact]
    public void Matrix_ZeroInitialized()
    {
        var m = new Matrix(3, 3);
        Assert.Equal(0.0, m[2, 2]);
    }
}
