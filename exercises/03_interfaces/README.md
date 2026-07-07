# 03. Interfaces

## Feature

`interface`, implementing multiple interfaces, casting to interface types, default interface methods (C# 8+).

## When to use it / When to avoid it

An interface exists to describe a *capability* ("can be drawn", "can be resized") that completely unrelated classes can fulfill, without forcing them into a shared class hierarchy — and a class can fulfill any number of them.

- **Use it when**: you need multiple, otherwise-unrelated types to be usable interchangeably through a shared contract (e.g. for polymorphism or testability — swapping in a fake implementation), or when a single class needs to satisfy several independent contracts at once.
- **Avoid it when**: you have real implementation logic to share between the implementers — duplicating that logic in every class that implements the interface is worse than an abstract class that provides it once. Default interface methods (C# 8+) exist but are mostly meant for evolving public APIs without breaking implementers, not as a general substitute for abstract classes.

## Case study

`IDrawable` (has `Draw()`) and `IResizable` (has `Resize(double factor)`). `Circle` implements both — it has a `Radius` property, `Draw()` prints to console, and `Resize` multiplies Radius by the factor. `Square` also implements both.

## Required classes and behavior

- **IDrawable** — contract with one method: `Draw()`.
- **IResizable** — contract with one method: `Resize(double factor)`.

- **Circle** — fulfills both IDrawable and IResizable.
  - `Radius` (double) — readable from outside; only changeable from within the class or via Resize.
  - `Circle(double radius)` — constructor.
  - `Draw()` — prints `"Drawing circle r={Radius}"`.
  - `Resize(double factor)` — multiplies Radius by factor.

- **Square** — fulfills both IDrawable and IResizable.
  - `Side` (double) — readable from outside; only changeable from within the class or via Resize.
  - `Square(double side)` — constructor.
  - `Draw()` — prints `"Drawing square s={Side}"`.
  - `Resize(double factor)` — multiplies Side by factor.

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
interface IFoo
{
    void DoFoo();
}

interface IBar
{
    void DoBar(double factor);
}

// a class can implement any number of interfaces, comma-separated
class Thing : IFoo, IBar
{
    public void DoFoo() => Console.WriteLine("foo");
    public void DoBar(double factor) { /* ... */ }
}

// usage: cast/assign to the interface type to call through the contract
IFoo asFoo = new Thing();
asFoo.DoFoo();

// explicit interface implementation (only reachable via the interface type)
class Other : IFoo
{
    void IFoo.DoFoo() => Console.WriteLine("hidden from Other's own surface");
}
```

</details>

## Things to watch for

- A class can implement multiple interfaces (C# does not allow multiple class inheritance).
- Interfaces are pure contracts — no fields, no constructors, no state (without default implementations).
- You can cast a `Circle` to `IDrawable` or `IResizable` and call through the interface.
- C# 8+ allows default interface method implementations, but it's rarely used in practice — prefer abstract classes when you need shared logic.
- Explicit interface implementation (`void IDrawable.Draw() { ... }`) hides the method from the class's public surface; it's only callable when cast to the interface.
