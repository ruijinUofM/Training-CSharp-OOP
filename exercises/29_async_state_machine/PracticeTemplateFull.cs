using Xunit;

public static class AsyncDemos
{
    // Immediately completed — state machine never suspends
    public static async Task<int> SyncCompletingAsync(int value)
    {
        throw new NotImplementedException();
        // hint: return value; (you need at least one await somewhere to be async)
        // OR: return await Task.FromResult(value);
    }

    // Simulated I/O: delay ms milliseconds, then return value
    public static async Task<int> DelayedAsync(int ms, int value)
    {
        throw new NotImplementedException();
        // await Task.Delay(ms);
        // return value;
    }

    // Run a and b concurrently using Task.WhenAll
    public static async Task<int> ConcurrentSumAsync(Task<int> a, Task<int> b)
    {
        throw new NotImplementedException();
    }

    // Run getA, then getB sequentially (second doesn't start until first finishes)
    public static async Task<int> SequentialSumAsync(Func<Task<int>> getA, Func<Task<int>> getB)
    {
        throw new NotImplementedException();
    }

    // Demonstrates awaiting an already-completed task
    public static async Task<bool> WasAlreadyComplete()
    {
        throw new NotImplementedException();
        // await Task.CompletedTask;
        // return true;
    }
}
