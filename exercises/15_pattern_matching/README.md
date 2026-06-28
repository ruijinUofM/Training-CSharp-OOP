# 15. Pattern Matching

## Feature

`switch` expression, type patterns, positional patterns, `when` guards, relational patterns (`< 0`, `> 0 and < 10`).

## Case study

Shape hierarchy (Circle, Rectangle, Triangle as abstract records) with an `Area(Shape)` function using positional patterns. A `Classify(int)` function using relational patterns.

## Required API

```csharp
abstract record Shape;
record Circle(double Radius) : Shape;
record Rectangle(double Width, double Height) : Shape;
record Triangle(double A, double B, double C) : Shape;

static class ShapeMath
{
    public static double Area(Shape shape)
    // Circle(r)     => Math.PI * r * r
    // Rectangle(w,h) => w * h
    // Triangle      => Heron's formula: s=(a+b+c)/2, sqrt(s*(s-a)*(s-b)*(s-c))
    // _             => throw new ArgumentException("Unknown shape")

    public static string Classify(int n)
    // < 0   => "negative"
    // 0     => "zero"
    // 1..9  => "small"
    // >= 10 => "large"
}
```

## Things to watch for

- `switch` expression returns a value (no `break`, no `return`, use `=>`).
- Positional pattern `Circle(var r)` works because `record Circle(double Radius)` auto-generates a `Deconstruct(out double Radius)` method.
- `Rectangle(var w, var h)` binds both components.
- `_` is the discard/wildcard — matches anything and doesn't bind.
- Relational patterns: `> 0 and < 10` uses the `and` keyword (not `&&`).
- Heron's formula: `s = (a+b+c)/2.0; area = Math.Sqrt(s*(s-a)*(s-b)*(s-c));`
- Without the `abstract` keyword on `Shape`, the compiler can't prove the switch is exhaustive.
