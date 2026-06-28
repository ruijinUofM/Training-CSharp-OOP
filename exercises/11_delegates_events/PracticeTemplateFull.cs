namespace Kata;

class Button
{
    public event EventHandler? Clicked;
    public void Click() { throw new NotImplementedException(); }
}

class Counter
{
    public int Count { get; private set; }
    public event Action<int>? CountChanged;
    public void Increment() { throw new NotImplementedException(); }
}
