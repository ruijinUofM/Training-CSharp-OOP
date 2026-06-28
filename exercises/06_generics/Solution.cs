namespace Kata;

class Stack<T>
{
    private readonly List<T> _items = new();

    public void Push(T item) => _items.Add(item);

    public T Pop()
    {
        if (_items.Count == 0) throw new InvalidOperationException("Stack is empty");
        var item = _items[^1];
        _items.RemoveAt(_items.Count - 1);
        return item;
    }

    public T Peek()
    {
        if (_items.Count == 0) throw new InvalidOperationException("Stack is empty");
        return _items[^1];
    }

    public int Count => _items.Count;
    public bool IsEmpty => _items.Count == 0;
}

class Pair<T, U>
{
    public T First { get; }
    public U Second { get; }
    public Pair(T first, U second) { First = first; Second = second; }
    public Pair<U, T> Swap() => new(Second, First);
}
