# 16. Async/Await

## Feature

`async` / `await`, `Task<T>`, `Task.WhenAll`, `CancellationToken`, `OperationCanceledException`.

## Case study

Async helper methods that simulate I/O with `Task.Delay`: `FetchDataAsync`, `SumAsync`, `FetchAllAsync` (parallel), and `FetchWithCancellationAsync`.

## Required API

```csharp
static class AsyncHelpers
{
    public static async Task<string> FetchDataAsync(string id, int delayMs = 10)
    // await Task.Delay(delayMs); return $"Data for {id}";

    public static async Task<int> SumAsync(IEnumerable<int> numbers)
    // await Task.Delay(1); return numbers.Sum();

    public static async Task<string[]> FetchAllAsync(string[] ids)
    // launch all FetchDataAsync calls in parallel, await Task.WhenAll

    public static async Task<string> FetchWithCancellationAsync(string id, CancellationToken ct)
    // await Task.Delay(100, ct);  (throws OperationCanceledException if cancelled)
    // return $"Data for {id}";
}
```

## Things to watch for

- `async Task<T>` methods can be `await`-ed; they run asynchronously and return a `Task<T>`.
- `await Task.Delay(ms)` is the async equivalent of `Thread.Sleep(ms)` — it yields the thread instead of blocking.
- `Task.WhenAll(tasks)` takes an array of tasks and returns a task that completes when ALL of them do.
- `CancellationToken` is passed to `Task.Delay(ms, ct)` — if the token is cancelled, Delay throws `OperationCanceledException`.
- xUnit supports `async Task` test methods natively — just return `Task` from the test.
- `ConfigureAwait(false)` is a library best practice to avoid deadlocks in sync contexts, but not needed in tests.
