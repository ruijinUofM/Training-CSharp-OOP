namespace Kata;

// This file simulates auto-generated code (e.g., from a source generator or ORM).
// Do not modify this file.
public partial class CustomerOrder
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; } = "";
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
}
