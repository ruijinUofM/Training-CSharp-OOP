# 18. Covariance and Contravariance

## Feature

Generic variance: `out T` (covariant — producer), `in T` (contravariant — consumer), built-in examples (`IEnumerable<out T>`, `Action<in T>`).

## Case study

`IProducer<out T>` (covariant) and `IConsumer<in T>` (contravariant) interfaces. `DogProducer : IProducer<Dog>` can be assigned to `IProducer<Animal>` because `out T` means "I only produce T, never consume it." `AnimalConsumer : IConsumer<Animal>` can be assigned to `IConsumer<Dog>` because `in T` means "I only consume T."

## Required API

```csharp
class Animal { public string Name { get; } public Animal(string name) }
class Dog : Animal { public Dog(string name) : base(name) { } }

interface IProducer<out T>  { T Produce(); }
interface IConsumer<in T>   { void Consume(T item); }

class DogProducer : IProducer<Dog>
{
    public Dog Produce() => new Dog("Rex");
}

class AnimalConsumer : IConsumer<Animal>
{
    public List<string> Consumed { get; } = new();
    public void Consume(Animal a) => Consumed.Add(a.Name);
}
```

## Things to watch for

- `out T` means T only appears in output (return) positions — the interface only "produces" T, never takes it as a parameter.
- `in T` means T only appears in input (parameter) positions — the interface only "consumes" T.
- Covariance allows: `IProducer<Dog> dogProd = new DogProducer(); IProducer<Animal> animalProd = dogProd;`
  — A dog producer IS an animal producer (a Dog is an Animal).
- Contravariance allows: `IConsumer<Animal> animalCons = new AnimalConsumer(); IConsumer<Dog> dogCons = animalCons;`
  — An animal consumer CAN consume dogs (Dog is a subtype of Animal).
- `IEnumerable<out T>` is the most common built-in covariant interface — you can assign `IEnumerable<Dog>` to `IEnumerable<Animal>`.
- `Action<in T>` is the most common built-in contravariant — you can assign `Action<Animal>` to `Action<Dog>`.
