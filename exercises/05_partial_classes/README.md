# 05. Partial Classes

## Feature

`partial class` — splitting a class across multiple files. Common in auto-generated code (WinForms designer, EF models, source generators).

## Case study

`CustomerOrder` is split across two files:
- **`GeneratedPart.cs`** (already written, simulates auto-generated code) — contains `OrderId`, `CustomerName`, `CreatedAt`.
- **`Practice.cs`** (you write) — contains `Items`, `Total`, and `Summary()`.

Both files declare `public partial class CustomerOrder`. The compiler merges them.

## Required implementation

`GeneratedPart.cs` is already provided (don't modify it). It defines one half of `CustomerOrder` with `OrderId`, `CustomerName`, and `CreatedAt`.

You write `Practice.cs` — the second half of the same class:

- Declares the second half of `CustomerOrder` (must share the same class name, namespace, and use the keyword that enables split-file classes).
- `Items` (List&lt;string&gt;) — read-only reference; starts empty.
- `Total` (decimal, computed) — `Items.Count * 9.99m`.
- `Summary()` → string — `"Order #{OrderId} for {CustomerName}: {Items.Count} item(s)"`; you can reference `OrderId` and `CustomerName` from the other half.

## Things to watch for

- Both `partial class` declarations must have the same access modifier, name, and be in the same namespace.
- The compiler treats them as one class — `Practice.cs` can reference `OrderId` and `CustomerName` even though they're defined in `GeneratedPart.cs`.
- `partial` is only about files — there's no runtime concept of "partial". The merged class is a single type.
- Common real-world pattern: an ORM or designer generates one file, developers extend in another. You never edit the generated file.
- `partial` methods are also a thing: the generated file declares a `partial void OnChange();` as a hook; the hand-written file may optionally implement it.
