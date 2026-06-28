# 07. Generic Constraints

## Feature

`where T : IComparable<T>`, `where T : class, new()`, `where T : struct` — type constraints that unlock capabilities inside generic methods/classes.

## Case study

A `Max<T>` method (requires `IComparable<T>`), a `Repository<T>` class (requires `class, new()`), and an `AreEqual<T>` method (requires `struct`).

## Required API

```csharp
static class Algorithms
{
    public static T Max<T>(T a, T b) where T : IComparable<T>
    // returns whichever is greater

    public static bool AreEqual<T>(T a, T b) where T : struct
    // returns a.Equals(b)
}

class Repository<T> where T : class, new()
{
    private readonly List<T> _items = new();
    public T Create()          // returns new T()
    public void Add(T item)
    public List<T> FindAll()   // returns copy or same list
    public int Count { get; }
}
```

## Things to watch for

- `where T : IComparable<T>` lets you call `a.CompareTo(b)` inside the method.
- `where T : class` restricts to reference types (classes, interfaces, not `int`, `bool`).
- `where T : new()` lets you call `new T()` inside the class without knowing the concrete type.
- `where T : struct` restricts to value types — `int`, `double`, custom structs. Useful for `AreEqual` where boxing/null behavior differs.
- Multiple constraints are ANDed: `where T : class, new()` means it must be BOTH a reference type AND have a parameterless constructor.
- `a.CompareTo(b) > 0` means `a > b`.
