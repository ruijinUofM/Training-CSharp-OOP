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

## Required implementation

```csharp
public static class StringInternals
{
    public static bool ContentEqual(string a, string b);      // a == b (value equality)
    public static bool ReferenceEqual(string a, string b);    // ReferenceEquals(a, b)
    public static string InternString(string s);              // string.Intern(s)
    public static bool IsInterned(string s);                  // string.IsInterned(s) != null
    public static string ConcatWithPlus(int n);               // "" + 0 + 1 + ... (n-1)
    public static string ConcatWithBuilder(int n);            // StringBuilder version
}
```
