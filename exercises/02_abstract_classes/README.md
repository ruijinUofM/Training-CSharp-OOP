# 02. Abstract Classes

## Feature

`abstract class`, `abstract` methods (no body), `virtual` methods (optional override), cannot instantiate abstract classes.

## Case study

An `abstract class Shape` with `abstract double Area()`, `abstract double Perimeter()`, and a `virtual string Describe()` that returns `"I am a {GetType().Name} with area {Area():F2}"`. `Circle` (radius) and `Rectangle` (width, height) are concrete subclasses.

## Required API

```csharp
abstract class Shape
{
    public abstract double Area();
    public abstract double Perimeter();
    public virtual string Describe() => $"I am a {GetType().Name} with area {Area():F2}";
}

class Circle : Shape
{
    public double Radius { get; }
    public Circle(double radius)
    public override double Area()      // Math.PI * Radius * Radius
    public override double Perimeter() // 2 * Math.PI * Radius
}

class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }
    public Rectangle(double width, double height)
    public override double Area()      // Width * Height
    public override double Perimeter() // 2 * (Width + Height)
}
```

## Things to watch for

- `abstract` methods have no body (no `{ }`). They must be overridden in every concrete subclass.
- `abstract class` cannot be instantiated directly — `new Shape()` is a compile error.
- `GetType().Name` inside Describe() returns the runtime type name (`"Circle"`, `"Rectangle"`), not `"Shape"`.
- `virtual` (on Describe) provides a default implementation that subclasses may override but don't have to.
- `abstract` vs `interface`: abstract classes can have state (fields/properties) and non-abstract methods; C# allows only one base class.
