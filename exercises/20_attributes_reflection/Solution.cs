using System.Reflection;

namespace Kata;

[AttributeUsage(AttributeTargets.Property)]
class ValidateAttribute : Attribute
{
    public int MinLength { get; }
    public int MaxLength { get; }
    public ValidateAttribute(int minLength, int maxLength)
    {
        MinLength = minLength;
        MaxLength = maxLength;
    }
}

static class FormValidator
{
    public static List<string> Validate<T>(T obj)
    {
        var errors = new List<string>();
        foreach (var prop in typeof(T).GetProperties())
        {
            var attr = prop.GetCustomAttribute<ValidateAttribute>();
            if (attr == null) continue;

            var value = prop.GetValue(obj) as string;
            if (value == null || value.Length < attr.MinLength)
                errors.Add($"{prop.Name} is too short");
            else if (value.Length > attr.MaxLength)
                errors.Add($"{prop.Name} is too long");
        }
        return errors;
    }
}

class UserForm
{
    [Validate(2, 50)]
    public string? Name { get; set; }

    [Validate(5, 100)]
    public string? Email { get; set; }
}
