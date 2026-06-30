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
//
//   DisposableLog — fulfills the standard deterministic cleanup contract (IDisposable).
//       IsDisposed (bool) — readable from outside; only settable from within the class.
//       Log (static List<string>) — shared log of disposal events; reference is read-only.
//       Name (string) — read-only; set in constructor.
//       DisposableLog(string name) — constructor.
//       Dispose() — sets IsDisposed to true; appends "disposed:{Name}" to Log.
//       ResetLog() — static; clears Log.
//
//   DisposeDemos — static class:
//       UseWithUsing(string name) — creates a DisposableLog in a block that guarantees
//           Dispose() is called on exit (even if an exception is thrown).
//       IsDisposedAfterUsing(string name) → bool — demonstrates that the object is
//           disposed after the block ends; returns true.

// Write your implementation below.
