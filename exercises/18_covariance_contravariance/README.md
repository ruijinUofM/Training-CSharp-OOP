# 18. Covariance and Contravariance

## Feature

Generic variance — enabling type-safe assignment between related generic types (covariance and contravariance).

## Case study

A covariant `IProducer<T>` (an `IProducer<Dog>` can be assigned to `IProducer<Animal>`) and a contravariant `IConsumer<T>` (an `IConsumer<Animal>` can be assigned to `IConsumer<Dog>`). Look up the C# type-parameter keywords that enable each direction.

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

- For covariance: T only appears in output (return) positions — the interface only "produces" T, never takes it as a parameter. Look up the C# type-parameter keyword for this direction.
- For contravariance: T only appears in input (parameter) positions — the interface only "consumes" T. Look up the C# type-parameter keyword for this direction.
- Covariance allows assigning a more-specific producer to a less-specific producer variable (a Dog producer IS an animal producer).
- Contravariance allows assigning a less-specific consumer to a more-specific consumer variable (an animal consumer CAN consume dogs).
- `IEnumerable<T>` is the most common built-in covariant interface — you can assign `IEnumerable<Dog>` to `IEnumerable<Animal>`.
- `Action<T>` is the most common built-in contravariant delegate — you can assign `Action<Animal>` to `Action<Dog>`.
