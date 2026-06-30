# 23. `ref`, `out`, and `in` Parameters

## Intent

Understand how `ref`, `out`, and `in` allow methods to work with the caller's variable directly rather than with a copy — and when each modifier is appropriate.

## By value (default)

```csharp
void Double(int x) { x *= 2; }  // caller's x is unchanged
```

## `ref` — read and write the caller's variable

The caller must initialize the variable before passing it. The method may read and modify it.

```csharp
void Double(ref int x) { x *= 2; }
int n = 5;
Double(ref n);
Console.WriteLine(n); // 10
```

## `out` — write-only, caller doesn't need to initialize

The method **must** assign the parameter before returning. Classic use: `int.TryParse`.

```csharp
bool TryParse(string s, out int result) {
    // must set result before returning
    result = int.Parse(s);
    return true;
}
```

## `in` — read-only reference (C# 7.2+)

Passes a value type by reference to avoid copying without allowing mutation. Useful for large structs.

```csharp
void Print(in LargeStruct s) { Console.WriteLine(s.X); } // s cannot be mutated
```

## When to use each

| Modifier | Caller initializes? | Method writes? | Method reads? | Use case |
|----------|---------------------|---------------|---------------|----------|
| (none)   | must | no effect on caller | yes | default |
| `ref`    | must | yes | yes | swap, accumulate |
| `out`    | doesn't have to | must | not required | multi-return, TryParse pattern |
| `in`     | must | no | yes | large struct — avoid copy |

## Required implementation (all in static class ParameterDemos)

- `Swap(int a, int b)` — exchanges the caller's two int variables in place. (Both parameters must let the method write back to the caller's variables.)
- `TryDouble(string s, int result)` → bool — parses s as int; if successful, result = parsed * 2 and returns true; else result = 0 and returns false. (result is set by the method; caller does not need to initialize it.)
- `SumWithRef(int accumulator, int value)` → int — adds value to the caller's accumulator variable directly and returns the new total. (accumulator is both read and written through the caller's variable.)
- `ReadOnly(int value)` → int — returns value * 2; value is passed by reference but the method cannot modify it.
