namespace Kata;

static class Algorithms
{
    public static T Max<T>(T a, T b) where T : IComparable<T>
    { throw new NotImplementedException(); }

    public static bool AreEqual<T>(T a, T b) where T : struct
    { throw new NotImplementedException(); }
}

class Repository<T> where T : class, new()
{
    public T Create() { throw new NotImplementedException(); }
    public void Add(T item) { throw new NotImplementedException(); }
    public List<T> FindAll() { throw new NotImplementedException(); }
    public int Count { get { throw new NotImplementedException(); } }
}
