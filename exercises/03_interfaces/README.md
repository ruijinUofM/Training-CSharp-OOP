# 03. Interfaces

## Feature

`interface`, implementing multiple interfaces, casting to interface types, default interface methods (C# 8+).

## Case study

`IDrawable` (has `Draw()`) and `IResizable` (has `Resize(double factor)`). `Circle` implements both — it has a `Radius` property, `Draw()` prints to console, and `Resize` multiplies Radius by the factor. `Square` also implements both.

## Required API

```csharp
interface IDrawable
{
    void Draw();
}

interface IResizable
{
    void Resize(double factor);
}

class Circle : IDrawable, IResizable
{
    public double Radius { get; private set; }
    public Circle(double radius)
    public void Draw()              // Console.WriteLine($"Drawing circle r={Radius}");
    public void Resize(double factor)  // Radius *= factor;
}

class Square : IDrawable, IResizable
{
    public double Side { get; private set; }
    public Square(double side)
    public void Draw()              // Console.WriteLine($"Drawing square s={Side}");
    public void Resize(double factor)  // Side *= factor;
}
```

## Things to watch for

- A class can implement multiple interfaces (C# does not allow multiple class inheritance).
- Interfaces are pure contracts — no fields, no constructors, no state (without default implementations).
- You can cast a `Circle` to `IDrawable` or `IResizable` and call through the interface.
- C# 8+ allows default interface method implementations, but it's rarely used in practice — prefer abstract classes when you need shared logic.
- Explicit interface implementation (`void IDrawable.Draw() { ... }`) hides the method from the class's public surface; it's only callable when cast to the interface.
