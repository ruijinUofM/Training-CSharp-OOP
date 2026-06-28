using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void DogProducer_Produces_Dog()
    {
        var producer = new DogProducer();
        var dog = producer.Produce();
        Assert.IsType<Dog>(dog);
        Assert.Equal("Rex", dog.Name);
    }

    [Fact]
    public void Covariance_DogProducer_AssignableToAnimalProducer()
    {
        IProducer<Dog> dogProducer = new DogProducer();
        IProducer<Animal> animalProducer = dogProducer; // covariance
        var animal = animalProducer.Produce();
        Assert.NotNull(animal);
    }

    [Fact]
    public void AnimalConsumer_Consumes_Dog()
    {
        var consumer = new AnimalConsumer();
        consumer.Consume(new Dog("Buddy"));
        Assert.Single(consumer.Consumed);
        Assert.Equal("Buddy", consumer.Consumed[0]);
    }

    [Fact]
    public void Contravariance_AnimalConsumer_AssignableToDogConsumer()
    {
        IConsumer<Animal> animalConsumer = new AnimalConsumer();
        IConsumer<Dog> dogConsumer = animalConsumer; // contravariance
        dogConsumer.Consume(new Dog("Max"));
        Assert.Single(((AnimalConsumer)animalConsumer).Consumed);
    }

    [Fact]
    public void IEnumerable_Covariance()
    {
        IEnumerable<Dog> dogs = new List<Dog> { new("Rex") };
        IEnumerable<Animal> animals = dogs; // built-in covariance
        Assert.Single(animals);
    }
}
