using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void CustomerOrder_HasOrderId()
    {
        var order = new CustomerOrder { OrderId = 42, CustomerName = "Alice" };
        Assert.Equal(42, order.OrderId);
    }

    [Fact]
    public void CustomerOrder_HasCustomerName()
    {
        var order = new CustomerOrder { CustomerName = "Bob" };
        Assert.Equal("Bob", order.CustomerName);
    }

    [Fact]
    public void CustomerOrder_Items_StartsEmpty()
    {
        var order = new CustomerOrder();
        Assert.Empty(order.Items);
    }

    [Fact]
    public void CustomerOrder_Total_ReflectsItemCount()
    {
        var order = new CustomerOrder();
        order.Items.Add("Widget");
        order.Items.Add("Gadget");
        Assert.Equal(2 * 9.99m, order.Total);
    }

    [Fact]
    public void CustomerOrder_Summary_ContainsOrderId()
    {
        var order = new CustomerOrder { OrderId = 7, CustomerName = "Carol" };
        order.Items.Add("Thing");
        Assert.Contains("7", order.Summary());
    }

    [Fact]
    public void CustomerOrder_Summary_ContainsCustomerName()
    {
        var order = new CustomerOrder { OrderId = 1, CustomerName = "Dave" };
        Assert.Contains("Dave", order.Summary());
    }

    [Fact]
    public void CustomerOrder_HasCreatedAt()
    {
        var order = new CustomerOrder();
        Assert.True(order.CreatedAt <= DateTimeOffset.UtcNow);
    }
}
