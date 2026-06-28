namespace Kata;

class Animal
{
    public string Name { get; }
    public Animal(string name) { throw new NotImplementedException(); }
    public virtual string Speak() { throw new NotImplementedException(); }
    public virtual string Describe() { throw new NotImplementedException(); }
}

class Dog : Animal
{
    public Dog(string name) : base(name) { }
    public override string Speak() { throw new NotImplementedException(); }
}

class Cat : Animal
{
    public Cat(string name) : base(name) { }
    public override string Speak() { throw new NotImplementedException(); }
    public override string Describe() { throw new NotImplementedException(); }
}
