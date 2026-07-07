# 22. Boxing and Unboxing

## Intent

Understand boxing (value type → `object`), unboxing (object → value type), why it allocates heap memory, and how to avoid it with generics.

## What is boxing?

When a value type (struct, int, etc.) is assigned to an `object` reference (or an interface reference), the runtime wraps it in a heap-allocated object. This wrapper is called a **box**.

```csharp
int n = 42;
object obj = n;   // box: allocates a new heap object containing 42
int m = (int)obj; // unbox: copies the value out of the box
```

## Why does it matter?

- Every boxing operation allocates heap memory → GC pressure.
- In hot paths (tight loops, millions of iterations) this can be a significant cost.
- Pre-generics code (e.g., `ArrayList`) boxed everything. With `List<int>`, no boxing.

## When does boxing happen?

1. Assigning a value type to `object`.
2. Assigning a value type to an interface variable: `IComparable c = 42;` — boxing!
3. Passing a value type where `object` is expected (e.g., `string.Format("{0}", 42)`).
4. Calling `object` methods on a value type via an interface reference.

## When it's fine vs. when to avoid it

Boxing itself isn't a "feature" you opt into — it's a cost the runtime pays automatically whenever a value type needs to be treated as an `object`/interface reference. Knowing when that's happening is what lets you decide if it's acceptable.

- **Acceptable when**: it's occasional, outside hot paths — interop with legacy non-generic APIs (`ArrayList`, older reflection-based code), or a one-off conversion that isn't repeated millions of times.
- **Avoid it when**: you're in a hot loop or handling large collections of value types — reach for generics (`List<int>` instead of `ArrayList`) so the compiler never needs to box at all. If you see `object`, `IComparable` (non-generic), or a non-generic collection holding value types in a hot path, that's the signal to look for a generic alternative.

## Detecting boxing

Use a profiler, or write a benchmark. At IL level, boxing emits the `box` opcode.

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
int n = 42;
object boxed = n;          // box: value type copied onto the heap, wrapped as object
int back = (int)boxed;     // unbox: copy the value back out; throws InvalidCastException on mismatch

// boxing via a non-generic collection (each Add boxes the int)
var arrayList = new System.Collections.ArrayList();
arrayList.Add(42);

// no boxing — generics store the actual int, not a boxed wrapper
var list = new List<int> { 42 };

Type t = boxed.GetType();      // typeof(int)
bool isInt = boxed is int;     // pattern-match without unboxing
```

</details>

## Required implementation (all in static class BoxingDemos)

- `BoxInt(int value)` → object — returns the int as an object (triggers boxing).
- `UnboxInt(object obj)` → int — extracts the int from the boxed object (may throw `InvalidCastException` if wrong type).
- `BoxMany(IEnumerable<int> values)` → ArrayList — adds all ints to a non-generic collection (each insertion triggers boxing).
- `NoBoxing(IEnumerable<int> values)` → `List<int>` — same but using the generic collection (no boxing).
- `GetBoxedType(object obj)` → Type — the runtime type of the boxed value.
- `IsBoxedInt(object obj)` → bool — true if the object holds a boxed int.
