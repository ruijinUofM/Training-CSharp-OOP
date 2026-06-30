using Xunit;

// Boxing and Unboxing
//
// Boxing: int → object allocates a heap wrapper around the value.
// Unboxing: (int)obj copies the value back out.
// Generics (List<int>) avoid boxing; ArrayList boxes everything.
//
// Implement (all in static class BoxingDemos):
//   BoxInt(int value) → object — returns the int as an object (triggers boxing).
//   UnboxInt(object obj) → int — extracts the int from the boxed object
//       (throws if the object is not a boxed int).
//   BoxMany(IEnumerable<int> values) → ArrayList — adds all ints to a
//       non-generic collection (each insertion triggers boxing).
//   NoBoxing(IEnumerable<int> values) → List<int> — same but using the
//       generic collection (no boxing).
//   GetBoxedType(object obj) → Type — the runtime type of the boxed value.
//   IsBoxedInt(object obj) → bool — true if the object holds a boxed int.

// Write your implementation below.
