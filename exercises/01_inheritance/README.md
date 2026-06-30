# 01. Inheritance

## Feature

Class inheritance, `virtual` / `override`, the `base` keyword, `sealed override`.

## Case study

An `Animal` base class with a `Name` property, a `virtual Speak()` method, and a `virtual Describe()` method. `Dog` and `Cat` both inherit from `Animal`. `Dog` overrides `Speak()` → `"Woof!"` and uses the inherited `Describe()`. `Cat` overrides both `Speak()` → `"Meow!"` and `Describe()` → `"I am {Name}, a mysterious cat"`.

## Required classes and behavior

- **Animal** — base class.
  - `Name` (string) — read-only; set via constructor.
  - `Speak()` → string — returns `"..."`; subclasses may optionally provide their own version.
  - `Describe()` → string — returns `"I am {Name}"`; subclasses may optionally provide their own version.

- **Dog : Animal** — inherits Animal; passes name up to Animal's constructor.
  - `Speak()` — returns `"Woof!"` (its own version).
  - `Describe()` — uses Animal's version (no change needed).

- **Cat : Animal** — inherits Animal; passes name up to Animal's constructor.
  - `Speak()` — returns `"Meow!"` (its own version).
  - `Describe()` — returns `"I am {Name}, a mysterious cat"` (its own version).

## Things to watch for

- `virtual` on the base method allows it to be overridden. Without `virtual`, you can only `new` (hide) it — not override it.
- `override` on the subclass method replaces the base implementation polymorphically.
- `base(name)` passes the constructor argument up to `Animal`'s constructor.
- `base.Describe()` calls the parent's version if you ever need it inside an override.
- `sealed override` would prevent further subclasses from overriding again.
