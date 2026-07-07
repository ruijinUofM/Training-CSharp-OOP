# 14. Nullable Reference Types

## Feature

`string?` vs `string`, null-coalescing `??`, null-conditional `?.`, `required` keyword, `ArgumentNullException.ThrowIfNull`.

## When to use it / When to avoid it

Nullable reference types exist to move "can this be null?" out of documentation/tribal knowledge and into the type system, so the compiler flags a missed null check as a warning instead of you finding out via a `NullReferenceException` in production.

- **Use it when**: always — turn it on for every new project, and be deliberate about which members are genuinely optional (`string?`) versus always required (`string`, or `required` for must-set-at-construction).
- **Avoid it when**: you're tempted to sprinkle the null-forgiving operator (`!`) everywhere just to silence warnings — that defeats the entire feature by re-hiding the risk it exists to surface. Also remember nullable reference types are a compile-time hint, not a runtime guarantee — they don't replace actually validating data that comes from outside the process (user input, deserialized JSON, etc.).

## Case study

`UserProfile` with a required `Name` and optional `Bio`. Helper functions `FindUser`, `GetUpperName` demonstrate null-safe patterns.

## Required classes and behavior

- **UserProfile**:
  - `Name` (string) — must be provided at construction; cannot be null; immutable after construction; compiler should enforce it's always set.
  - `Bio` (string or null) — optional; immutable after construction.
  - `GetDisplayName()` → string — returns Name.
  - `GetBio()` → string — returns Bio if set, otherwise `"No bio provided"`.
  - `GetBioLength()` → int — returns Bio's length, or 0 if Bio is null.

- **UserHelpers** — static helper methods:
  - `FindUser(List<UserProfile>, string name)` → UserProfile or null — finds the first profile matching name, or null if not found.
  - `GetUpperName(UserProfile or null)` → string — returns Name uppercased, or `"UNKNOWN"` if profile is null.

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
class Profile
{
    // "required" (C# 11) — object initializer MUST set this, or compile error
    public required string Name { get; init; }

    // "?" suffix — nullable; the compiler expects you to check before using it
    public string? Bio { get; init; }

    public string GetBio() => Bio ?? "No bio provided";      // ?? = fallback if null
    public int GetBioLength() => Bio?.Length ?? 0;            // ?. = safe-navigate, short-circuits to null
}

static class ProfileHelpers
{
    // "Profile?" return type signals the caller must handle a possible null
    public static Profile? Find(List<Profile> items, string name)
        => items.FirstOrDefault(p => p.Name == name);

    public static string GetUpperName(Profile? profile)
        => profile?.Name?.ToUpper() ?? "UNKNOWN";
}

// object initializer — compiler enforces Name is set because it's "required"
var p = new Profile { Name = "Alice" };
```

</details>

## Things to watch for

- `Nullable>enable</Nullable>` in the project file turns on nullable reference type analysis. Without it, `string` and `string?` are the same.
- `string` (non-nullable) means the compiler warns you if you assign `null` to it or dereference it without checking.
- `string?` (nullable) means null is intentional; you must check before dereferencing.
- `required` (C# 11) means object initializer must set this property — compiler error if omitted.
- `??` operator: `a ?? b` returns `a` if not null, otherwise `b`.
- `?.` operator: `obj?.Property` returns null instead of throwing NullReferenceException if `obj` is null.
- Chain them: `profile?.Name?.ToUpper() ?? "UNKNOWN"` — safe even if profile or Name is null.
