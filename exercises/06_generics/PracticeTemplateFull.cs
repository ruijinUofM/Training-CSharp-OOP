namespace Kata;

class Stack<T>
{
    public void Push(T item) { throw new NotImplementedException(); }
    public T Pop() { throw new NotImplementedException(); }
    public T Peek() { throw new NotImplementedException(); }
    public int Count { get { throw new NotImplementedException(); } }
    public bool IsEmpty { get { throw new NotImplementedException(); } }
}

class Pair<T, U>
{
    public T First { get; }
    public U Second { get; }
    public Pair(T first, U second) { throw new NotImplementedException(); }
    public Pair<U, T> Swap() { throw new NotImplementedException(); }
}
