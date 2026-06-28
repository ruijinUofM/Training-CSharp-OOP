// Covariance and Contravariance, written from scratch.
//
// Required API:
//
//   class Animal { public string Name { get; } Animal(string name) }
//   class Dog : Animal { Dog(string name) : base(name) }
//
//   interface IProducer<out T> { T Produce(); }    // covariant: out T
//   interface IConsumer<in T>  { void Consume(T item); }  // contravariant: in T
//
//   class DogProducer : IProducer<Dog>
//   {
//       public Dog Produce() => new Dog("Rex");
//   }
//
//   class AnimalConsumer : IConsumer<Animal>
//   {
//       public List<string> Consumed { get; } = new();
//       public void Consume(Animal a) => Consumed.Add(a.Name);
//   }
//
// Key assignments to understand:
//   IProducer<Animal> = new DogProducer();  // covariance: Dog IS an Animal
//   IConsumer<Dog> = new AnimalConsumer();  // contravariance: Animal consumer can consume Dog

namespace Kata;

// Write your implementation below.
