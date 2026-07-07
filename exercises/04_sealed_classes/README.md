# 04. Sealed Classes

## Feature

`sealed class` (cannot be subclassed), `sealed override` (stops a specific virtual chain), when and why to seal.

## When to use it / When to avoid it

Sealing exists to make a deliberate design decision — "this class is finished, don't extend it" — explicit and compiler-enforced, protecting invariants that a subclass could otherwise break, and occasionally unlocking small performance wins (devirtualization).

- **Use it when**: a class is a concrete "leaf" not designed as an extension point (e.g. a specific `FileLogger` implementation), when allowing subclasses could silently violate the class's invariants, or when you're authoring a library and don't want to commit to supporting arbitrary subclassing forever.
- **Avoid it when**: the class is explicitly meant to be extended (a base class in a hierarchy you designed for that purpose), or you're sealing reflexively "by default" without a specific reason — that just removes flexibility other code might legitimately need later.

## Case study

An `abstract class Logger` with `abstract void Log(string message)`. `ConsoleLogger : Logger` (not sealed — could be subclassed). `FileLogger : Logger` is `sealed` — nothing can inherit from it. The test verifies via reflection that `FileLogger` is sealed and `ConsoleLogger` is not.

## Required classes and behavior

- **Logger** — base class; cannot be instantiated directly.
  - `LastMessage` (string) — stores the last logged message; settable from this class and subclasses only; defaults to `""`.
  - `Log(string message)` — every concrete subclass must provide its own implementation.

- **ConsoleLogger : Logger** — NOT restricted from being subclassed further.
  - `Log(string message)` — sets LastMessage; prints to console.

- **FileLogger : Logger** — CANNOT be subclassed; no further inheritance allowed.
  - `FilePath` (string) — read-only; set via constructor.
  - `FileLogger(string filePath)` — constructor.
  - `Log(string message)` — sets LastMessage (simulates file write).

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
abstract class Base
{
    public abstract void DoThing();
}

// no "sealed" here — this class CAN still be inherited from
class Extendable : Base
{
    public override void DoThing() { }
}

// "sealed" on the class — nothing can inherit from this, ever
sealed class Final : Base
{
    public override void DoThing() { }
}

// class Nope : Final { }   // <- compile error: cannot derive from sealed type

// "sealed override" on ONE method inside a still-extendable class:
// blocks further overriding of just that method in subclasses
class PartlyLocked : Base
{
    public sealed override void DoThing() { }
}

// reflection check used by tests:
bool isSealed = typeof(Final).IsSealed;
```

</details>

## Things to watch for

- `sealed class` cannot be used as a base class. Any attempt to inherit from it is a compile-time error.
- `sealed` on a class is a promise to the compiler (enables some JIT optimizations — virtual dispatch becomes direct call).
- `sealed override` on a specific method lets a non-sealed class stop a particular override chain: `public sealed override void Log(...) { }` in `ConsoleLogger` would prevent further override of `Log` in subclasses of `ConsoleLogger`, while the class itself is still extensible.
- Common use: `string`, `decimal`, most framework types are sealed.
- Reflection check: `typeof(FileLogger).IsSealed`.
