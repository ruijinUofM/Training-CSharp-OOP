# 01. Inheritance

## Feature

Class inheritance — extending a base class, customizing inherited behavior in subclasses, and preventing further extension.

## Case study

An `Animal` base class with a `Name` property, a `Speak()` method with a default implementation, and a `Describe()` method with a default implementation. `Dog` and `Cat` both inherit from `Animal`. `Dog` replaces `Speak()` → `"Woof!"` and uses the inherited `Describe()`. `Cat` replaces both `Speak()` → `"Meow!"` and `Describe()` → `"I am {Name}, a mysterious cat"`.

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

- A base method must be marked to allow subclasses to replace it; without that marking, you can only hide it (not polymorphically replace it).
- A subclass method that replaces a base method needs a specific keyword to do so polymorphically.
- `base(name)` passes the constructor argument up to `Animal`'s constructor.
- `base.Describe()` calls the parent's version if you ever need it inside an override.
- A keyword exists to prevent any further subclass from replacing a method again.
