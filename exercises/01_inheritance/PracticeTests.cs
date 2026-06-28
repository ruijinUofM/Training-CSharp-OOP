using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void Dog_Speak_ReturnsWoof()
    {
        var dog = new Dog("Rex");
        Assert.Equal("Woof!", dog.Speak());
    }

    [Fact]
    public void Cat_Speak_ReturnsMeow()
    {
        var cat = new Cat("Whiskers");
        Assert.Equal("Meow!", cat.Speak());
    }

    [Fact]
    public void Animal_Speak_ReturnsDots()
    {
        // Animal itself is not abstract, so we can instantiate it directly
        var a = new Animal("Generic");
        Assert.Equal("...", a.Speak());
    }

    [Fact]
    public void Dog_Describe_UsesBaseBehavior()
    {
        var dog = new Dog("Buddy");
        Assert.Equal("I am Buddy", dog.Describe());
    }

    [Fact]
    public void Cat_Describe_IsCustom()
    {
        var cat = new Cat("Luna");
        Assert.Contains("mysterious", cat.Describe());
        Assert.Contains("Luna", cat.Describe());
    }

    [Fact]
    public void Animal_Name_IsSet()
    {
        var dog = new Dog("Max");
        Assert.Equal("Max", dog.Name);
    }

    [Fact]
    public void Dog_IsA_Animal()
    {
        var dog = new Dog("Rex");
        Assert.IsAssignableFrom<Animal>(dog);
    }
}
