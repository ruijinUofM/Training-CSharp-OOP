# 20. Attributes and Reflection

## Feature

Custom attributes, controlling where attributes can be applied, and runtime inspection via reflection.

## When to use it / When to avoid it

Attributes + reflection exist to attach declarative metadata to code and act on it generically at runtime, so you write the cross-cutting logic (validation, serialization, DI wiring) once instead of hand-rolling it per type.

- **Use it when**: implementing cross-cutting concerns driven by metadata — validation attributes, serialization mapping, ORMs, DI container registration — where the alternative is a lot of near-duplicate per-type code.
- **Avoid it when**: you're on a hot path — reflection is comparatively slow, so cache reflection results (or use source generators/compiled expression trees) rather than re-reflecting on every call. Also avoid reaching for reflection when a direct interface or method call would accomplish the same thing more simply and faster.

## Case study

A `[Validate(minLength, maxLength)]` attribute applied to string properties. A `FormValidator.Validate<T>(obj)` method uses reflection to inspect all properties with `[Validate]` and collect error messages.

## Required types and behavior

- **ValidateAttribute** — a custom metadata tag applicable to properties only.
  - `MinLength` (int), `MaxLength` (int) — read-only; set via constructor.
  - (Look up how to declare a custom attribute class in C#, and how to restrict which targets it can be applied to.)

- **FormValidator** — static class:
  - `Validate<T>(T obj)` → `List<string>` — inspects all properties of `obj` at runtime; for each property tagged with `ValidateAttribute`:
    - gets the string value of the property;
    - if null or shorter than MinLength: adds `"{PropertyName} is too short"`;
    - if longer than MaxLength: adds `"{PropertyName} is too long"`.
  - (Look up the reflection API for reading all properties of a type and fetching custom attributes.)

- **UserForm** — example form class with two nullable string properties:
  - `Name` — must be 2–50 characters.
  - `Email` — must be 5–100 characters.

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
using System.Reflection;

// "[AttributeUsage(...)]" restricts where this custom attribute can be applied
[AttributeUsage(AttributeTargets.Property)]
class RangeAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }
    public RangeAttribute(int min, int max) { Min = min; Max = max; }
}

class Form
{
    [Range(2, 50)]
    public string? Name { get; set; }
}

static class Validator
{
    public static List<string> Validate<T>(T obj)
    {
        var errors = new List<string>();

        // reflection: enumerate all public properties of the runtime type
        foreach (var prop in typeof(T).GetProperties())
        {
            // fetch a specific attribute instance off the property, if present
            var attr = prop.GetCustomAttribute<RangeAttribute>();
            if (attr is null) continue;

            var value = prop.GetValue(obj) as string;   // GetValue returns object?
            if (value is null || value.Length < attr.Min)
                errors.Add($"{prop.Name} is too short");
        }

        return errors;
    }
}
```

</details>

## Things to watch for

- There is a built-in attribute that restricts where a custom attribute can be applied — look up how to constrain it to properties only.
- The reflection API lets you iterate a type's public properties, check for attached attributes, and read property values at runtime.
- Property values come back as `object?`; cast to `string?` to apply length checks.
- Reflection is slow; in production, use source generators or compiled expression trees for validation.
- Error message format: `"{Name} is too short"` / `"{Name} is too long"` where Name is the property name.
