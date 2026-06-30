// Generics -- Stack<T> and Pair<T,U>, written from scratch.
//
// Required classes and behavior:
//
//   Stack — a generic LIFO collection typed over one type parameter.
//       Push(item) — adds an item to the top.
//       Pop() → item — removes and returns the top item;
//           throws InvalidOperationException if empty.
//       Peek() → item — returns the top item without removing it;
//           throws InvalidOperationException if empty.
//       Count (int) — number of items currently in the stack.
//       IsEmpty (bool) — true when Count == 0.
//
//   Pair — holds two values of potentially different types (two type parameters).
//       First — the first value; read-only.
//       Second — the second value; read-only.
//       Constructor — takes first and second values.
//       Swap() → Pair — returns a new Pair with First and Second swapped
//           (with the type parameters also swapped).

namespace Kata;

// Write your implementation below.
