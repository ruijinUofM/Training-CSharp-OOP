using Xunit;

public class GcInternalsTests
{
    [Fact]
    public void NewObject_IsGen0()
    {
        object o = new object();
        Assert.Equal(0, GcDemos.GetGeneration(o));
    }

    [Fact]
    public void GetGeneration_ReturnsValidGeneration()
    {
        object o = new object();
        int gen = GcDemos.GetGeneration(o);
        Assert.InRange(gen, 0, 2);
    }

    [Fact]
    public void TotalMemory_ReturnsPositive()
    {
        long mem = GcDemos.TotalMemory(false);
        Assert.True(mem > 0);
    }

    [Fact]
    public void WeakRef_IsAlive_WhenStrongRefExists()
    {
        var obj = new object();
        var wr = GcDemos.MakeWeak(obj);
        Assert.True(GcDemos.IsAlive(wr));
        GC.KeepAlive(obj); // ensure strong ref is kept until here
    }

    [Fact]
    public void WeakRef_IsNotAlive_AfterCollect()
    {
        WeakReference<object> wr;
        {
            var obj = new object();
            wr = GcDemos.MakeWeak(obj);
        }
        GcDemos.CollectAll();
        Assert.False(GcDemos.IsAlive(wr));
    }

    [Fact]
    public void LohThreshold_Is85000()
    {
        Assert.Equal(85_000, GcDemos.LohThresholdBytes);
    }

    [Fact]
    public void CollectAll_DoesNotThrow()
    {
        var ex = Record.Exception(() => GcDemos.CollectAll());
        Assert.Null(ex);
    }
}
