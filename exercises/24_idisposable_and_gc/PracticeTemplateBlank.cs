using Xunit;

// Deterministic Resource Cleanup
//
// Implement:
//
//   DisposableLog — fulfills the standard deterministic cleanup contract.
//       (Look up the C# interface for deterministic cleanup, and how to use
//       a language construct that guarantees cleanup even if an exception is thrown.)
//       IsDisposed (bool) — readable from outside; only settable from within the class.
//       Log (static List<string>) — shared log of disposal events; reference is read-only.
//       Name (string) — read-only; set in constructor.
//       DisposableLog(string name) — constructor.
//       Dispose() — sets IsDisposed to true; appends "disposed:{Name}" to Log.
//       ResetLog() — static; clears Log.
//
//   DisposeDemos — static class:
//       UseWithUsing(string name) — creates a DisposableLog in a block that guarantees
//           cleanup is called on exit (even if an exception is thrown).
//       IsDisposedAfterUsing(string name) → bool — demonstrates that the object is
//           disposed after the block ends; returns true.

// Write your implementation below.
