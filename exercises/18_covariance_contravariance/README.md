# 18. Covariance and Contravariance

## Feature

Generic variance — enabling type-safe assignment between related generic types (covariance and contravariance).

## When to use it / When to avoid it

Variance exists so generic interface/delegate assignments can respect the real subtyping relationship between their type arguments — a `Dog` producer really can stand in for an `Animal` producer, and the compiler can prove it's safe as long as `T` only flows one direction.

- **Use it when**: designing a library-level generic interface or delegate where `T` appears in only output positions (`out T`, covariant — a "producer") or only input positions (`in T`, contravariant — a "consumer"), like `IEnumerable<T>` or `Action<T>`.
- **Avoid it when**: `T` appears in both input and output positions on the same interface — it fundamentally can't be made variant, and trying to force it is a compile error. Also note that most day-to-day application code never needs to *declare* its own variant interface — this mostly matters when designing reusable, general-purpose APIs.

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

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
class Animal { }
class Dog : Animal { }

// "out T" — covariant: T only ever comes OUT (return positions)
interface IProducer<out T>
{
    T Produce();
}

// "in T" — contravariant: T only ever goes IN (parameter positions)
interface IConsumer<in T>
{
    void Consume(T item);
}

class DogProducer : IProducer<Dog>
{
    public Dog Produce() => new Dog();
}

class AnimalConsumer : IConsumer<Animal>
{
    public void Consume(Animal a) { }
}

// covariance: a more-specific producer can be used where a less-specific one is expected
IProducer<Animal> producer = new DogProducer();

// contravariance: a less-specific consumer can be used where a more-specific one is expected
IConsumer<Dog> consumer = new AnimalConsumer();

// built-in examples: IEnumerable<out T>, Action<in T>
```

</details>

## Things to watch for

- For covariance: T only appears in output (return) positions — the interface only "produces" T, never takes it as a parameter. Look up the C# type-parameter keyword for this direction.
- For contravariance: T only appears in input (parameter) positions — the interface only "consumes" T. Look up the C# type-parameter keyword for this direction.
- Covariance allows assigning a more-specific producer to a less-specific producer variable (a Dog producer IS an animal producer).
- Contravariance allows assigning a less-specific consumer to a more-specific consumer variable (an animal consumer CAN consume dogs).
- `IEnumerable<T>` is the most common built-in covariant interface — you can assign `IEnumerable<Dog>` to `IEnumerable<Animal>`.
- `Action<T>` is the most common built-in contravariant delegate — you can assign `Action<Animal>` to `Action<Dog>`.
