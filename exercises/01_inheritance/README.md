# 01. Inheritance

## Feature

Class inheritance — extending a base class, customizing inherited behavior in subclasses, and preventing further extension.

## When to use it / When to avoid it

Inheritance exists to eliminate duplication among types that share both state and behavior, while letting each type specialize the parts that differ — and to let calling code treat all of them uniformly through the base type (polymorphism).

- **Use it when**: the types genuinely have an "is-a" relationship (a `Dog` really is an `Animal`), they share meaningful implementation (not just a signature), and you want callers to work with the base type without caring which subclass they hold.
- **Avoid it when**: the relationship is really "has-a" or "can-do" — e.g. a `Car` "has an" `Engine`, it isn't one. Prefer composition (holding a reference) or an interface (a capability) in that case. Also avoid building deep hierarchies "just in case" — each added layer makes every subclass more fragile to changes in its ancestors (the "fragile base class" problem).

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

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
class Base
{
    public string Field { get; }
    public Base(string field) { Field = field; }

    // "virtual" = subclasses MAY replace this
    public virtual string DoThing() => "base behavior";
}

class Derived : Base
{
    // ": base(...)" forwards constructor args to the base class
    public Derived(string field) : base(field) { }

    // "override" = actually replaces Base's version polymorphically
    public override string DoThing() => "derived behavior";

    // calling the parent's version explicitly
    public string CallBase() => base.DoThing();
}

class Locked : Base
{
    public Locked(string field) : base(field) { }

    // "sealed override" = replaces it, but blocks further overriding below this point
    public sealed override string DoThing() => "final behavior";
}
```

</details>

## Things to watch for

- A base method must be marked to allow subclasses to replace it; without that marking, you can only hide it (not polymorphically replace it).
- A subclass method that replaces a base method needs a specific keyword to do so polymorphically.
- `base(name)` passes the constructor argument up to `Animal`'s constructor.
- `base.Describe()` calls the parent's version if you ever need it inside an override.
- A keyword exists to prevent any further subclass from replacing a method again.
