# 13. Enums

## Feature

`enum`, `[Flags]` enum, extension methods on enums, `switch` expression on enums.

## When to use it / When to avoid it

Enums exist to replace magic numbers/strings with a named, type-checked, closed set of options the compiler and IDE both understand — and `[Flags]` extends that to independent options that combine with bitwise OR.

- **Use it when**: the set of values is fixed and known at compile time, and either mutually exclusive (a status) or independently combinable (permissions/flags).
- **Avoid it when**: the set of options is open-ended, defined by data, or expected to grow at runtime/deployment time without a recompile (e.g. user-defined categories, feature flags coming from config) — a lookup table, string constants, or a small class hierarchy handles that better than an enum ever can.

## Case study

`OrderStatus` enum (Pending, Processing, Shipped, Delivered, Cancelled) with extension methods `IsTerminal` and `CanTransitionTo`. `Permission` as a `[Flags]` enum (None=0, Read=1, Write=2, Execute=4).

## Required types and behavior

- **OrderStatus** — a named, discrete set of states: Pending, Processing, Shipped, Delivered, Cancelled. (C# has a specific keyword for this.)

- **OrderStatusExtensions** — methods callable directly on OrderStatus values.
  - `IsTerminal(OrderStatus)` → bool — called as `s.IsTerminal()`; true for Delivered and Cancelled.
  - `CanTransitionTo(OrderStatus current, OrderStatus next)` → bool — called as `current.CanTransitionTo(next)`:
    - Pending → Processing
    - Processing → Shipped
    - Shipped → Delivered
    - anything non-terminal → Cancelled
    - terminal states: no valid transitions

- **Permission** — a set of bit-flag values that can be combined with bitwise OR.
  - Values: None=0, Read=1, Write=2, Execute=4.
  - Requires a specific attribute on the type to enable bitwise combination semantics.

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
enum Status { Pending, Active, Done, Cancelled }

static class StatusExtensions
{
    public static bool IsTerminal(this Status s)
        => s is Status.Done or Status.Cancelled;

    // tuple pattern switch on a pair of enum values
    public static bool CanTransitionTo(this Status current, Status next)
        => (current, next) switch
        {
            (Status.Pending, Status.Active) => true,
            (Status.Active, Status.Done) => true,
            (_, Status.Cancelled) => true,
            _ => false,
        };
}

// [Flags] — lets values be combined with bitwise OR
[Flags]
enum Access
{
    None = 0,
    Read = 1,
    Write = 2,
    Execute = 4,
}

Access combined = Access.Read | Access.Write;   // = 3
bool canRead = combined.HasFlag(Access.Read);   // true
```

</details>

## Things to watch for

- Enums are just named integers under the hood; `(int)OrderStatus.Pending == 0`.
- Extension methods work on enum types the same way as on classes.
- `[Flags]` enables bitwise combination: `Permission.Read | Permission.Write` gives a value of 3.
- `HasFlag(Permission.Read)` checks if the Read bit is set.
- `switch` expression on an enum is exhaustive if you cover all cases or add a `_` wildcard.
- Terminal states: once an order is Delivered or Cancelled, no further transitions make sense.
- `is` pattern in switch: `OrderStatus.Delivered or OrderStatus.Cancelled => true`.
