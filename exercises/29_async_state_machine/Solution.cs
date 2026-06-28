using Xunit;

public static class AsyncDemos
{
    public static async Task<int> SyncCompletingAsync(int value)
        => await Task.FromResult(value);

    public static async Task<int> DelayedAsync(int ms, int value)
    {
        await Task.Delay(ms);
        return value;
    }

    public static async Task<int> ConcurrentSumAsync(Task<int> a, Task<int> b)
    {
        int[] results = await Task.WhenAll(a, b);
        return results[0] + results[1];
    }

    public static async Task<int> SequentialSumAsync(Func<Task<int>> getA, Func<Task<int>> getB)
    {
        int ra = await getA();
        int rb = await getB();
        return ra + rb;
    }

    public static async Task<bool> WasAlreadyComplete()
    {
        await Task.CompletedTask;
        return true;
    }
}
