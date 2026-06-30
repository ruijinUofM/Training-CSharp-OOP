# 11. Delegates and Events

## Feature

`delegate` type, `event`, `EventHandler`, `Action<T>`, `Func<T>`, multicast delegates, null-conditional invocation.

## Case study

A `Button` with an `event EventHandler? Clicked` and a `Click()` method that fires it. A `Counter` with `event Action<int>? CountChanged` that fires with the new count on each `Increment()`.

## Required classes and behavior

- **Button**:
  - `Clicked` — a notification that fires when `Click()` is called. Subscribers receive the sender (the Button) and an EventArgs. Uses the standard .NET event handler delegate shape.
  - `Click()` — raises the Clicked notification to all subscribers.

- **Counter**:
  - `Count` (int) — readable from outside; only changeable from within the class.
  - `CountChanged` — a notification that fires after each `Increment()`; subscribers receive the new Count value as an int.
  - `Increment()` — increments Count by 1, then fires CountChanged with the new value.

Note: C# has a specific keyword for declaring observable notifications on a class. Callers subscribe with `+=` and unsubscribe with `-=`. Firing safely when no subscribers are attached requires a null-conditional call.

## Things to watch for

- `event EventHandler? Clicked` — `EventHandler` is `delegate void (object sender, EventArgs e)`. The `?` means the event may have no subscribers.
- Fire events with null-conditional: `Clicked?.Invoke(this, EventArgs.Empty);` — safe when no subscribers are attached.
- `+=` adds a subscriber, `-=` removes it. Multiple subscribers form a multicast delegate.
- `Action<int>` is a built-in delegate type equivalent to `delegate void (int value)`. No need to declare a custom delegate.
- Events differ from plain delegates: only the declaring class can invoke them; subscribers can only add/remove themselves.
