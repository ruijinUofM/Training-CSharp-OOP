# 11. Delegates and Events

## Feature

`delegate` type, `event`, `EventHandler`, `Action<T>`, `Func<T>`, multicast delegates, null-conditional invocation.

## Case study

A `Button` with an `event EventHandler? Clicked` and a `Click()` method that fires it. A `Counter` with `event Action<int>? CountChanged` that fires with the new count on each `Increment()`.

## Required API

```csharp
class Button
{
    public event EventHandler? Clicked;
    public void Click()   // raises Clicked
}

class Counter
{
    public int Count { get; private set; }
    public event Action<int>? CountChanged;
    public void Increment()   // Count++, then raises CountChanged with new Count
}
```

## Things to watch for

- `event EventHandler? Clicked` — `EventHandler` is `delegate void (object sender, EventArgs e)`. The `?` means the event may have no subscribers.
- Fire events with null-conditional: `Clicked?.Invoke(this, EventArgs.Empty);` — safe when no subscribers are attached.
- `+=` adds a subscriber, `-=` removes it. Multiple subscribers form a multicast delegate.
- `Action<int>` is a built-in delegate type equivalent to `delegate void (int value)`. No need to declare a custom delegate.
- Events differ from plain delegates: only the declaring class can invoke them; subscribers can only add/remove themselves.
