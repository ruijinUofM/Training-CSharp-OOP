# 07. Generic Constraints

## Feature

Generic type constraints — restricting type parameters to unlock specific capabilities inside generic methods and classes.

## When to use it / When to avoid it

Constraints exist to trade a little bit of flexibility (which types can be plugged in) for capabilities you couldn't otherwise use on `T` — calling `CompareTo`, calling `new T()`, or restricting to value/reference types — all checked at compile time.

- **Use it when**: your generic code actually needs to call a specific method/operator on `T`, construct a new `T`, or must exclude value types (or reference types) because your logic depends on that distinction.
- **Avoid it when**: you're adding a constraint "just in case" it's useful later — every constraint narrows the set of types callers can pass in, so only constrain what the current implementation actually requires.

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

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
// "where T : IComparable<T>" — T must support CompareTo against itself
static class Algorithms
{
    public static T Max<T>(T a, T b) where T : IComparable<T>
        => a.CompareTo(b) >= 0 ? a : b;

    // "where T : struct" — restricts T to value types (int, double, custom structs)
    public static bool AreEqual<T>(T a, T b) where T : struct
        => a.Equals(b);
}

// "where T : class, new()" — T must be a reference type AND have a public
// parameterless constructor; multiple constraints are comma-separated and ANDed
class Repository<T> where T : class, new()
{
    public T Create() => new T();   // only legal because of the new() constraint
}

// other common constraints:
//   where T : SomeBaseClass       (T must derive from SomeBaseClass)
//   where T : ISomeInterface      (T must implement the interface)
//   where T : notnull             (T cannot be a nullable type)
//   where T : U                   (T must be U or derive from U)
```

</details>

## Things to watch for

- Constraining T to types that support comparison against themselves lets you call comparison methods on T values inside the method.
- Constraining T to reference types restricts it to classes and interfaces (not `int`, `bool`, or structs).
- Constraining T to have a parameterless constructor lets you call `new T()` inside the class without knowing the concrete type.
- Constraining T to value types restricts it to types like `int`, `double`, and custom structs — useful where boxing or null behavior differs.
- Multiple constraints are ANDed: T must satisfy ALL listed constraints simultaneously.
- `a.CompareTo(b) > 0` means `a > b`.
