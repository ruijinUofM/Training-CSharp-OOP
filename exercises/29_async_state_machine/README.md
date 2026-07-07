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

## When to use it / When to avoid it

Understanding the compiler-generated state machine explains two decisions you'll make repeatedly in real async code.

- **Use `async` when**: the method actually awaits something that can genuinely suspend (I/O, a delay, another async call) — that's the case the state machine exists for. Run independent awaited operations concurrently (start all the tasks, then await them) rather than sequentially, when they don't depend on each other's results.
- **Avoid it when**: a method never really suspends (an already-completed result) — marking it `async` still pays for a state machine and `Task` allocation for no benefit; consider returning the inner `Task`/`ValueTask` directly instead. Also avoid awaiting operations sequentially in a loop when they could run concurrently — that serializes work that didn't need to be serial.

## Why this matters for performance

Each `async` method allocates: the state machine (unless it completes synchronously), the `Task`/`ValueTask` object. Use `ValueTask` in hot paths where synchronous completion is common.

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
// completes synchronously — Task.FromResult wraps an already-available value
static async Task<int> SyncCompletingAsync(int value)
    => await Task.FromResult(value);

static async Task<int> DelayedAsync(int ms, int value)
{
    await Task.Delay(ms);          // genuinely suspends here
    return value;
}

// concurrent: start/await both together via WhenAll
static async Task<int> ConcurrentSumAsync(Task<int> a, Task<int> b)
{
    int[] results = await Task.WhenAll(a, b);
    return results[0] + results[1];
}

// sequential: each await blocks on the previous one finishing first
static async Task<int> SequentialSumAsync(Func<Task<int>> getA, Func<Task<int>> getB)
{
    int ra = await getA();
    int rb = await getB();
    return ra + rb;
}
```

</details>

## Required implementation (all in static class AsyncDemos)

- `SyncCompletingAsync(int value)` → int (asynchronously) — returns value immediately using an already-completed result; no real suspension.
- `DelayedAsync(int ms, int value)` → int (asynchronously) — waits ms milliseconds, then returns value.
- `ConcurrentSumAsync(Task<int> a, Task<int> b)` → int (asynchronously) — runs a and b concurrently, then sums their results.
- `SequentialSumAsync(Func<Task<int>> getA, Func<Task<int>> getB)` → int (asynchronously) — completes getA first, then getB, then sums.
- `WasAlreadyComplete()` → bool (asynchronously) — awaits a pre-completed no-op; returns true.
