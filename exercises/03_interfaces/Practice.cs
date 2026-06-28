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
    public Circle(double radius) { throw new NotImplementedException(); }
    public void Draw() { throw new NotImplementedException(); }
    public void Resize(double factor) { throw new NotImplementedException(); }
}

class Square : IDrawable, IResizable
{
    public double Side { get; private set; }
    public Square(double side) { throw new NotImplementedException(); }
    public void Draw() { throw new NotImplementedException(); }
    public void Resize(double factor) { throw new NotImplementedException(); }
}
