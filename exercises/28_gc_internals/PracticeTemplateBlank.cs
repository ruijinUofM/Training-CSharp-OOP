using Xunit;

// GC Internals — Generations, LOH, WeakReference<T>
//
// .NET GC has 3 generations: Gen0 (short-lived, cheap), Gen1, Gen2 (full, expensive).
// Objects >= 85,000 bytes → Large Object Heap (LOH), collected only at Gen2.
// WeakReference<T> holds a reference that doesn't prevent GC collection.
//   TryGetTarget(out T?) → true if object still alive.
//
// Implement (all in static class GcDemos):
//   GetGeneration(object obj) → int — which GC generation the object currently lives in.
//   CollectAll() — trigger a full collection and wait for finalizers to complete.
//   TotalMemory(bool collect) → long — total bytes allocated on the managed heap.
//   IsAlive<T>(weak reference to T) → bool — T must be a reference type; returns true
//       if the referenced object has not been collected yet.
//   MakeWeak<T>(T obj) → weak reference to T — T must be a reference type; wraps obj
//       in a reference that does not prevent collection.
//   LohThresholdBytes — the byte size above which objects go to the LOH (85,000).

// Write your implementation below.
