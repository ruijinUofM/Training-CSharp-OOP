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

## When to use it / When to avoid it

Understanding closures explains both the late-binding bug above and a subtler cost: every captured variable keeps its enclosing display class instance (and everything else it points to) alive for as long as the lambda is reachable.

- **Use closures freely when**: capturing small, short-lived local state that naturally needs to travel with the lambda — a multiplier, an accumulator, a loop-local copy.
- **Avoid it when**: capturing `this` or a large object just to reach one field (it keeps the entire object alive, which matters especially for event handlers or long-lived caches holding the lambda), or capturing a `for`-loop variable directly in a closure that outlives the iteration (the late-binding bug above) — copy it into a fresh local each iteration instead. Note `foreach` (C# 6+) doesn't have this bug since its loop variable is re-declared each iteration.

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
// closes over "factor" — the lambda keeps it alive as long as the Func exists
static Func<int, int> MakeMultiplier(int factor) => x => x * factor;

// BUG: every lambda captures the SAME loop variable "i"
static List<Func<int>> LateBuggy()
{
    var fns = new List<Func<int>>();
    for (int i = 0; i < 3; i++)
        fns.Add(() => i);          // all will return 3 once the loop finishes
    return fns;
}

// FIX: re-declare a fresh local inside the loop body — one per iteration
static List<Func<int>> LateFixed()
{
    var fns = new List<Func<int>>();
    for (int i = 0; i < 3; i++)
    {
        int captured = i;          // new closure variable each pass
        fns.Add(() => captured);
    }
    return fns;
}

// a closure that mutates its captured variable across calls (a stateful counter)
static Func<int> MakeCounter(int start = 0)
{
    int count = start;
    return () => ++count;
}

// composing two functions via nested lambdas
static Func<int, int> Compose(Func<int, int> f, Func<int, int> g) => x => f(g(x));
```

</details>

## Required implementation (all in static class LambdaDemos)

- `MakeMultiplier(int factor)` → (int → int) — returns a function that multiplies its argument by factor; closes over factor.
- `LateBuggy()` → list of (() → int) — 3 lambdas capturing the same for-loop counter; all return 3 after the loop (demonstrates the late-binding bug).
- `LateFixed()` → list of (() → int) — 3 lambdas each capturing their own copy; return 0, 1, 2 respectively (demonstrates the fix).
- `MakeCounter(int start = 0)` → (() → int) — each invocation increments and returns a shared counter starting at start.
- `Compose(f, g)` → (int → int) — returns a new function that applies g then f: `x → f(g(x))`.
