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

## When to use it / When to avoid it

The value-type/reference-type split exists so you can choose, per type, whether copying should mean "an independent value" (struct) or "another handle to the same object" (class) — and structs additionally avoid GC overhead by living inline instead of on the heap.

- **Use struct when**: it's small (≤ 16 bytes recommended), semantically represents a value (e.g., `Point`, `Color`, `DateTime`), is frequently allocated in bulk (arrays of structs are contiguous in memory — cache-friendly), and can be made **immutable** to avoid the "mutable struct gotcha" (modifying a copy without realizing it).
- **Avoid struct when**: the type is large, needs to mutate in place and be observed by multiple holders (shared, changeable state), needs reference semantics (`null`, identity, aliasing), or participates in inheritance/polymorphism — classes are the right fit for all of those, and forcing a large or mutable type into a struct trades one set of bugs (GC pressure) for another (accidental copies, defensive-copy overhead).

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
// "struct" — value type; fields, no inheritance from other structs/classes
public struct Coord
{
    public int X;
    public int Y;
    public Coord(int x, int y) { X = x; Y = y; }
}

// "class" — reference type
public class Wrapper
{
    public int Value { get; set; }
    public Wrapper(int value) { Value = value; }
}

Coord a = new Coord(1, 2);
Coord b = a;      // copy — mutating b does NOT affect a
b.X = 99;

Wrapper w1 = new Wrapper(1);
Wrapper w2 = w1;  // same reference — mutating w2 DOES affect w1
w2.Value = 99;

// reflection checks
bool valueType = typeof(Coord).IsValueType;      // true
bool refType = !typeof(Wrapper).IsValueType;     // true
```

</details>

## Required implementation

- **Point** — a VALUE type (not a class) with two int fields: X and Y. Constructor sets X and Y.
- **Box** — a REFERENCE type with one int property: Value (readable and writable). Constructor sets Value.
- **Demos** — static class:
  - `StructsAreCopied(Point a, Point modifiedB)` → bool — demonstrates structs are copied; return true.
  - `ClassesAreShared(Box original, Box alias)` → bool — demonstrates both variables point to the same object; return true.
  - `IsValueType(Type t)` → bool — true if t is a value type.
  - `IsReferenceType(Type t)` → bool — true if t is not a value type.
