namespace Kata;

class Animal
{
    public string Name { get; }
    public Animal(string name) { Name = name; }
}

class Dog : Animal
{
    public Dog(string name) : base(name) { }
}

interface IProducer<out T> { T Produce(); }
interface IConsumer<in T> { void Consume(T item); }

class DogProducer : IProducer<Dog>
{
    public Dog Produce() => new Dog("Rex");
}

class AnimalConsumer : IConsumer<Animal>
{
    public List<string> Consumed { get; } = new();
    public void Consume(Animal a) => Consumed.Add(a.Name);
}
