# 16. Async/Await

## Feature

`async` / `await`, `Task<T>`, `Task.WhenAll`, `CancellationToken`, `OperationCanceledException`.

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

## Things to watch for

- `async Task<T>` methods can be `await`-ed; they run asynchronously and return a `Task<T>`.
- `await Task.Delay(ms)` is the async equivalent of `Thread.Sleep(ms)` — it yields the thread instead of blocking.
- `Task.WhenAll(tasks)` takes an array of tasks and returns a task that completes when ALL of them do.
- `CancellationToken` is passed to `Task.Delay(ms, ct)` — if the token is cancelled, Delay throws `OperationCanceledException`.
- xUnit supports `async Task` test methods natively — just return `Task` from the test.
- `ConfigureAwait(false)` is a library best practice to avoid deadlocks in sync contexts, but not needed in tests.
