# 05. Partial Classes

## Feature

`partial class` — splitting a class across multiple files. Common in auto-generated code (WinForms designer, EF models, source generators).

## Case study

`CustomerOrder` is split across two files:
- **`GeneratedPart.cs`** (already written, simulates auto-generated code) — contains `OrderId`, `CustomerName`, `CreatedAt`.
- **`Practice.cs`** (you write) — contains `Items`, `Total`, and `Summary()`.

Both files declare `public partial class CustomerOrder`. The compiler merges them.

## Required API

You only write `Practice.cs`. `GeneratedPart.cs` is already provided:

```csharp
// GeneratedPart.cs (already done — don't modify)
public partial class CustomerOrder
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; } = "";
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
}

// Practice.cs (you implement)
public partial class CustomerOrder
{
    public List<string> Items { get; } = new();
    public decimal Total => Items.Count * 9.99m;
    public string Summary()   // "Order #{OrderId} for {CustomerName}: {Items.Count} item(s)"
}
```

## Things to watch for

- Both `partial class` declarations must have the same access modifier, name, and be in the same namespace.
- The compiler treats them as one class — `Practice.cs` can reference `OrderId` and `CustomerName` even though they're defined in `GeneratedPart.cs`.
- `partial` is only about files — there's no runtime concept of "partial". The merged class is a single type.
- Common real-world pattern: an ORM or designer generates one file, developers extend in another. You never edit the generated file.
- `partial` methods are also a thing: the generated file declares a `partial void OnChange();` as a hook; the hand-written file may optionally implement it.
