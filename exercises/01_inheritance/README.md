# 01. Inheritance

## Feature

Class inheritance, `virtual` / `override`, the `base` keyword, `sealed override`.

## Case study

An `Animal` base class with a `Name` property, a `virtual Speak()` method, and a `virtual Describe()` method. `Dog` and `Cat` both inherit from `Animal`. `Dog` overrides `Speak()` → `"Woof!"` and uses the inherited `Describe()`. `Cat` overrides both `Speak()` → `"Meow!"` and `Describe()` → `"I am {Name}, a mysterious cat"`.

## Required API

```csharp
class Animal
{
    public string Name { get; }
    public Animal(string name)
    public virtual string Speak()      // returns "..."
    public virtual string Describe()   // returns "I am {Name}"
}

class Dog : Animal
{
    public Dog(string name) : base(name) { }
    public override string Speak()     // "Woof!"
    // Describe() inherited from Animal
}

class Cat : Animal
{
    public Cat(string name) : base(name) { }
    public override string Speak()     // "Meow!"
    public override string Describe()  // "I am {Name}, a mysterious cat"
}
```

## Things to watch for

- `virtual` on the base method allows it to be overridden. Without `virtual`, you can only `new` (hide) it — not override it.
- `override` on the subclass method replaces the base implementation polymorphically.
- `base(name)` passes the constructor argument up to `Animal`'s constructor.
- `base.Describe()` calls the parent's version if you ever need it inside an override.
- `sealed override` would prevent further subclasses from overriding again.
