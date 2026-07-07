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

## When to use it / When to avoid it

`readonly struct` exists to make the compiler *prove* a value type is immutable, which both prevents the mutable-struct gotcha above and removes the need for defensive copies when the struct is passed by `in`.

- **Use it when**: the struct is small, genuinely represents an immutable value (a coordinate, a color, a money amount), and especially when it's passed around frequently via `in` on a hot path — that's where skipping defensive copies actually pays off.
- **Avoid it when**: the type needs to mutate in place — that's most stateful, "changes over time" modeling, and belongs on a class (or a plain mutable struct used very carefully, if at all). Also don't bother with `in`/`readonly struct` for tiny structs (int-sized or smaller) — copying them is already as cheap as passing a reference, so the ceremony buys you nothing.

## Performance: `in` + `readonly struct`

Passing a large `readonly struct` via `in` is zero-copy and zero defensive-copy:
```csharp
void Process(in BigReadonlyStruct s) { ... }
```
Without `readonly`, the compiler inserts a defensive copy on each `in` parameter access, defeating the purpose.

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
// "readonly struct" — compiler enforces every field/auto-property is immutable
public readonly struct Vector2
{
    public double X { get; }
    public double Y { get; }

    public Vector2(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double Length => Math.Sqrt(X * X + Y * Y);

    // methods return a NEW instance instead of mutating "this"
    public Vector2 Add(Vector2 other) => new Vector2(X + other.X, Y + other.Y);
    public Vector2 Scale(double factor) => new Vector2(X * factor, Y * factor);

    public bool Equals(Vector2 other) => X == other.X && Y == other.Y;

    public static Vector2 Zero => new Vector2(0, 0);
}

// "in" + "readonly struct" together = zero-copy, no defensive copy needed
static void PrintLength(in Vector2 v) => Console.WriteLine(v.Length);
```

</details>

## Required implementation

Implement **Vector2** as a fully immutable value type. (Look up the C# keyword that enforces full immutability on a struct, preventing any field mutation.)

- `X`, `Y` (double) — set at construction; cannot be changed afterward.
- `Vector2(double x, double y)` — constructor.
- `Length` (double, computed) — `Math.Sqrt(X*X + Y*Y)`.
- `Add(Vector2 other)` → Vector2 — returns a new `Vector2(X+other.X, Y+other.Y)`; does NOT mutate this instance.
- `Scale(double factor)` → Vector2 — returns a new `Vector2(X*factor, Y*factor)`; does NOT mutate.
- `Equals(Vector2 other)` → bool — `X == other.X && Y == other.Y`.
- `Zero` (static) → Vector2 — returns `(0, 0)`.
