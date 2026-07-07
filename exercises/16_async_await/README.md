# 16. Async/Await

## Feature

`async` / `await`, `Task<T>`, `Task.WhenAll`, `CancellationToken`, `OperationCanceledException`.

## When to use it / When to avoid it

`async`/`await` exists to keep threads free while waiting on I/O (network, disk, timers) instead of blocking them idle — critical for scalability under load (a blocked thread can't serve other requests).

- **Use it when**: the operation is I/O-bound — HTTP calls, database queries, file access, or anywhere you'd otherwise call a blocking wait.
- **Avoid it when**: the work is CPU-bound — `async`/`await` doesn't parallelize computation by itself; use `Task.Run`/parallelism for that instead. Also avoid marking a method `async` "for consistency" when it wraps trivial synchronous logic — every `async` method pays for a compiler-generated state machine and `Task` allocation even if nothing ever actually suspends.

## Case study

Async helper methods that simulate I/O with `Task.Delay`: `FetchDataAsync`, `SumAsync`, `FetchAllAsync` (parallel), and `FetchWithCancellationAsync`.

## Required methods and behavior (all in static class AsyncHelpers)

- `FetchDataAsync(string id, int delayMs = 10)` → string (runs asynchronously):
  Waits delayMs milliseconds without blocking the thread, then returns `"Data for {id}"`.

- `SumAsync(IEnumerable<int> numbers)` → int (runs asynchronously):
  Waits 1ms without blocking, then returns the sum.

- `FetchAllAsync(string[] ids)` → string[] (runs asynchronously):
  Launches FetchDataAsync for all IDs at the same time; waits for all to complete; returns all results.

- `FetchWithCancellationAsync(string id, CancellationToken ct)` → string (runs asynchronously):
  Waits 100ms respecting the cancellation token; if cancelled, the cancellation exception propagates naturally; otherwise returns `"Data for {id}"`.

Note: methods that perform work asynchronously use specific C# keywords for the method signature and for suspending execution. Look them up if unsure.

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
static class Helpers
{
    // "async" + returns Task<T> — await-able, runs asynchronously
    public static async Task<string> FetchAsync(string id, int delayMs = 10)
    {
        await Task.Delay(delayMs);   // yields the thread instead of blocking it
        return $"Data for {id}";
    }

    // launching several async calls concurrently, then waiting for all of them
    public static async Task<string[]> FetchAllAsync(string[] ids)
    {
        var tasks = ids.Select(id => FetchAsync(id)).ToArray();
        return await Task.WhenAll(tasks);
    }

    // respecting a CancellationToken
    public static async Task<string> FetchWithCancellationAsync(string id, CancellationToken ct)
    {
        await Task.Delay(100, ct);   // throws OperationCanceledException if ct is cancelled
        return $"Data for {id}";
    }
}

// calling into async code
string result = await Helpers.FetchAsync("42");
```

</details>

## Things to watch for

- `async Task<T>` methods can be `await`-ed; they run asynchronously and return a `Task<T>`.
- `await Task.Delay(ms)` is the async equivalent of `Thread.Sleep(ms)` — it yields the thread instead of blocking.
- `Task.WhenAll(tasks)` takes an array of tasks and returns a task that completes when ALL of them do.
- `CancellationToken` is passed to `Task.Delay(ms, ct)` — if the token is cancelled, Delay throws `OperationCanceledException`.
- xUnit supports `async Task` test methods natively — just return `Task` from the test.
- `ConfigureAwait(false)` is a library best practice to avoid deadlocks in sync contexts, but not needed in tests.
