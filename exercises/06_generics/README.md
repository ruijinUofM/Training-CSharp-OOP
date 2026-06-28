# 06. Generics

## Feature

Generic classes (`class Foo<T>`), multiple type parameters (`Foo<T, U>`), type safety without boxing.

## Case study

A typed `Stack<T>` (LIFO) and a `Pair<T, U>` with a `Swap()` method.

## Required API

```csharp
class Stack<T>
{
    public void Push(T item)
    public T Pop()      // throws InvalidOperationException if empty
    public T Peek()     // throws InvalidOperationException if empty
    public int Count { get; }
    public bool IsEmpty { get; }
}

class Pair<T, U>
{
    public T First { get; }
    public U Second { get; }
    public Pair(T first, U second)
    public Pair<U, T> Swap()   // returns new Pair with First/Second swapped
}
```

## Things to watch for

- `class Stack<T>` declares a type parameter `T`. Inside the class, use `T` like any type.
- You cannot use `new T()` without the `new()` constraint, and you cannot call `T.SomeMethod()` without an interface constraint.
- `Stack<int>` and `Stack<string>` are distinct types at compile time — no casting needed.
- `Pair<U, T> Swap()` returns a different specialization. The return type changes the type parameters.
- `List<T>` internally; `InvalidOperationException` is the conventional exception for an empty stack operation.
