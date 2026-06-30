# 06. Generics

## Feature

Generic classes (`class Foo<T>`), multiple type parameters (`Foo<T, U>`), type safety without boxing.

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

## Things to watch for

- `class Stack<T>` declares a type parameter `T`. Inside the class, use `T` like any type.
- You cannot use `new T()` without the `new()` constraint, and you cannot call `T.SomeMethod()` without an interface constraint.
- `Stack<int>` and `Stack<string>` are distinct types at compile time — no casting needed.
- `Pair<U, T> Swap()` returns a different specialization. The return type changes the type parameters.
- `List<T>` internally; `InvalidOperationException` is the conventional exception for an empty stack operation.
