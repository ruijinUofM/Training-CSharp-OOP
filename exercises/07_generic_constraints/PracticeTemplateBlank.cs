// Generic Constraints, written from scratch.
//
// Required classes and behavior:
//
//   Algorithms — static class with generic helper methods.
//       Max(a, b) → T — returns whichever is greater; the type parameter T must
//           support comparison against itself (i.e., must be comparable to T).
//       AreEqual(a, b) → bool — returns a.Equals(b); the type parameter T must
//           be a value type (not a reference type).
//
//   Repository — a generic collection class.
//       The type parameter must be a reference type AND must have a parameterless
//       constructor.
//       Create() → T — returns a new instance using the default constructor.
//       Add(item) — adds an item to the internal list.
//       FindAll() → List<T> — returns the stored items.
//       Count (int) — number of items stored.

namespace Kata;

// Write your implementation below.
