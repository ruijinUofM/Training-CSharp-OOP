using Xunit;

// GC Internals — Generations, LOH, WeakReference<T>
//
// .NET GC has 3 generations: Gen0 (short-lived, cheap), Gen1, Gen2 (full, expensive).
// Objects >= 85,000 bytes → Large Object Heap (LOH), collected only at Gen2.
// WeakReference<T> holds a reference that doesn't prevent GC collection.
//   TryGetTarget(out T?) → true if object still alive.
//
// Implement:
//   public static class GcDemos {
//       public static int GetGeneration(object obj);         // GC.GetGeneration(obj)
//       public static void CollectAll();
//           // GC.Collect(); GC.WaitForPendingFinalizers(); GC.Collect();
//       public static long TotalMemory(bool collect);        // GC.GetTotalMemory(collect)
//       public static bool IsAlive<T>(WeakReference<T> wr) where T : class;
//           // wr.TryGetTarget(out _)
//       public static WeakReference<T> MakeWeak<T>(T obj) where T : class;
//           // new WeakReference<T>(obj)
//       public static int LohThresholdBytes => 85_000;
//   }

// Write your implementation below.
