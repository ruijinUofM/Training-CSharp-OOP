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

- **Point** — a VALUE type (not a class) with two int fields: X and Y. Constructor sets X and Y.
- **Box** — a REFERENCE type with one int property: Value (readable and writable). Constructor sets Value.
- **Demos** — static class:
  - `StructsAreCopied(Point a, Point modifiedB)` → bool — demonstrates structs are copied; return true.
  - `ClassesAreShared(Box original, Box alias)` → bool — demonstrates both variables point to the same object; return true.
  - `IsValueType(Type t)` → bool — true if t is a value type.
  - `IsReferenceType(Type t)` → bool — true if t is not a value type.
