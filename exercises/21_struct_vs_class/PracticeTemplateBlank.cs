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
//   Point — a VALUE type (not a class) with two int fields: X and Y.
//       Constructor sets X and Y.
//
//   Box — a REFERENCE type with one int property: Value (readable and writable).
//       Constructor sets Value.
//
//   Demos — static class:
//       StructsAreCopied(Point a, Point modifiedB) → bool
//           — demonstrates structs are copied; return true.
//       ClassesAreShared(Box original, Box alias) → bool
//           — demonstrates both variables point to the same object; return true.
//       IsValueType(Type t) → bool — true if t is a value type.
//       IsReferenceType(Type t) → bool — true if t is not a value type.

// Write your implementation below.
