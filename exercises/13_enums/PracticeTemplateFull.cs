namespace Kata;

enum OrderStatus { Pending, Processing, Shipped, Delivered, Cancelled }

static class OrderStatusExtensions
{
    public static bool IsTerminal(this OrderStatus s) { throw new NotImplementedException(); }
    public static bool CanTransitionTo(this OrderStatus current, OrderStatus next) { throw new NotImplementedException(); }
}

[Flags]
enum Permission { None = 0, Read = 1, Write = 2, Execute = 4 }
