// Delegates and Events -- Button + Counter, written from scratch.
//
// Required classes and behavior:
//
//   Button:
//       Clicked — a notification that fires when Click() is called. Subscribers
//           receive the sender (the Button) and an EventArgs. Uses the standard
//           .NET event handler delegate shape (object sender, EventArgs e).
//       Click() — raises the Clicked notification to all subscribers.
//
//   Counter:
//       Count (int) — readable from outside; only changeable from within the class.
//       CountChanged — a notification that fires after each Increment(); subscribers
//           receive the new Count value as an int.
//       Increment() — increments Count by 1, then fires CountChanged with the new value.
//
// Notes:
//   - C# has a specific keyword for declaring observable notifications on a class.
//   - Callers subscribe using += and unsubscribe using -=.
//   - Firing safely when no subscribers are attached requires a null-conditional call.

namespace Kata;

// Write your implementation below.
