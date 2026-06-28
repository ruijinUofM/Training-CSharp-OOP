// Async/Await -- AsyncHelpers, written from scratch.
//
// Required API:
//
//   static class AsyncHelpers
//   {
//       public static async Task<string> FetchDataAsync(string id, int delayMs = 10)
//           // await Task.Delay(delayMs); return $"Data for {id}";
//
//       public static async Task<int> SumAsync(IEnumerable<int> numbers)
//           // await Task.Delay(1); return numbers.Sum();
//
//       public static async Task<string[]> FetchAllAsync(string[] ids)
//           // launch all FetchDataAsync calls, Task.WhenAll
//
//       public static async Task<string> FetchWithCancellationAsync(string id, CancellationToken ct)
//           // await Task.Delay(100, ct); return $"Data for {id}";
//           // OperationCanceledException bubbles up if cancelled
//   }
//
// Notes:
//   - xUnit test methods can return Task.
//   - Task.WhenAll(tasks) returns Task<T[]>.

namespace Kata;

// Write your implementation below.
