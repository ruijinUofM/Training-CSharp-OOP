using Xunit;

// Boxing and Unboxing
//
// Boxing: int → object allocates a heap wrapper around the value.
// Unboxing: (int)obj copies the value back out.
// Generics (List<int>) avoid boxing; ArrayList boxes everything.
//
// Implement:
//   public static class BoxingDemos {
//       public static object BoxInt(int value);
//       public static int UnboxInt(object obj);
//       public static System.Collections.ArrayList BoxMany(IEnumerable<int> values);
//       public static List<int> NoBoxing(IEnumerable<int> values);
//       public static Type GetBoxedType(object obj);
//       public static bool IsBoxedInt(object obj);
//   }

// Write your implementation below.
