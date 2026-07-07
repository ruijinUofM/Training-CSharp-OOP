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

## When to use it / When to avoid it

This is mostly mental-model knowledge — you don't "opt into" string immutability or interning, but knowing how they work should guide two concrete decisions in your own code.

- **Use `StringBuilder` when**: you're concatenating in a loop or building up a string from many pieces — each `+` on immutable strings allocates a brand-new string, so a loop of `s += x` is O(n²) allocations, while `StringBuilder` mutates one buffer.
- **Avoid manually interning strings when**: you don't have a specific, measured reason to — interning has its own cost (a lookup, plus the interned string lives for the entire process lifetime, so it can't be garbage collected). Literal strings are interned automatically; only reach for `string.Intern` for long-lived, frequently-repeated runtime strings where you've confirmed deduplication is worth it.

## Concatenation and `StringBuilder`

Every `+` creates a new string object:
```csharp
string s = "";
for (int i = 0; i < 1000; i++) s += i; // 1000 allocations!

var sb = new StringBuilder();
for (int i = 0; i < 1000; i++) sb.Append(i);
string s = sb.ToString(); // 1 allocation
```

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
bool contentEqual = ("hi" == "h" + "i");                  // true — content comparison
bool sameObject = ReferenceEquals("hi", "h" + "i");        // depends on interning

string interned = string.Intern(someRuntimeString);         // force into the intern pool
bool alreadyInterned = string.IsInterned(someString) != null;

// O(n^2)-ish: each "+=" allocates a brand-new string
string s = "";
for (int i = 0; i < n; i++) s += i;

// O(n): one growable buffer, one final allocation
var sb = new System.Text.StringBuilder();
for (int i = 0; i < n; i++) sb.Append(i);
string result = sb.ToString();
```

</details>

## Required implementation (all in static class StringInternals)

- `ContentEqual(string a, string b)` → bool — true if both strings have the same content.
- `ReferenceEqual(string a, string b)` → bool — true if both variables point to the same object.
- `InternString(string s)` → string — ensures s is in the intern pool and returns it.
- `IsInterned(string s)` → bool — true if s is already in the intern pool.
- `ConcatWithPlus(int n)` → string — concatenate `"0"` through `"{n-1}"` using `+` in a loop.
- `ConcatWithBuilder(int n)` → string — same but using the efficient mutable builder type.
