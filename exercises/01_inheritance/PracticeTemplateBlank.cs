// Inheritance -- Animal/Dog/Cat, written from scratch.
//
// Required API:
//
//   class Animal
//   {
//       public string Name { get; }
//       public Animal(string name)
//       public virtual string Speak()    // "..."
//       public virtual string Describe() // "I am {Name}"
//   }
//
//   class Dog : Animal
//   {
//       public Dog(string name) : base(name)
//       public override string Speak()   // "Woof!"
//   }
//
//   class Cat : Animal
//   {
//       public Cat(string name) : base(name)
//       public override string Speak()   // "Meow!"
//       public override string Describe() // "I am {Name}, a mysterious cat"
//   }

namespace Kata;

// Write your implementation below.
