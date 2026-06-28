namespace Kata;

interface IDrawable
{
    void Draw();
}

interface IResizable
{
    void Resize(double factor);
}

class Circle : IDrawable, IResizable
{
    public double Radius { get; private set; }
    public Circle(double radius) { Radius = radius; }
    public void Draw() => Console.WriteLine($"Drawing circle r={Radius}");
    public void Resize(double factor) { Radius *= factor; }
}

class Square : IDrawable, IResizable
{
    public double Side { get; private set; }
    public Square(double side) { Side = side; }
    public void Draw() => Console.WriteLine($"Drawing square s={Side}");
    public void Resize(double factor) { Side *= factor; }
}
