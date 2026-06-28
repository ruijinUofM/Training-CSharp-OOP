using Xunit;

// Struct vs Class — Value Types vs Reference Types
//
// struct = value type: copied on assignment, stored inline (stack for locals).
// class  = reference type: heap-allocated, variable holds a reference.
//
// Key consequence:
//   Point b = a;   → b is a copy, mutating b does NOT affect a.
//   Box   b = a;   → b is an alias, mutating b DOES affect a.
//
// Implement:
//   public struct Point { public int X, Y; ... }
//   public class Box { public int Value { get; set; } ... }
//   public static class Demos {
//       public static bool StructsAreCopied();
//       public static bool ClassesAreShared();
//       public static bool IsValueType(Type t);
//       public static bool IsReferenceType(Type t);
//   }

// Write your implementation below.
