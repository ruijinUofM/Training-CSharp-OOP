# 13. Enums

## Feature

`enum`, `[Flags]` enum, extension methods on enums, `switch` expression on enums.

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

## Things to watch for

- Enums are just named integers under the hood; `(int)OrderStatus.Pending == 0`.
- Extension methods work on enum types the same way as on classes.
- `[Flags]` enables bitwise combination: `Permission.Read | Permission.Write` gives a value of 3.
- `HasFlag(Permission.Read)` checks if the Read bit is set.
- `switch` expression on an enum is exhaustive if you cover all cases or add a `_` wildcard.
- Terminal states: once an order is Delivered or Cancelled, no further transitions make sense.
- `is` pattern in switch: `OrderStatus.Delivered or OrderStatus.Cancelled => true`.
