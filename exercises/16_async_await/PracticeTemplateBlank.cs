// Async/Await -- AsyncHelpers, written from scratch.
//
// Required methods and behavior (all in static class AsyncHelpers):
//
//   FetchDataAsync(string id, int delayMs = 10) → string (runs asynchronously):
//       Waits delayMs milliseconds without blocking the thread, then returns
//       "Data for {id}".
//
//   SumAsync(IEnumerable<int> numbers) → int (runs asynchronously):
//       Waits 1ms without blocking, then returns the sum of the numbers.
//
//   FetchAllAsync(string[] ids) → string[] (runs asynchronously):
//       Launches FetchDataAsync for all IDs at the same time (in parallel);
//       waits for all to complete; returns all results.
//
//   FetchWithCancellationAsync(string id, CancellationToken ct) → string (runs asynchronously):
//       Waits 100ms respecting the cancellation token; if cancelled, lets the
//       cancellation exception propagate naturally; otherwise returns "Data for {id}".
//
// Note: methods that perform work asynchronously use specific C# keywords for the
//       method signature and for suspending execution. Look them up if unsure.

namespace Kata;

// Write your implementation below.
