# 21. Struct vs Class — Value Types vs Reference Types

## Intent

Understand the fundamental distinction between **value types** (struct, enum, primitives) and **reference types** (class, interface, delegate, string). This is the single most important memory concept in C#.

## Stack vs Heap

| Value type (struct) | Reference type (class) |
|---------------------|------------------------|
| Stored **inline** where declared (stack for locals, inline in parent object) | Object body on **heap**; variable holds a pointer (reference) |
| Copied on assignment | Reference copied on assignment — two variables can point to the same object |
| No GC overhead | Managed by GC |
| Cannot be `null` (unless `T?`) | Can be `null` |
| Should be small and immutable | No size restriction |

## Assignment semantics

```csharp
// Value type — copy
Point a = new Point(1, 2);
Point b = a;   // b gets a copy
b.X = 99;
Console.WriteLine(a.X); // still 1

// Reference type — shared reference
var p = new Box(1);
var q = p;     // q and p point to the same object
q.Value = 99;
Console.WriteLine(p.Value); // 99!
```

## When to use struct

- Small (≤ 16 bytes recommended), semantically represents a value (e.g., `Point`, `Color`, `DateTime`).
- Frequently allocated in bulk (arrays of structs are contiguous in memory — cache-friendly).
- Should be **immutable** to avoid the "mutable struct gotcha" (modifying a copy without realizing it).

## Required implementation

```csharp
public struct Point
{
    public int X;
    public int Y;
    public Point(int x, int y) { X = x; Y = y; }
}

public class Box
{
    public int Value { get; set; }
    public Box(int value) { Value = value; }
}

public static class Demos
{
    public static bool StructsAreCopied(Point a, Point modifiedB) => ...
        // pass in a Point 'a', assign to b, mutate b, return (a.X == b.X) ? false : true
        // just return true (structs are always copied)

    public static bool ClassesAreShared(Box original, Box alias) => ...
        // pass two refs to same object, mutate via alias, check original — return true

    public static bool IsValueType(Type t) => t.IsValueType;
    public static bool IsReferenceType(Type t) => !t.IsValueType;
}
```
