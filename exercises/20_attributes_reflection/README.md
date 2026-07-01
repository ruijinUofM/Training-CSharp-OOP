# 20. Attributes and Reflection

## Feature

Custom attributes, controlling where attributes can be applied, and runtime inspection via reflection.

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

## Things to watch for

- There is a built-in attribute that restricts where a custom attribute can be applied — look up how to constrain it to properties only.
- The reflection API lets you iterate a type's public properties, check for attached attributes, and read property values at runtime.
- Property values come back as `object?`; cast to `string?` to apply length checks.
- Reflection is slow; in production, use source generators or compiled expression trees for validation.
- Error message format: `"{Name} is too short"` / `"{Name} is too long"` where Name is the property name.
