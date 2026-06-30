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

## Required implementation (all in static class GcDemos)

- `GetGeneration(object obj)` → int — which GC generation the object currently lives in.
- `CollectAll()` — trigger a full collection and wait for finalizers to complete.
- `TotalMemory(bool collect)` → long — total bytes allocated on the managed heap.
- `IsAlive<T>(weak reference to T)` → bool — T must be a reference type; returns true if the referenced object has not been collected yet.
- `MakeWeak<T>(T obj)` → weak reference to T — T must be a reference type; wraps obj in a reference that does not prevent collection.
- `LohThresholdBytes` — the size in bytes above which objects go to the LOH (85,000).
