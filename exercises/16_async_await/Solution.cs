namespace Kata;

static class AsyncHelpers
{
    public static async Task<string> FetchDataAsync(string id, int delayMs = 10)
    {
        await Task.Delay(delayMs);
        return $"Data for {id}";
    }

    public static async Task<int> SumAsync(IEnumerable<int> numbers)
    {
        await Task.Delay(1);
        return numbers.Sum();
    }

    public static async Task<string[]> FetchAllAsync(string[] ids)
    {
        var tasks = ids.Select(id => FetchDataAsync(id)).ToArray();
        return await Task.WhenAll(tasks);
    }

    public static async Task<string> FetchWithCancellationAsync(string id, CancellationToken ct)
    {
        await Task.Delay(100, ct);
        return $"Data for {id}";
    }
}
