# 27. `Span<T>` and `Memory<T>`

## Intent

Understand `Span<T>` — a zero-allocation, bounds-checked view over a contiguous region of memory — and when to use it instead of array slices, string substrings, or `ArraySegment`.

## The problem with slices

```csharp
int[] arr = { 1, 2, 3, 4, 5 };
int[] slice = arr[1..3]; // allocates a NEW array
string s = "Hello World";
string sub = s.Substring(6, 5); // allocates a NEW string
```

## `Span<T>` — a stack-only view

`Span<T>` is a `ref struct` (stack-only). It holds a pointer + length. No heap allocation.

```csharp
int[] arr = { 1, 2, 3, 4, 5 };
Span<int> span = arr;              // view over all elements
Span<int> slice = arr.AsSpan(1, 3); // view over elements 1,2,3 — no copy

ReadOnlySpan<char> str = "Hello World".AsSpan(6, 5); // no copy!
```

## `Span<T>` from `stackalloc`

```csharp
Span<int> buffer = stackalloc int[8]; // 8 ints on the stack, no GC
buffer[0] = 42;
```

## `Memory<T>` — for async

`Span<T>` cannot be stored in fields (it's stack-only). `Memory<T>` is the heap-compatible cousin:
- Can be stored in fields, captured in closures, passed to `async` methods.
- Call `.Span` to get a `Span<T>` when you need to do the actual work synchronously.

## When to use

| Use case | Tool |
|----------|------|
| Synchronous slice/parse, hot path | `Span<T>` / `ReadOnlySpan<T>` |
| Async pipeline, store in field | `Memory<T>` / `ReadOnlyMemory<T>` |
| Stack-allocated temp buffer | `stackalloc` + `Span<T>` |
| Cross-version/interop (pre-.NET Core 2.1) | `ArraySegment<T>` |

## Required implementation

```csharp
public static class SpanDemos
{
    public static int Sum(ReadOnlySpan<int> span);
        // sum elements without allocating

    public static ReadOnlySpan<int> Slice(int[] arr, int start, int length);
        // return arr.AsSpan(start, length)

    public static int ParseFirstInt(ReadOnlySpan<char> chars);
        // int.Parse(chars) — no string allocation

    public static int StackAllocSum(int n);
        // stackalloc int[n], fill with 1..n, return sum

    public static int MemorySum(Memory<int> mem);
        // sum via mem.Span
}
```
