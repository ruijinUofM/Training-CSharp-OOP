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

## When to use it / When to avoid it

`Span<T>` exists to slice/parse memory without allocating a new array or string for every slice — it's a view, not a copy.

| Use case | Tool |
|----------|------|
| Synchronous slice/parse, hot path | `Span<T>` / `ReadOnlySpan<T>` |
| Async pipeline, store in field | `Memory<T>` / `ReadOnlyMemory<T>` |
| Stack-allocated temp buffer | `stackalloc` + `Span<T>` |
| Cross-version/interop (pre-.NET Core 2.1) | `ArraySegment<T>` |

- **Use it when**: you're parsing or slicing in a hot, synchronous path and want to avoid the allocations that `Substring`/array-slicing normally cost.
- **Avoid it when**: you need to store the view across an `await`, in a field, or in a captured closure — `Span<T>` is a stack-only `ref struct` and can't do that; reach for `Memory<T>` there instead. Also don't reach for `Span<T>` in ordinary, non-hot-path code where a plain substring/slice is clearer and the allocation genuinely doesn't matter.

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
static int Sum(ReadOnlySpan<int> span)
{
    int total = 0;
    foreach (int x in span) total += x;
    return total;
}

static ReadOnlySpan<int> Slice(int[] arr, int start, int length)
    => arr.AsSpan(start, length);          // view, no copy

static int ParseFirstInt(ReadOnlySpan<char> chars)
    => int.Parse(chars);                    // parses directly, no Substring allocation

static int StackAllocSum(int n)
{
    Span<int> buf = stackalloc int[n];      // stack, not heap — no GC pressure
    for (int i = 0; i < n; i++) buf[i] = i + 1;
    return Sum(buf);
}

// Memory<T> — the heap-storable, field-storable, async-safe cousin of Span<T>
static int MemorySum(Memory<int> mem) => Sum(mem.Span);
```

</details>

## Required implementation (all in static class SpanDemos)

- `Sum(read-only span of int)` → int — sums elements without allocating.
- `Slice(int[] arr, int start, int length)` → read-only span of int — a zero-copy view over the specified range (no new array).
- `ParseFirstInt(read-only span of char)` → int — parse an int without a string allocation.
- `StackAllocSum(int n)` → int — allocate n ints on the stack, fill with 1..n, return their sum (no heap allocation).
- `MemorySum(heap-compatible span wrapper of int)` → int — sum via the synchronous span view.

Note: look up `Span<T>`, `ReadOnlySpan<T>`, `Memory<T>`, and `stackalloc`.
