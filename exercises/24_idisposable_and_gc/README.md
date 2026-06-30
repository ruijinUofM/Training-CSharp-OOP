# 24. `IDisposable`, `using`, and the GC

## Intent

Understand the difference between managed memory (GC handles it automatically) and unmanaged resources (file handles, network connections, native memory — you must release these explicitly). Learn the Dispose pattern and how it integrates with the GC.

## The problem

The GC manages heap memory. It does **not** close file handles, release network sockets, or free native buffers. If you forget to close these, you leak OS resources.

## `IDisposable`

```csharp
public interface IDisposable
{
    void Dispose();
}
```

Any class holding unmanaged resources implements `IDisposable.Dispose()` to release them deterministically.

## The `using` statement

`using` guarantees `Dispose()` is called even if an exception is thrown:

```csharp
using (var f = new FileStream("x", FileMode.Open))
{
    // ... f is disposed when the block exits (even on exception)
}
// C# 8+ can drop the braces: using var f = new FileStream(...);
```

## Finalizers (last resort)

A finalizer (`~MyClass()`) is called by the GC if `Dispose()` was never called. Problems:
- Non-deterministic: called whenever GC runs (could be seconds/minutes later, or never during testing).
- Keeps the object alive an **extra GC cycle** (put on finalization queue).
- `GC.SuppressFinalize(this)` in `Dispose()` skips the finalizer for properly disposed objects.

## The full Dispose pattern

```csharp
public class ManagedResource : IDisposable
{
    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Release managed resources (other IDisposables)
            }
            // Release unmanaged resources here
            _disposed = true;
        }
    }

    ~ManagedResource() => Dispose(false); // finalizer — safety net

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // we already cleaned up
    }
}
```

## Required implementation

- **DisposableLog** — fulfills the standard deterministic cleanup contract (IDisposable).
  - `IsDisposed` (bool) — readable from outside; only settable from within the class.
  - `Log` (static `List<string>`) — shared log of disposal events; the reference is read-only.
  - `Name` (string) — read-only; set in constructor.
  - `DisposableLog(string name)` — constructor.
  - `Dispose()` — sets IsDisposed to true; appends `"disposed:{Name}"` to Log.
  - `ResetLog()` — static; clears Log.

- **DisposeDemos** — static class:
  - `UseWithUsing(string name)` — creates a DisposableLog in a block that guarantees Dispose() is called on exit (even on exception).
  - `IsDisposedAfterUsing(string name)` → bool — demonstrates the object is disposed after the block ends; returns true.
