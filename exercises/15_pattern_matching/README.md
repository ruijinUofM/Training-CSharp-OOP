# 15. Pattern Matching

## Feature

`switch` expression, type patterns, positional patterns, `when` guards, relational patterns (`< 0`, `> 0 and < 10`).

## When to use it / When to avoid it

Pattern matching exists to express "what shape is this data, and what should happen for each shape" declaratively — often with compiler-checked exhaustiveness — instead of nested `if`/`else`/casts.

- **Use it when**: dispatching over a closed set of cases (a sealed/abstract hierarchy of records, or ranges of values) where the compiler can help confirm you've covered everything.
- **Avoid it when**: the hierarchy is open-ended and new cases get added by code you don't control, or over time by many different developers — a central `switch` needs updating every time a new subtype appears, whereas a virtual/overridden method lets each new subtype bring its own behavior without touching shared code.

## Case study

Shape hierarchy (Circle, Rectangle, Triangle as abstract records) with an `Area(Shape)` function using positional patterns. A `Classify(int)` function using relational patterns.

## Required types and behavior

- **Shape** — base type; cannot be instantiated directly; uses value equality; supports deconstruction in pattern matching.
- **Circle : Shape** — one component: Radius (double).
- **Rectangle : Shape** — two components: Width, Height (double).
- **Triangle : Shape** — three components: A, B, C (double) — side lengths.

Note: use C#'s concise immutable data type syntax. The base Shape should not be directly instantiable.

- **ShapeMath** — static class:
  - `Area(Shape)` → double — dispatches on shape type using positional patterns:
    - Circle: `Math.PI * r * r`
    - Rectangle: `w * h`
    - Triangle: Heron's formula — `s=(a+b+c)/2; sqrt(s*(s-a)*(s-b)*(s-c))`
    - unknown: throw `ArgumentException`
  - `Classify(int)` → string — using relational patterns:
    - `< 0` → `"negative"`, `0` → `"zero"`, `1–9` → `"small"`, `>= 10` → `"large"`

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
// "abstract record" — base cannot be instantiated directly, subtypes get
// positional Deconstruct for free, which positional patterns rely on
abstract record Shape;
record Circle(double Radius) : Shape;
record Rectangle(double Width, double Height) : Shape;

static class ShapeMath
{
    public static double Area(Shape shape) => shape switch
    {
        // positional pattern — destructures via the record's auto-generated Deconstruct
        Circle(var r) => Math.PI * r * r,
        Rectangle(var w, var h) => w * h,
        _ => throw new ArgumentException("unknown shape"),
    };

    // relational patterns + "and" to combine them
    public static string Classify(int n) => n switch
    {
        < 0 => "negative",
        0 => "zero",
        > 0 and < 10 => "small",
        _ => "large",
    };

    // "when" guard — extra condition on top of a matched pattern
    public static string Describe(Shape shape) => shape switch
    {
        Circle(var r) when r > 100 => "huge circle",
        Circle => "circle",
        _ => "other",
    };
}
```

</details>

## Things to watch for

- `switch` expression returns a value (no `break`, no `return`, use `=>`).
- Positional pattern `Circle(var r)` works because `record Circle(double Radius)` auto-generates a `Deconstruct(out double Radius)` method.
- `Rectangle(var w, var h)` binds both components.
- `_` is the discard/wildcard — matches anything and doesn't bind.
- Relational patterns: `> 0 and < 10` uses the `and` keyword (not `&&`).
- Heron's formula: `s = (a+b+c)/2.0; area = Math.Sqrt(s*(s-a)*(s-b)*(s-c));`
- Without the `abstract` keyword on `Shape`, the compiler can't prove the switch is exhaustive.
