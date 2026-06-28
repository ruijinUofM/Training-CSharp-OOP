namespace Kata;

static class Algorithms
{
    public static T Max<T>(T a, T b) where T : IComparable<T>
        => a.CompareTo(b) >= 0 ? a : b;

    public static bool AreEqual<T>(T a, T b) where T : struct
        => a.Equals(b);
}

class Repository<T> where T : class, new()
{
    private readonly List<T> _items = new();

    public T Create() => new T();
    public void Add(T item) => _items.Add(item);
    public List<T> FindAll() => new List<T>(_items);
    public int Count => _items.Count;
}
