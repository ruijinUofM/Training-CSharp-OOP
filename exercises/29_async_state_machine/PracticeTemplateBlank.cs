using Xunit;

// Async State Machine
//
// Implement (all in static class AsyncDemos):
//   SyncCompletingAsync(int value) → int (runs asynchronously) — returns value
//       immediately using an already-completed result; no real suspension.
//   DelayedAsync(int ms, int value) → int (runs asynchronously) — waits ms
//       milliseconds, then returns value.
//   ConcurrentSumAsync(Task<int> a, Task<int> b) → int (runs asynchronously)
//       — runs a and b concurrently, then sums their results.
//   SequentialSumAsync(Func<Task<int>> getA, Func<Task<int>> getB) → int (runs asynchronously)
//       — completes getA first, then getB, then sums.
//   WasAlreadyComplete() → bool (runs asynchronously) — awaits a pre-completed no-op;
//       returns true.
//
// Note: figure out what C# keywords enable a method to be awaited and to suspend
// without blocking a thread. Look up how to run multiple tasks concurrently vs. sequentially.

// Write your implementation below.
