# 28. GC Internals — Generations, LOH, and `WeakReference<T>`

## Intent

Understand how .NET's generational garbage collector works, what the Large Object Heap is, and how `WeakReference<T>` lets you hold a reference without preventing collection.

## Generational GC

The .NET GC divides the heap into **three generations**:

| Generation | Contains | Collected |
|------------|----------|-----------|
| Gen 0 | Newly allocated objects | Most frequently (cheap) |
| Gen 1 | Survived one Gen 0 GC | Medium frequency |
| Gen 2 | Long-lived objects | Least frequently (expensive) |

Objects that survive a GC are **promoted** to the next generation. Gen 2 collection is a "full GC" — it's expensive, so the GC tries to avoid it.

## Rationale

Most objects die young (short-lived allocations in loops). Collecting only Gen 0 (cheap) handles the majority of garbage without touching long-lived objects.

## Large Object Heap (LOH)

Objects ≥ **85,000 bytes** go directly to the LOH (skipping Gen 0/1). The LOH is collected only during Gen 2 GCs and is **not compacted by default** (gaps accumulate). Large arrays, strings, etc. → LOH.

## `WeakReference<T>`

A weak reference allows you to hold a reference to an object without preventing it from being collected. Useful for caches.

```csharp
var cache = new WeakReference<byte[]>(new byte[1024]);
if (cache.TryGetTarget(out byte[]? data))
{
    // still alive — use data
}
else
{
    // collected — reload from source
}
```

## Required implementation

```csharp
public static class GcDemos
{
    public static int GetGeneration(object obj);         // GC.GetGeneration(obj)
    public static void CollectAll();                     // GC.Collect(); GC.WaitForPendingFinalizers();
    public static long TotalMemory(bool collect);        // GC.GetTotalMemory(collect)
    public static bool IsAlive<T>(WeakReference<T> wr) where T : class;
        // wr.TryGetTarget(out _)
    public static WeakReference<T> MakeWeak<T>(T obj) where T : class;
        // new WeakReference<T>(obj)
    public static int LohThresholdBytes => 85_000;
}
```
