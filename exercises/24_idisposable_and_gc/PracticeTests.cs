using Xunit;

public class IDisposableTests
{
    public IDisposableTests() => DisposableLog.ResetLog();

    [Fact]
    public void Dispose_SetsIsDisposed()
    {
        var r = new DisposableLog("x");
        Assert.False(r.IsDisposed);
        r.Dispose();
        Assert.True(r.IsDisposed);
    }

    [Fact]
    public void Dispose_LogsEvent()
    {
        var r = new DisposableLog("myres");
        r.Dispose();
        Assert.Contains("disposed:myres", DisposableLog.Log);
    }

    [Fact]
    public void UseWithUsing_CallsDispose()
    {
        DisposeDemos.UseWithUsing("demo");
        Assert.Contains("disposed:demo", DisposableLog.Log);
    }

    [Fact]
    public void IsDisposedAfterUsing_ReturnsTrue()
    {
        Assert.True(DisposeDemos.IsDisposedAfterUsing("check"));
    }

    [Fact]
    public void DisposableLog_ImplementsIDisposable()
    {
        Assert.IsAssignableFrom<IDisposable>(new DisposableLog("test"));
    }
}
