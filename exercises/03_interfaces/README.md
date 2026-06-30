# 03. Interfaces

## Feature

`interface`, implementing multiple interfaces, casting to interface types, default interface methods (C# 8+).

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

## Things to watch for

- A class can implement multiple interfaces (C# does not allow multiple class inheritance).
- Interfaces are pure contracts — no fields, no constructors, no state (without default implementations).
- You can cast a `Circle` to `IDrawable` or `IResizable` and call through the interface.
- C# 8+ allows default interface method implementations, but it's rarely used in practice — prefer abstract classes when you need shared logic.
- Explicit interface implementation (`void IDrawable.Draw() { ... }`) hides the method from the class's public surface; it's only callable when cast to the interface.
