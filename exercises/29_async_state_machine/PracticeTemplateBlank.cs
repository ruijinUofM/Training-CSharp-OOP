using Xunit;

// Async State Machine
//
// async/await is compiler sugar: the method is rewritten into a state machine struct.
// Locals that span an await live on the heap in the state machine.
// If the awaitable is already done, the continuation runs synchronously (no allocation).
// ValueTask<T> avoids Task allocation for synchronous hot paths.
// Task.WhenAll(a, b) runs tasks concurrently; awaiting sequentially runs them one by one.
//
// Implement (all in static class AsyncDemos):
//   SyncCompletingAsync(int value) → int (asynchronously) — returns value immediately
//       using an already-completed result; no real suspension.
//   DelayedAsync(int ms, int value) → int (asynchronously) — waits ms milliseconds,
//       then returns value.
//   ConcurrentSumAsync(Task<int> a, Task<int> b) → int (asynchronously) — runs a and b
//       concurrently, then sums their results.
//   SequentialSumAsync(Func<Task<int>> getA, Func<Task<int>> getB) → int (asynchronously)
//       — completes getA first, then getB, then sums.
//   WasAlreadyComplete() → bool (asynchronously) — awaits a pre-completed no-op;
//       returns true.

// Write your implementation below.
