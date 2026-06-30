// Covariance and Contravariance, written from scratch.
//
// Required classes and behavior:
//
//   Animal — Name (string) read-only; set via constructor.
//   Dog : Animal — passes name up to Animal's constructor.
//
//   IProducer<T> — contract with one method: Produce() → T.
//       The type parameter only appears in output (return) positions, meaning an
//       IProducer<Dog> can be assigned to IProducer<Animal>.
//       (C# requires a specific keyword on the type parameter to enable this.)
//
//   IConsumer<T> — contract with one method: Consume(T item).
//       The type parameter only appears in input (parameter) positions, meaning an
//       IConsumer<Animal> can be assigned to IConsumer<Dog>.
//       (C# requires a specific keyword on the type parameter to enable this.)
//
//   DogProducer — fulfills IProducer<Dog>; Produce() returns new Dog("Rex").
//
//   AnimalConsumer — fulfills IConsumer<Animal>.
//       Consumed (List<string>) — tracks names of consumed animals.
//       Consume(Animal) — appends the animal's Name to Consumed.
//
// Key assignments to understand:
//   IProducer<Dog> can be assigned to IProducer<Animal> (covariance — Dog IS an Animal)
//   IConsumer<Animal> can be assigned to IConsumer<Dog> (contravariance)

namespace Kata;

// Write your implementation below.
