# 18. Covariance and Contravariance

## Feature

Generic variance: `out T` (covariant — producer), `in T` (contravariant — consumer), built-in examples (`IEnumerable<out T>`, `Action<in T>`).

## Case study

`IProducer<out T>` (covariant) and `IConsumer<in T>` (contravariant) interfaces. `DogProducer : IProducer<Dog>` can be assigned to `IProducer<Animal>` because `out T` means "I only produce T, never consume it." `AnimalConsumer : IConsumer<Animal>` can be assigned to `IConsumer<Dog>` because `in T` means "I only consume T."

## Required classes and behavior

- **Animal** — `Name` (string) read-only; set via constructor.
- **Dog : Animal** — passes name up to Animal's constructor.

- **IProducer&lt;T&gt;** — contract with one method: `Produce()` → T.
  - T only appears in output (return) positions.
  - This means an `IProducer<Dog>` can be assigned to `IProducer<Animal>`.
  - C# requires a specific keyword on the type parameter to enable this.

- **IConsumer&lt;T&gt;** — contract with one method: `Consume(T item)`.
  - T only appears in input (parameter) positions.
  - This means an `IConsumer<Animal>` can be assigned to `IConsumer<Dog>`.
  - C# requires a specific keyword on the type parameter to enable this.

- **DogProducer** — fulfills `IProducer<Dog>`; `Produce()` returns `new Dog("Rex")`.

- **AnimalConsumer** — fulfills `IConsumer<Animal>`.
  - `Consumed` (List&lt;string&gt;) — tracks names of consumed animals.
  - `Consume(Animal)` — appends the animal's Name to Consumed.

## Things to watch for

- `out T` means T only appears in output (return) positions — the interface only "produces" T, never takes it as a parameter.
- `in T` means T only appears in input (parameter) positions — the interface only "consumes" T.
- Covariance allows: `IProducer<Dog> dogProd = new DogProducer(); IProducer<Animal> animalProd = dogProd;`
  — A dog producer IS an animal producer (a Dog is an Animal).
- Contravariance allows: `IConsumer<Animal> animalCons = new AnimalConsumer(); IConsumer<Dog> dogCons = animalCons;`
  — An animal consumer CAN consume dogs (Dog is a subtype of Animal).
- `IEnumerable<out T>` is the most common built-in covariant interface — you can assign `IEnumerable<Dog>` to `IEnumerable<Animal>`.
- `Action<in T>` is the most common built-in contravariant — you can assign `Action<Animal>` to `Action<Dog>`.
