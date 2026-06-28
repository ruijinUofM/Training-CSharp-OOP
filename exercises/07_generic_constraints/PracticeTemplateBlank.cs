// Generic Constraints, written from scratch.
//
// Required API:
//
//   static class Algorithms
//   {
//       public static T Max<T>(T a, T b) where T : IComparable<T>
//           // a.CompareTo(b) >= 0 ? a : b
//
//       public static bool AreEqual<T>(T a, T b) where T : struct
//           // a.Equals(b)
//   }
//
//   class Repository<T> where T : class, new()
//   {
//       public T Create()           // new T()
//       public void Add(T item)
//       public List<T> FindAll()    // returns items
//       public int Count { get; }
//   }

namespace Kata;

// Write your implementation below.
