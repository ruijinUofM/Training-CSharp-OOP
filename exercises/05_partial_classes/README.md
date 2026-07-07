# 05. Partial Classes

## Feature

`partial class` — splitting a class across multiple files. Common in auto-generated code (WinForms designer, EF models, source generators).

## When to use it / When to avoid it

`partial` exists so that machine-generated code and hand-written code can occupy the same class without conflicting — the generator can freely rewrite its file, and your additions in the other file survive untouched.

- **Use it when**: a tool owns one file (a designer, an EF scaffolder, a source generator) and you need to add hand-written members to that same type without touching the generated file.
- **Avoid it when**: you're tempted to use it just to make one big hand-written class feel smaller by splitting it across files — that's a sign the class itself is doing too much and should be broken into smaller, separate classes (or composed from smaller pieces), not merely visually split.

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

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
// FileA.cs — e.g. auto-generated
namespace MyNamespace;

public partial class Thing
{
    public int Id { get; }
    public Thing(int id) { Id = id; }
}

// FileB.cs — your hand-written half
namespace MyNamespace;

public partial class Thing
{
    // same access modifier, same name, same namespace, both marked "partial"
    public List<string> Items { get; } = new();

    // can freely reference members declared in the OTHER file
    public string Summary() => $"Thing #{Id}: {Items.Count} item(s)";
}

// optional: a "hook" declared in one file, implemented (or left unimplemented) in the other
partial class Thing
{
    partial void OnChanged();
}
```

</details>

## Things to watch for

- Both `partial class` declarations must have the same access modifier, name, and be in the same namespace.
- The compiler treats them as one class — `Practice.cs` can reference `OrderId` and `CustomerName` even though they're defined in `GeneratedPart.cs`.
- `partial` is only about files — there's no runtime concept of "partial". The merged class is a single type.
- Common real-world pattern: an ORM or designer generates one file, developers extend in another. You never edit the generated file.
- `partial` methods are also a thing: the generated file declares a `partial void OnChange();` as a hook; the hand-written file may optionally implement it.
