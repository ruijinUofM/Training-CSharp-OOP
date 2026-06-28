using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void Delivered_IsTerminal()
    {
        Assert.True(OrderStatus.Delivered.IsTerminal());
    }

    [Fact]
    public void Cancelled_IsTerminal()
    {
        Assert.True(OrderStatus.Cancelled.IsTerminal());
    }

    [Fact]
    public void Pending_IsNotTerminal()
    {
        Assert.False(OrderStatus.Pending.IsTerminal());
    }

    [Fact]
    public void Pending_CanTransitionTo_Processing()
    {
        Assert.True(OrderStatus.Pending.CanTransitionTo(OrderStatus.Processing));
    }

    [Fact]
    public void Pending_CannotTransitionTo_Shipped()
    {
        Assert.False(OrderStatus.Pending.CanTransitionTo(OrderStatus.Shipped));
    }

    [Fact]
    public void Processing_CanTransitionTo_Cancelled()
    {
        Assert.True(OrderStatus.Processing.CanTransitionTo(OrderStatus.Cancelled));
    }

    [Fact]
    public void Delivered_CannotTransition()
    {
        Assert.False(OrderStatus.Delivered.CanTransitionTo(OrderStatus.Cancelled));
    }

    [Fact]
    public void Permission_HasFlag()
    {
        var perms = Permission.Read | Permission.Write;
        Assert.True(perms.HasFlag(Permission.Read));
        Assert.False(perms.HasFlag(Permission.Execute));
    }

    [Fact]
    public void Permission_None_IsZero()
    {
        Assert.Equal(0, (int)Permission.None);
    }

    [Fact]
    public void Permission_Combined_Value()
    {
        Assert.Equal(3, (int)(Permission.Read | Permission.Write));
    }
}
