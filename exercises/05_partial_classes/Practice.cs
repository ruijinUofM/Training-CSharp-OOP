namespace Kata;

public partial class CustomerOrder
{
    public List<string> Items { get; } = new();
    public decimal Total => throw new NotImplementedException();
    public string Summary() { throw new NotImplementedException(); }
}
