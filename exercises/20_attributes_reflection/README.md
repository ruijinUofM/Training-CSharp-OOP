# 20. Attributes and Reflection

## Feature

Custom attributes, `[AttributeUsage]`, `Type.GetProperties()`, `PropertyInfo.GetCustomAttribute<T>()`, runtime validation via reflection.

## Case study

A `[Validate(minLength, maxLength)]` attribute applied to string properties. A `FormValidator.Validate<T>(obj)` method uses reflection to inspect all properties with `[Validate]` and collect error messages.

## Required API

```csharp
[AttributeUsage(AttributeTargets.Property)]
class ValidateAttribute : Attribute
{
    public int MinLength { get; }
    public int MaxLength { get; }
    public ValidateAttribute(int minLength, int maxLength)
}

static class FormValidator
{
    public static List<string> Validate<T>(T obj)
    // For each property with [Validate]:
    //   get the string value
    //   if null or length < MinLength: add "{PropertyName} is too short"
    //   if length > MaxLength: add "{PropertyName} is too long"
}

class UserForm
{
    [Validate(2, 50)]
    public string? Name { get; set; }

    [Validate(5, 100)]
    public string? Email { get; set; }
}
```

## Things to watch for

- `[AttributeUsage(AttributeTargets.Property)]` restricts where the attribute can be applied.
- `typeof(T).GetProperties()` returns all public properties.
- `prop.GetCustomAttribute<ValidateAttribute>()` retrieves the attribute if present, or `null`.
- `prop.GetValue(obj)` returns the property value as `object?`; cast to `string?`.
- Reflection is slow; in production, use source generators or compiled expression trees for validation.
- Error message format: `"{Name} is too short"` / `"{Name} is too long"` where Name is `prop.Name`.
