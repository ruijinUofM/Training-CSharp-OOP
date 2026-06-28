using Xunit;

public class AsyncStateMachineTests
{
    [Fact]
    public async Task SyncCompleting_ReturnsValue()
    {
        int result = await AsyncDemos.SyncCompletingAsync(42);
        Assert.Equal(42, result);
    }

    [Fact]
    public async Task Delayed_ReturnsValue()
    {
        int result = await AsyncDemos.DelayedAsync(10, 99);
        Assert.Equal(99, result);
    }

    [Fact]
    public async Task ConcurrentSum_IsCorrect()
    {
        var a = Task.FromResult(3);
        var b = Task.FromResult(7);
        int sum = await AsyncDemos.ConcurrentSumAsync(a, b);
        Assert.Equal(10, sum);
    }

    [Fact]
    public async Task ConcurrentSum_RunsInParallel()
    {
        // Each task delays 50ms; concurrent should finish in ~50ms
        var start = System.Diagnostics.Stopwatch.GetTimestamp();
        var a = AsyncDemos.DelayedAsync(50, 1);
        var b = AsyncDemos.DelayedAsync(50, 2);
        int sum = await AsyncDemos.ConcurrentSumAsync(a, b);
        double elapsed = System.Diagnostics.Stopwatch.GetElapsedTime(start).TotalMilliseconds;
        Assert.Equal(3, sum);
        Assert.True(elapsed < 150, $"Expected concurrent but took {elapsed:F0}ms");
    }

    [Fact]
    public async Task SequentialSum_IsCorrect()
    {
        int result = await AsyncDemos.SequentialSumAsync(
            () => Task.FromResult(4),
            () => Task.FromResult(6));
        Assert.Equal(10, result);
    }

    [Fact]
    public async Task WasAlreadyComplete_ReturnsTrue()
    {
        Assert.True(await AsyncDemos.WasAlreadyComplete());
    }
}
