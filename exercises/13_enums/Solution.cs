namespace Kata;

enum OrderStatus { Pending, Processing, Shipped, Delivered, Cancelled }

static class OrderStatusExtensions
{
    public static bool IsTerminal(this OrderStatus s)
        => s is OrderStatus.Delivered or OrderStatus.Cancelled;

    public static bool CanTransitionTo(this OrderStatus current, OrderStatus next)
    {
        if (current.IsTerminal()) return false;
        return (current, next) switch
        {
            (OrderStatus.Pending, OrderStatus.Processing) => true,
            (OrderStatus.Processing, OrderStatus.Shipped) => true,
            (OrderStatus.Shipped, OrderStatus.Delivered) => true,
            (_, OrderStatus.Cancelled) => true,
            _ => false,
        };
    }
}

[Flags]
enum Permission { None = 0, Read = 1, Write = 2, Execute = 4 }
