using Xunit;

// GC Internals — Generations, LOH, and Weak References
//
// Implement (all in static class GcDemos):
//   GetGeneration(object obj) → int — which GC generation the object currently lives in.
//   CollectAll() — trigger a full collection and wait for finalizers to complete.
//   TotalMemory(bool collect) → long — total bytes allocated on the managed heap.
//   IsAlive<T>(weak reference to T) → bool — T must be a reference type; returns true
//       if the referenced object has not been collected yet.
//   MakeWeak<T>(T obj) → weak reference to T — T must be a reference type; wraps obj
//       in a reference that does not prevent collection.
//   LohThresholdBytes — the byte size above which objects go to the Large Object Heap (85,000).
//
// Look up: how to hold a reference to an object without preventing the GC from collecting it.

// Write your implementation below.
