# 25. `readonly struct` and the Mutable Struct Gotcha

## Intent

Understand why mutable structs are dangerous, what `readonly struct` guarantees, and why `in` parameters and `readonly struct` work best together.

## The mutable struct gotcha

```csharp
struct Counter { public int Value; public void Increment() => Value++; }

Counter c = new Counter();
c.Increment(); // works: c is a variable, can be modified

var list = new List<Counter> { new Counter() };
list[0].Increment(); // COMPILE ERROR in newer C#; historically a SILENT BUG
// list[0] returns a COPY — you increment the copy, not the stored element
```

## `readonly struct` (C# 7.2+)

Declaring a struct `readonly` makes the compiler enforce immutability:
- All fields must be `readonly`.
- All auto-properties are implicitly `readonly`.
- Calling a non-readonly method on a `readonly struct` causes a **defensive copy** — the compiler copies the struct to call the method (because it can't guarantee the method won't mutate `this`).

```csharp
public readonly struct Point
{
    public int X { get; init; }
    public int Y { get; init; }
    public double Distance => Math.Sqrt(X * X + Y * Y);
    public Point Translate(int dx, int dy) => new Point { X = X + dx, Y = Y + dy };
}
```

## Performance: `in` + `readonly struct`

Passing a large `readonly struct` via `in` is zero-copy and zero defensive-copy:
```csharp
void Process(in BigReadonlyStruct s) { ... }
```
Without `readonly`, the compiler inserts a defensive copy on each `in` parameter access, defeating the purpose.

## Required implementation

Implement **Vector2** as a fully immutable value type. (Look up the C# keyword that enforces full immutability on a struct, preventing any field mutation.)

- `X`, `Y` (double) — set at construction; cannot be changed afterward.
- `Vector2(double x, double y)` — constructor.
- `Length` (double, computed) — `Math.Sqrt(X*X + Y*Y)`.
- `Add(Vector2 other)` → Vector2 — returns a new `Vector2(X+other.X, Y+other.Y)`; does NOT mutate this instance.
- `Scale(double factor)` → Vector2 — returns a new `Vector2(X*factor, Y*factor)`; does NOT mutate.
- `Equals(Vector2 other)` → bool — `X == other.X && Y == other.Y`.
- `Zero` (static) → Vector2 — returns `(0, 0)`.
