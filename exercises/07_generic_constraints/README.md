# 07. Generic Constraints

## Feature

`where T : IComparable<T>`, `where T : class, new()`, `where T : struct` — type constraints that unlock capabilities inside generic methods/classes.

## Case study

A `Max<T>` method (requires `IComparable<T>`), a `Repository<T>` class (requires `class, new()`), and an `AreEqual<T>` method (requires `struct`).

## Required classes and behavior

- **Algorithms** — static class with generic helper methods.
  - `Max(a, b)` → T — returns whichever is greater; T must support comparison against itself.
  - `AreEqual(a, b)` → bool — returns `a.Equals(b)`; T must be a value type (not a reference type).

- **Repository** — a generic collection class.
  - T must be a reference type AND must have a parameterless constructor.
  - `Create()` → T — returns a new instance of T using its default constructor.
  - `Add(item)` — adds an item to the internal list.
  - `FindAll()` → `List<T>` — returns the stored items.
  - `Count` (int) — number of items stored.

## Things to watch for

- `where T : IComparable<T>` lets you call `a.CompareTo(b)` inside the method.
- `where T : class` restricts to reference types (classes, interfaces, not `int`, `bool`).
- `where T : new()` lets you call `new T()` inside the class without knowing the concrete type.
- `where T : struct` restricts to value types — `int`, `double`, custom structs. Useful for `AreEqual` where boxing/null behavior differs.
- Multiple constraints are ANDed: `where T : class, new()` means it must be BOTH a reference type AND have a parameterless constructor.
- `a.CompareTo(b) > 0` means `a > b`.
