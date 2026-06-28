using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public async Task FetchDataAsync_ReturnsExpectedString()
    {
        var result = await AsyncHelpers.FetchDataAsync("x");
        Assert.Equal("Data for x", result);
    }

    [Fact]
    public async Task SumAsync_ReturnsCorrectSum()
    {
        var result = await AsyncHelpers.SumAsync(new[] { 1, 2, 3, 4 });
        Assert.Equal(10, result);
    }

    [Fact]
    public async Task FetchAllAsync_ReturnsAllResults()
    {
        var results = await AsyncHelpers.FetchAllAsync(new[] { "a", "b", "c" });
        Assert.Equal(3, results.Length);
        Assert.Contains("Data for a", results);
        Assert.Contains("Data for b", results);
        Assert.Contains("Data for c", results);
    }

    [Fact]
    public async Task FetchWithCancellation_Completes_WhenNotCancelled()
    {
        using var cts = new CancellationTokenSource();
        var result = await AsyncHelpers.FetchWithCancellationAsync("y", cts.Token);
        Assert.Equal("Data for y", result);
    }

    [Fact]
    public async Task FetchWithCancellation_Throws_WhenCancelled()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();
        await Assert.ThrowsAnyAsync<OperationCanceledException>(
            () => AsyncHelpers.FetchWithCancellationAsync("z", cts.Token));
    }
}
