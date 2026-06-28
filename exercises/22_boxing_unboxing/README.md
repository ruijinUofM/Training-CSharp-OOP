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

## Detecting boxing

Use a profiler, or write a benchmark. At IL level, boxing emits the `box` opcode.

## Required implementation

```csharp
public static class BoxingDemos
{
    // Box an int — return it as object
    public static object BoxInt(int value) => throw new NotImplementedException();

    // Unbox an object to int — may throw InvalidCastException
    public static int UnboxInt(object obj) => throw new NotImplementedException();

    // Box multiple ints into an ArrayList (pre-generics)
    public static System.Collections.ArrayList BoxMany(IEnumerable<int> values) => ...

    // No boxing: use List<int>
    public static List<int> NoBoxing(IEnumerable<int> values) => ...

    // Returns the type of the object inside a box
    public static Type GetBoxedType(object obj) => obj.GetType();

    // Check if an object is a boxed int
    public static bool IsBoxedInt(object obj) => obj is int;
}
```
