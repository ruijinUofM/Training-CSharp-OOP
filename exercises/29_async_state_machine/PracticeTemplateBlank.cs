using Xunit;

// Async State Machine
//
// async/await is compiler sugar: the method is rewritten into a state machine struct.
// Locals that span an await live on the heap in the state machine.
// If the awaitable is already done, the continuation runs synchronously (no allocation).
// ValueTask<T> avoids Task allocation for synchronous hot paths.
// Task.WhenAll(a, b) runs tasks concurrently; awaiting sequentially runs them one by one.
//
// Implement:
//   public static class AsyncDemos {
//       public static async Task<int> SyncCompletingAsync(int value);
//           // return await Task.FromResult(value);
//       public static async Task<int> DelayedAsync(int ms, int value);
//           // await Task.Delay(ms); return value;
//       public static async Task<int> ConcurrentSumAsync(Task<int> a, Task<int> b);
//           // var results = await Task.WhenAll(a, b); return results[0] + results[1];
//       public static async Task<int> SequentialSumAsync(Func<Task<int>> getA, Func<Task<int>> getB);
//           // int ra = await getA(); int rb = await getB(); return ra + rb;
//       public static async Task<bool> WasAlreadyComplete();
//           // await Task.CompletedTask; return true;
//   }

// Write your implementation below.
