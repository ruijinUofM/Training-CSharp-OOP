# 02. Abstract Classes

## Feature

Abstract base classes — classes that cannot be instantiated directly, methods with no implementation that concrete subclasses must provide, and optional methods with a default implementation.

## When to use it / When to avoid it

An abstract class exists for the case where subclasses are the same *kind* of thing, share real implementation, but also each must supply a piece that only they know how to do (e.g. every `Shape` can `Describe()` itself the same way, but only `Circle` knows its own `Area()`).

- **Use it when**: you have common state or logic to share across subclasses AND you want to force every subclass to implement specific members, and instantiating the base type directly wouldn't make sense (there's no such thing as a bare "Shape").
- **Avoid it when**: unrelated classes only need to agree on a contract with no shared code to reuse — an `interface` is the better fit there, and it doesn't spend your one allowed base class. Also avoid it if you find yourself wanting more than one "abstract base" for a type — C# only allows single inheritance, so a rigid abstract-class hierarchy can back you into a corner that composition or interfaces would have avoided.

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

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
abstract class Base
{
    // no body, no implementation — every concrete subclass MUST override this
    public abstract double DoThing();

    // has a body — subclasses MAY override it, but don't have to
    public virtual string Describe() => $"I am a {GetType().Name} doing {DoThing():F2}";
}

// "abstract class Base" itself cannot be instantiated: new Base() is a compile error

class Concrete : Base
{
    public double Value { get; }
    public Concrete(double value) { Value = value; }

    // required — the class won't compile without this
    public override double DoThing() => Value * 2;

    // optional — inherits Base.Describe() if omitted
}
```

</details>

## Things to watch for

- Methods with no body must be overridden in every concrete subclass; the class containing them cannot be instantiated.
- A class cannot be instantiated directly if it is declared with a specific C# keyword — `new Shape()` becomes a compile error.
- `GetType().Name` inside Describe() returns the runtime type name (`"Circle"`, `"Rectangle"`), not `"Shape"`.
- Methods with a default implementation that subclasses may optionally replace use a different keyword than those with no body at all.
- Abstract classes can have state (fields/properties) and non-abstract methods; C# allows only one base class.
