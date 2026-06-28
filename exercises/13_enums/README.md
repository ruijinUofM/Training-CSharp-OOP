# 13. Enums

## Feature

`enum`, `[Flags]` enum, extension methods on enums, `switch` expression on enums.

## Case study

`OrderStatus` enum (Pending, Processing, Shipped, Delivered, Cancelled) with extension methods `IsTerminal` and `CanTransitionTo`. `Permission` as a `[Flags]` enum (None=0, Read=1, Write=2, Execute=4).

## Required API

```csharp
enum OrderStatus { Pending, Processing, Shipped, Delivered, Cancelled }

static class OrderStatusExtensions
{
    public static bool IsTerminal(this OrderStatus s)
    // true for Delivered and Cancelled

    public static bool CanTransitionTo(this OrderStatus current, OrderStatus next)
    // Pending -> Processing
    // Processing -> Shipped
    // Shipped -> Delivered
    // anything (except Delivered/Cancelled) -> Cancelled
    // all other transitions: false
}

[Flags]
enum Permission { None = 0, Read = 1, Write = 2, Execute = 4 }
```

## Things to watch for

- Enums are just named integers under the hood; `(int)OrderStatus.Pending == 0`.
- Extension methods work on enum types the same way as on classes.
- `[Flags]` enables bitwise combination: `Permission.Read | Permission.Write` gives a value of 3.
- `HasFlag(Permission.Read)` checks if the Read bit is set.
- `switch` expression on an enum is exhaustive if you cover all cases or add a `_` wildcard.
- Terminal states: once an order is Delivered or Cancelled, no further transitions make sense.
- `is` pattern in switch: `OrderStatus.Delivered or OrderStatus.Cancelled => true`.
