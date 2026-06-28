// Sealed Classes -- Logger hierarchy, written from scratch.
//
// Required API:
//
//   abstract class Logger
//   {
//       public abstract void Log(string message);
//       public string LastMessage { get; protected set; } = "";
//   }
//
//   class ConsoleLogger : Logger      // NOT sealed
//   {
//       public override void Log(string message)  // sets LastMessage, prints to console
//   }
//
//   sealed class FileLogger : Logger   // SEALED
//   {
//       public string FilePath { get; }
//       public FileLogger(string filePath)
//       public override void Log(string message)  // sets LastMessage (simulates file write)
//   }
//
// Behavior notes:
//   - typeof(FileLogger).IsSealed == true
//   - typeof(ConsoleLogger).IsSealed == false
//   - FileLogger cannot be inherited (compile error if attempted)

namespace Kata;

// Write your implementation below.
