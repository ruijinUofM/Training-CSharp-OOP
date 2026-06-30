// Sealed Classes -- Logger hierarchy, written from scratch.
//
// Required classes and behavior:
//
//   Logger — base class; cannot be instantiated directly.
//       LastMessage (string) — stores the last logged message; settable from
//           this class and its subclasses only; defaults to "".
//       Log(string message) — every concrete subclass must provide its own.
//
//   ConsoleLogger : Logger — NOT restricted from being subclassed further.
//       Log(string message) — sets LastMessage; prints to console.
//
//   FileLogger : Logger — CANNOT be subclassed; no further inheritance allowed.
//       FilePath (string) — read-only; set via constructor.
//       FileLogger(string filePath) — constructor.
//       Log(string message) — sets LastMessage (simulates file write).
//
// Behavior notes:
//   - typeof(FileLogger).IsSealed == true
//   - typeof(ConsoleLogger).IsSealed == false
//   - FileLogger cannot be inherited (compile error if attempted)

namespace Kata;

// Write your implementation below.
