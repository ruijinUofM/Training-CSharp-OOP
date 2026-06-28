using Xunit;

// IDisposable, using, and the GC
//
// The GC manages heap memory but NOT unmanaged resources (files, sockets, etc.).
// IDisposable.Dispose() releases them deterministically.
// 'using' guarantees Dispose() is called even if an exception is thrown.
// Finalizers (~MyClass()) are a last-resort safety net — non-deterministic.
// Call GC.SuppressFinalize(this) in Dispose() to skip unnecessary finalization.
//
// Implement:
//   public class DisposableLog : IDisposable {
//       public bool IsDisposed { get; private set; }
//       public static List<string> Log { get; } = new();
//       public string Name { get; }
//       public DisposableLog(string name);  // Name = name
//       public void Dispose();              // IsDisposed = true; Log.Add($"disposed:{Name}");
//       public static void ResetLog();      // Log.Clear();
//   }
//   public static class DisposeDemos {
//       public static void UseWithUsing(string name);
//           // using (var r = new DisposableLog(name)) { }
//       public static bool IsDisposedAfterUsing(string name);
//           // DisposableLog r; using (r = new DisposableLog(name)) { } return r.IsDisposed;
//   }

// Write your implementation below.
