// Attributes and Reflection -- ValidateAttribute + FormValidator, written from scratch.
//
// Required API:
//
//   [AttributeUsage(AttributeTargets.Property)]
//   class ValidateAttribute : Attribute
//   {
//       public int MinLength { get; }
//       public int MaxLength { get; }
//       public ValidateAttribute(int minLength, int maxLength)
//   }
//
//   static class FormValidator
//   {
//       public static List<string> Validate<T>(T obj)
//       // For each property with [Validate]:
//       //   cast value to string?
//       //   null or too short: "{PropName} is too short"
//       //   too long:          "{PropName} is too long"
//   }
//
//   class UserForm
//   {
//       [Validate(2, 50)]  public string? Name { get; set; }
//       [Validate(5, 100)] public string? Email { get; set; }
//   }
//
// Reflection workflow:
//   typeof(T).GetProperties()
//   prop.GetCustomAttribute<ValidateAttribute>()
//   prop.GetValue(obj) as string

using System.Reflection;

namespace Kata;

// Write your implementation below.
