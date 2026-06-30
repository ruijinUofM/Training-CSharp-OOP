// Attributes and Reflection -- ValidateAttribute + FormValidator, written from scratch.
//
// Required types and behavior:
//
//   ValidateAttribute — a custom metadata tag applicable to properties only.
//       MinLength (int), MaxLength (int) — read-only; set via constructor.
//       (Look up how to declare a custom attribute class in C#, and how to restrict
//       which targets it can be applied to.)
//
//   FormValidator — static class:
//       Validate<T>(T obj) → List<string> — inspects all properties of obj at runtime;
//           for each property tagged with ValidateAttribute:
//               gets the string value of the property;
//               if null or shorter than MinLength: adds "{PropertyName} is too short";
//               if longer than MaxLength: adds "{PropertyName} is too long".
//
//   UserForm — example form class with two nullable string properties:
//       Name — must be 2–50 characters.
//       Email — must be 5–100 characters.
//
// Reflection workflow: typeof(T).GetProperties(), prop.GetCustomAttribute<ValidateAttribute>(),
//   prop.GetValue(obj) as string.

using System.Reflection;

namespace Kata;

// Write your implementation below.
