# 11. Delegates and Events

## Feature

Delegates and events — observable notifications, multicast subscribers, and null-conditional invocation.

## Case study

A `Button` that fires a notification when `Click()` is called — subscribers receive the Button and an EventArgs. A `Counter` that fires a notification after each `Increment()` — subscribers receive the new count as an int.

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

- The standard .NET delegate shape for event handlers takes a sender (the object firing) and event data — look up `EventHandler` and `EventArgs`.
- Fire notifications safely using null-conditional invocation — this handles the case where no subscribers are attached.
- `+=` adds a subscriber, `-=` removes it. Multiple subscribers form a multicast delegate chain.
- For `CountChanged`, use a built-in generic delegate type that takes one parameter — no need to declare a custom delegate type.
- Events differ from plain public delegates: only the declaring class can invoke them; outside code can only add/remove subscribers.
