# 07. Generic Constraints

## Feature

Generic type constraints — restricting type parameters to unlock specific capabilities inside generic methods and classes.

## Case study

A `Max<T>` method (T must support comparison against itself), a `Repository<T>` class (T must be a reference type with a parameterless constructor), and an `AreEqual<T>` method (T must be a value type).

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

- Constraining T to types that support comparison against themselves lets you call comparison methods on T values inside the method.
- Constraining T to reference types restricts it to classes and interfaces (not `int`, `bool`, or structs).
- Constraining T to have a parameterless constructor lets you call `new T()` inside the class without knowing the concrete type.
- Constraining T to value types restricts it to types like `int`, `double`, and custom structs — useful where boxing or null behavior differs.
- Multiple constraints are ANDed: T must satisfy ALL listed constraints simultaneously.
- `a.CompareTo(b) > 0` means `a > b`.
