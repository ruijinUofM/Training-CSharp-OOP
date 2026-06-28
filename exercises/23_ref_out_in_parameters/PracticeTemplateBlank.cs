using Xunit;

// ref / out / in Parameters
//
// ref: caller initializes; method reads and writes caller's variable.
// out: method must write before returning; caller doesn't need to initialize.
// in:  read-only reference (avoids copy for large structs; cannot mutate).
//
// Implement:
//   public static class ParameterDemos {
//       public static void Swap(ref int a, ref int b);
//       public static bool TryDouble(string s, out int result);
//           // parse s; if success result = parsed*2; else result = 0; return false
//       public static int SumWithRef(ref int accumulator, int value);
//           // accumulator += value; return accumulator
//       public static int ReadOnly(in int value);
//           // return value * 2
//   }

// Write your implementation below.
