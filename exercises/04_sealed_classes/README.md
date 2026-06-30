# 04. Sealed Classes

## Feature

`sealed class` (cannot be subclassed), `sealed override` (stops a specific virtual chain), when and why to seal.

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

## Things to watch for

- `sealed class` cannot be used as a base class. Any attempt to inherit from it is a compile-time error.
- `sealed` on a class is a promise to the compiler (enables some JIT optimizations — virtual dispatch becomes direct call).
- `sealed override` on a specific method lets a non-sealed class stop a particular override chain: `public sealed override void Log(...) { }` in `ConsoleLogger` would prevent further override of `Log` in subclasses of `ConsoleLogger`, while the class itself is still extensible.
- Common use: `string`, `decimal`, most framework types are sealed.
- Reflection check: `typeof(FileLogger).IsSealed`.
