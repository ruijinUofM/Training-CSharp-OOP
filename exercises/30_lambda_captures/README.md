# 30. Lambda Captures and Closure Classes

## Intent

Understand what the C# compiler generates when a lambda captures a variable — a **closure class** on the heap — and the classic late-binding bug.

## What the compiler generates

When a lambda captures a local variable, the compiler:
1. Creates a **display class** (a private nested class) with the captured variable as a field.
2. Allocates an instance of this class on the heap.
3. The lambda becomes a method on that class.

```csharp
// Your code:
int multiplier = 3;
Func<int, int> triple = x => x * multiplier;

// Compiler generates roughly:
// class <>c__DisplayClass {
//     public int multiplier;
//     public int <Main>b__0(int x) => x * multiplier;
// }
// var closure = new <>c__DisplayClass { multiplier = 3 };
// Func<int, int> triple = closure.<Main>b__0;
```

## The late-binding bug

The closure captures the **variable** (a reference to the closure field), not the **value**. If the variable changes after the lambda is created, the lambda sees the new value.

```csharp
// BUG: all lambdas share one 'i' variable
var fns = new List<Func<int>>();
for (int i = 0; i < 3; i++)
    fns.Add(() => i);
// After loop, i == 3
fns[0]()  // → 3 (NOT 0!)

// FIX: capture a copy by creating a new variable in each iteration
for (int i = 0; i < 3; i++) {
    int captured = i;   // new variable each iteration → new closure each iteration
    fns.Add(() => captured);
}
fns[0]() // → 0
```

Note: `foreach` in modern C# (6+) does **not** have this bug — the loop variable is re-declared each iteration.

## Required implementation

```csharp
public static class LambdaDemos
{
    public static Func<int, int> MakeMultiplier(int factor);
        // return x => x * factor;

    public static List<Func<int>> LateBuggy();
        // for loop capturing i → all return 3

    public static List<Func<int>> LateFixed();
        // for loop with captured copy → return 0, 1, 2

    public static Func<int> MakeCounter(int start = 0);
        // captures a mutable local; each call increments and returns it

    public static Func<int, int> Compose(Func<int, int> f, Func<int, int> g);
        // return x => f(g(x));
}
```
