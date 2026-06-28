namespace Kata;

class Button
{
    public event EventHandler? Clicked;
    public void Click() => Clicked?.Invoke(this, EventArgs.Empty);
}

class Counter
{
    public int Count { get; private set; }
    public event Action<int>? CountChanged;

    public void Increment()
    {
        Count++;
        CountChanged?.Invoke(Count);
    }
}
