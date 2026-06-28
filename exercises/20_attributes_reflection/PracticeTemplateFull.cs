using System.Reflection;

namespace Kata;

[AttributeUsage(AttributeTargets.Property)]
class ValidateAttribute : Attribute
{
    public int MinLength { get; }
    public int MaxLength { get; }
    public ValidateAttribute(int minLength, int maxLength) { throw new NotImplementedException(); }
}

static class FormValidator
{
    public static List<string> Validate<T>(T obj) { throw new NotImplementedException(); }
}

class UserForm
{
    [Validate(2, 50)]
    public string? Name { get; set; }

    [Validate(5, 100)]
    public string? Email { get; set; }
}
