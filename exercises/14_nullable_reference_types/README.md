# 14. Nullable Reference Types

## Feature

`string?` vs `string`, null-coalescing `??`, null-conditional `?.`, `required` keyword, `ArgumentNullException.ThrowIfNull`.

## Case study

`UserProfile` with a required `Name` and optional `Bio`. Helper functions `FindUser`, `GetUpperName` demonstrate null-safe patterns.

## Required API

```csharp
class UserProfile
{
    public required string Name { get; init; }
    public string? Bio { get; init; }
    public string GetDisplayName() => Name;
    public string GetBio()        => Bio ?? "No bio provided";
    public int GetBioLength()     => Bio?.Length ?? 0;
}

static class UserHelpers
{
    public static UserProfile? FindUser(List<UserProfile> users, string name)
    // returns first match or null

    public static string GetUpperName(UserProfile? profile)
    // profile?.Name?.ToUpper() ?? "UNKNOWN"
}
```

## Things to watch for

- `Nullable>enable</Nullable>` in the project file turns on nullable reference type analysis. Without it, `string` and `string?` are the same.
- `string` (non-nullable) means the compiler warns you if you assign `null` to it or dereference it without checking.
- `string?` (nullable) means null is intentional; you must check before dereferencing.
- `required` (C# 11) means object initializer must set this property — compiler error if omitted.
- `??` operator: `a ?? b` returns `a` if not null, otherwise `b`.
- `?.` operator: `obj?.Property` returns null instead of throwing NullReferenceException if `obj` is null.
- Chain them: `profile?.Name?.ToUpper() ?? "UNKNOWN"` — safe even if profile or Name is null.
