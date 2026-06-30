# 29. Async State Machine

## Intent

Understand what the C# compiler does when it sees `async`/`await` — it rewrites the method into a **state machine struct** on the heap that can be suspended and resumed.

## What the compiler generates

```csharp
// Your code:
public async Task<int> FetchAsync()
{
    int a = await GetAAsync();
    int b = await GetBAsync();
    return a + b;
}

// Compiler generates roughly:
// struct FetchAsyncStateMachine : IAsyncStateMachine
// {
//     int _state;          // -1 running, 0 at first await, 1 at second await, -2 done
//     int a, b;            // locals captured across awaits
//     TaskCompletionSource<int> _tcs;
//     void MoveNext() {    // called on resume
//         switch (_state) {
//             case -1: /* start */ ...
//             case 0:  /* after GetAAsync */ ...
//             case 1:  /* after GetBAsync */ ...
//         }
//     }
// }
```

Key points:
- Locals that span an `await` live in the **state machine struct** (on the heap, not the call stack).
- If no `await` suspends (the awaitable is already complete), the continuation runs synchronously on the same thread — no real suspension occurs.
- `ValueTask<T>` avoids the `Task` allocation when the result is synchronous (common hot path optimization).
- `ConfigureAwait(false)` tells the runtime not to resume on the captured synchronization context (important in library code to avoid deadlocks).

## Why this matters for performance

Each `async` method allocates: the state machine (unless it completes synchronously), the `Task`/`ValueTask` object. Use `ValueTask` in hot paths where synchronous completion is common.

## Required implementation (all in static class AsyncDemos)

- `SyncCompletingAsync(int value)` → int (asynchronously) — returns value immediately using an already-completed result; no real suspension.
- `DelayedAsync(int ms, int value)` → int (asynchronously) — waits ms milliseconds, then returns value.
- `ConcurrentSumAsync(Task<int> a, Task<int> b)` → int (asynchronously) — runs a and b concurrently, then sums their results.
- `SequentialSumAsync(Func<Task<int>> getA, Func<Task<int>> getB)` → int (asynchronously) — completes getA first, then getB, then sums.
- `WasAlreadyComplete()` → bool (asynchronously) — awaits a pre-completed no-op; returns true.
