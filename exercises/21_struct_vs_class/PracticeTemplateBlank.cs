using Xunit;

// Struct vs Class — Value Types vs Reference Types
//
// Implement:
//   Point — a VALUE type (copies on assignment, not heap-allocated) with two int fields: X and Y.
//       Constructor sets X and Y.
//
//   Box — a REFERENCE type (heap-allocated, variables hold a reference) with one int property:
//       Value (readable and writable). Constructor sets Value.
//
//   Demos — static class:
//       StructsAreCopied(Point a, Point modifiedB) → bool
//           — demonstrates structs are copied; return true.
//       ClassesAreShared(Box original, Box alias) → bool
//           — demonstrates both variables point to the same object; return true.
//       IsValueType(Type t) → bool — true if t is a value type.
//       IsReferenceType(Type t) → bool — true if t is not a value type.

// Write your implementation below.
