# 26. String Internals

## Intent

Understand why strings in C# are **immutable reference types**, how **string interning** works, and why you should use `StringBuilder` for repeated concatenation.

## Strings are reference types

`string` is a class (heap-allocated), but it behaves like a value type because:
1. It's **immutable** — every operation creates a new string object.
2. `==` compares by **content**, not by reference (operator overloading).

## String interning

The CLR maintains a **string intern pool**: a dictionary of string literals. All identical string literals in your assembly are automatically interned and point to the same object.

```csharp
string a = "hello";
string b = "hello";
bool sameRef = ReferenceEquals(a, b); // true — both point to the intern pool

string c = new string("hello".ToCharArray()); // NOT interned by default
bool sameRef2 = ReferenceEquals(a, c); // false

c = string.Intern(c); // explicitly intern it
bool sameRef3 = ReferenceEquals(a, c); // true
```

## `String.IsInterned`

Returns the interned version if one exists, or `null`:
```csharp
string? interned = string.IsInterned("hello"); // returns "hello"
string? notInterned = string.IsInterned(new string('x', 100)); // null
```

## Concatenation and `StringBuilder`

Every `+` creates a new string object:
```csharp
string s = "";
for (int i = 0; i < 1000; i++) s += i; // 1000 allocations!

var sb = new StringBuilder();
for (int i = 0; i < 1000; i++) sb.Append(i);
string s = sb.ToString(); // 1 allocation
```

## Required implementation (all in static class StringInternals)

- `ContentEqual(string a, string b)` → bool — true if both strings have the same content.
- `ReferenceEqual(string a, string b)` → bool — true if both variables point to the same object.
- `InternString(string s)` → string — ensures s is in the intern pool and returns it.
- `IsInterned(string s)` → bool — true if s is already in the intern pool.
- `ConcatWithPlus(int n)` → string — concatenate `"0"` through `"{n-1}"` using `+` in a loop.
- `ConcatWithBuilder(int n)` → string — same but using the efficient mutable builder type.
