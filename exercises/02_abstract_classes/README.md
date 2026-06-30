# 02. Abstract Classes

## Feature

`abstract class`, `abstract` methods (no body), `virtual` methods (optional override), cannot instantiate abstract classes.

## Case study

An `abstract class Shape` with `abstract double Area()`, `abstract double Perimeter()`, and a `virtual string Describe()` that returns `"I am a {GetType().Name} with area {Area():F2}"`. `Circle` (radius) and `Rectangle` (width, height) are concrete subclasses.

## Required classes and behavior

- **Shape** — base class; cannot be instantiated directly.
  - `Area()` → double — every concrete subclass must provide this.
  - `Perimeter()` → double — every concrete subclass must provide this.
  - `Describe()` → string — returns `"I am a {TypeName} with area {Area():F2}"`; subclasses may optionally override.

- **Circle : Shape** — concrete; takes a radius.
  - `Radius` (double) — read-only; set via constructor.
  - `Area()` — `Math.PI * Radius * Radius`.
  - `Perimeter()` — `2 * Math.PI * Radius`.

- **Rectangle : Shape** — concrete; takes width and height.
  - `Width`, `Height` (double) — read-only; set via constructor.
  - `Area()` — `Width * Height`.
  - `Perimeter()` — `2 * (Width + Height)`.

## Things to watch for

- `abstract` methods have no body (no `{ }`). They must be overridden in every concrete subclass.
- `abstract class` cannot be instantiated directly — `new Shape()` is a compile error.
- `GetType().Name` inside Describe() returns the runtime type name (`"Circle"`, `"Rectangle"`), not `"Shape"`.
- `virtual` (on Describe) provides a default implementation that subclasses may override but don't have to.
- `abstract` vs `interface`: abstract classes can have state (fields/properties) and non-abstract methods; C# allows only one base class.
