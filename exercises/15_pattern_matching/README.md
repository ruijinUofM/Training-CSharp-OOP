# 15. Pattern Matching

## Feature

`switch` expression, type patterns, positional patterns, `when` guards, relational patterns (`< 0`, `> 0 and < 10`).

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

## Things to watch for

- `switch` expression returns a value (no `break`, no `return`, use `=>`).
- Positional pattern `Circle(var r)` works because `record Circle(double Radius)` auto-generates a `Deconstruct(out double Radius)` method.
- `Rectangle(var w, var h)` binds both components.
- `_` is the discard/wildcard — matches anything and doesn't bind.
- Relational patterns: `> 0 and < 10` uses the `and` keyword (not `&&`).
- Heron's formula: `s = (a+b+c)/2.0; area = Math.Sqrt(s*(s-a)*(s-b)*(s-c));`
- Without the `abstract` keyword on `Shape`, the compiler can't prove the switch is exhaustive.
