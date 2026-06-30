# 14. Nullable Reference Types

## Feature

`string?` vs `string`, null-coalescing `??`, null-conditional `?.`, `required` keyword, `ArgumentNullException.ThrowIfNull`.

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

## Things to watch for

- `Nullable>enable</Nullable>` in the project file turns on nullable reference type analysis. Without it, `string` and `string?` are the same.
- `string` (non-nullable) means the compiler warns you if you assign `null` to it or dereference it without checking.
- `string?` (nullable) means null is intentional; you must check before dereferencing.
- `required` (C# 11) means object initializer must set this property — compiler error if omitted.
- `??` operator: `a ?? b` returns `a` if not null, otherwise `b`.
- `?.` operator: `obj?.Property` returns null instead of throwing NullReferenceException if `obj` is null.
- Chain them: `profile?.Name?.ToUpper() ?? "UNKNOWN"` — safe even if profile or Name is null.
