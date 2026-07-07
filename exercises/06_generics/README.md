# 06. Generics

## Feature

Generic classes (`class Foo<T>`), multiple type parameters (`Foo<T, U>`), type safety without boxing.

## When to use it / When to avoid it

Generics exist so you can write one implementation of a container or algorithm that works for any type, safely, without casting, without boxing value types, and without duplicating code per type.

- **Use it when**: the logic is genuinely type-independent — a stack, a list, a repository — and you'd otherwise be tempted to write it once with `object` (losing type safety and paying boxing costs) or copy-paste it per concrete type.
- **Avoid it when**: the code only ever needs to work with one concrete type — adding a type parameter there is pure ceremony with no reuse benefit. Also avoid piling on many type parameters "for flexibility" if callers only ever use one or two combinations — it hurts readability more than it helps.

## Case study

A typed `Stack<T>` (LIFO) and a `Pair<T, U>` with a `Swap()` method.

## Required classes and behavior

- **Stack** — a generic LIFO collection typed over one type parameter.
  - `Push(item)` — adds an item to the top.
  - `Pop()` → item — removes and returns the top item; throws `InvalidOperationException` if empty.
  - `Peek()` → item — returns the top item without removing it; throws `InvalidOperationException` if empty.
  - `Count` (int) — number of items currently in the stack.
  - `IsEmpty` (bool) — true when Count == 0.

- **Pair** — holds two values of potentially different types (two type parameters).
  - `First` — the first value; read-only.
  - `Second` — the second value; read-only.
  - Constructor — takes first and second values.
  - `Swap()` → Pair — returns a new Pair with First and Second swapped (with the type parameters also swapped).

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
class Box<T>
{
    private readonly List<T> _items = new();

    public void Add(T item) => _items.Add(item);

    public T GetLast() => _items[^1];   // ^1 = "last element" index-from-end

    public int Count => _items.Count;
}

// two independent type parameters
class Pair<TFirst, TSecond>
{
    public TFirst First { get; }
    public TSecond Second { get; }

    public Pair(TFirst first, TSecond second)
    {
        First = first;
        Second = second;
    }

    // returning a re-specialized generic type with the parameters swapped
    public Pair<TSecond, TFirst> Swap() => new(Second, First);
}

// usage — no casting, distinct types at compile time
var box = new Box<int>();
var pair = new Pair<string, int>("age", 30);
```

</details>

## Things to watch for

- `class Stack<T>` declares a type parameter `T`. Inside the class, use `T` like any type.
- You cannot use `new T()` without the `new()` constraint, and you cannot call `T.SomeMethod()` without an interface constraint.
- `Stack<int>` and `Stack<string>` are distinct types at compile time — no casting needed.
- `Pair<U, T> Swap()` returns a different specialization. The return type changes the type parameters.
- `List<T>` internally; `InvalidOperationException` is the conventional exception for an empty stack operation.
