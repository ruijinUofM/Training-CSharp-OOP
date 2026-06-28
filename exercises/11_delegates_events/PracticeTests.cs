using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void Button_Click_FiresEvent()
    {
        var btn = new Button();
        int fired = 0;
        btn.Clicked += (s, e) => fired++;
        btn.Click();
        Assert.Equal(1, fired);
    }

    [Fact]
    public void Button_Click_NoSubscribers_DoesNotThrow()
    {
        var btn = new Button();
        var ex = Record.Exception(() => btn.Click());
        Assert.Null(ex);
    }

    [Fact]
    public void Button_Click_MultipleSubscribers_AllCalled()
    {
        var btn = new Button();
        int count = 0;
        btn.Clicked += (s, e) => count++;
        btn.Clicked += (s, e) => count++;
        btn.Click();
        Assert.Equal(2, count);
    }

    [Fact]
    public void Counter_Increment_IncreasesCount()
    {
        var c = new Counter();
        c.Increment();
        Assert.Equal(1, c.Count);
    }

    [Fact]
    public void Counter_CountChanged_FiresWithNewCount()
    {
        var c = new Counter();
        int lastValue = 0;
        c.CountChanged += v => lastValue = v;
        c.Increment();
        Assert.Equal(1, lastValue);
        c.Increment();
        Assert.Equal(2, lastValue);
    }

    [Fact]
    public void Counter_NoSubscribers_DoesNotThrow()
    {
        var c = new Counter();
        var ex = Record.Exception(() => c.Increment());
        Assert.Null(ex);
    }
}
