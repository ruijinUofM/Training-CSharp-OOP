// Generics -- Stack<T> and Pair<T,U>, written from scratch.
//
// Required API:
//
//   class Stack<T>
//   {
//       public void Push(T item)
//       public T Pop()      // throws InvalidOperationException if empty
//       public T Peek()     // throws InvalidOperationException if empty
//       public int Count { get; }
//       public bool IsEmpty { get; }
//   }
//
//   class Pair<T, U>
//   {
//       public T First { get; }
//       public U Second { get; }
//       public Pair(T first, U second)
//       public Pair<U, T> Swap()
//   }

namespace Kata;

// Write your implementation below.
