using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void Constructor_SetsOwnerAndBalance()
    {
        var account = new BankAccount("Alice", 100m);
        Assert.Equal("Alice", account.Owner);
        Assert.Equal(100m, account.Balance);
    }

    [Fact]
    public void Constructor_NegativeBalance_Throws()
    {
        Assert.Throws<ArgumentException>(() => new BankAccount("Bob", -1m));
    }

    [Fact]
    public void Deposit_IncreasesBalance()
    {
        var account = new BankAccount("Alice", 100m);
        account.Deposit(50m);
        Assert.Equal(150m, account.Balance);
    }

    [Fact]
    public void Deposit_Zero_Throws()
    {
        var account = new BankAccount("Alice", 100m);
        Assert.Throws<ArgumentException>(() => account.Deposit(0m));
    }

    [Fact]
    public void Withdraw_DecreasesBalance()
    {
        var account = new BankAccount("Alice", 100m);
        account.Withdraw(30m);
        Assert.Equal(70m, account.Balance);
    }

    [Fact]
    public void Withdraw_Overdraft_Throws()
    {
        var account = new BankAccount("Alice", 50m);
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(100m));
    }

    [Fact]
    public void Withdraw_NegativeAmount_Throws()
    {
        var account = new BankAccount("Alice", 100m);
        Assert.Throws<ArgumentException>(() => account.Withdraw(-10m));
    }
}
