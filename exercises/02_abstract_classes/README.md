# 02. Abstract Classes

## Feature

Abstract base classes — classes that cannot be instantiated directly, methods with no implementation that concrete subclasses must provide, and optional methods with a default implementation.

## Case study

A `Shape` base class that cannot be instantiated directly. It declares `Area()` and `Perimeter()` that every concrete subclass must implement, plus a `Describe()` method with a default implementation that subclasses may optionally replace. `Circle` (radius) and `Rectangle` (width, height) are concrete subclasses.

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

- Methods with no body must be overridden in every concrete subclass; the class containing them cannot be instantiated.
- A class cannot be instantiated directly if it is declared with a specific C# keyword — `new Shape()` becomes a compile error.
- `GetType().Name` inside Describe() returns the runtime type name (`"Circle"`, `"Rectangle"`), not `"Shape"`.
- Methods with a default implementation that subclasses may optionally replace use a different keyword than those with no body at all.
- Abstract classes can have state (fields/properties) and non-abstract methods; C# allows only one base class.
