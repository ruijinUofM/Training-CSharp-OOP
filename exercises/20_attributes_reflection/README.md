# 20. Attributes and Reflection

## Feature

Custom attributes, `[AttributeUsage]`, `Type.GetProperties()`, `PropertyInfo.GetCustomAttribute<T>()`, runtime validation via reflection.

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

- **UserForm** — example form class with two nullable string properties:
  - `Name` — must be 2–50 characters.
  - `Email` — must be 5–100 characters.

## Things to watch for

- `[AttributeUsage(AttributeTargets.Property)]` restricts where the attribute can be applied.
- `typeof(T).GetProperties()` returns all public properties.
- `prop.GetCustomAttribute<ValidateAttribute>()` retrieves the attribute if present, or `null`.
- `prop.GetValue(obj)` returns the property value as `object?`; cast to `string?`.
- Reflection is slow; in production, use source generators or compiled expression trees for validation.
- Error message format: `"{Name} is too short"` / `"{Name} is too long"` where Name is `prop.Name`.
