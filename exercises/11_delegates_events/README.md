# 11. Delegates and Events

## Feature

Delegates and events — observable notifications, multicast subscribers, and null-conditional invocation.

## When to use it / When to avoid it

Events exist to decouple the code that *raises* a notification from the code(s) that *react* to it — the publisher doesn't need to know who's listening, or how many, or whether anyone is listening at all.

- **Use it when**: modeling in-process pub/sub — UI interactions, observable state changes, plugin/callback hooks — where zero, one, or many independent listeners might care.
- **Avoid it when**: the reaction is a mandatory part of the core control flow that must always happen — a direct method call is simpler and easier to trace than an event whose subscriber count and identity aren't visible at the call site. Also avoid events for cross-process/cross-service notification — that needs a message bus or queue, not an in-memory delegate.

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

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
class Publisher
{
    // standard .NET event shape: sender + EventArgs
    public event EventHandler? SomethingHappened;

    // a built-in generic delegate — no custom delegate type needed
    public event Action<int>? ValueChanged;

    public void DoThing()
    {
        // "?." = only invoke if there's at least one subscriber
        SomethingHappened?.Invoke(this, EventArgs.Empty);
        ValueChanged?.Invoke(42);
    }
}

// subscribing / unsubscribing from outside
var pub = new Publisher();
EventHandler handler = (sender, args) => Console.WriteLine("handled");
pub.SomethingHappened += handler;
pub.SomethingHappened -= handler;

pub.ValueChanged += newValue => Console.WriteLine(newValue);
```

</details>

## Things to watch for

- The standard .NET delegate shape for event handlers takes a sender (the object firing) and event data — look up `EventHandler` and `EventArgs`.
- Fire notifications safely using null-conditional invocation — this handles the case where no subscribers are attached.
- `+=` adds a subscriber, `-=` removes it. Multiple subscribers form a multicast delegate chain.
- For `CountChanged`, use a built-in generic delegate type that takes one parameter — no need to declare a custom delegate type.
- Events differ from plain public delegates: only the declaring class can invoke them; outside code can only add/remove subscribers.
