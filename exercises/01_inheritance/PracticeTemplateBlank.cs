// Inheritance -- Animal/Dog/Cat, written from scratch.
//
// Required classes and behavior:
//
//   Animal — base class.
//       Name (string) — read-only; set via constructor.
//       Speak() → string — returns "..."; subclasses may optionally provide
//           their own version.
//       Describe() → string — returns "I am {Name}"; subclasses may optionally
//           provide their own version.
//
//   Dog : Animal — inherits Animal; passes name up to Animal's constructor.
//       Speak() — returns "Woof!" (its own version, replacing Animal's).
//       Describe() — uses Animal's version (no change needed).
//
//   Cat : Animal — inherits Animal; passes name up to Animal's constructor.
//       Speak() — returns "Meow!" (its own version).
//       Describe() — returns "I am {Name}, a mysterious cat" (its own version).

namespace Kata;

// Write your implementation below.
