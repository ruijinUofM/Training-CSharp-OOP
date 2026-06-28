namespace Kata;

class BankAccount
{
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner, decimal initialBalance)
    { throw new NotImplementedException(); }

    public void Deposit(decimal amount)
    { throw new NotImplementedException(); }

    public void Withdraw(decimal amount)
    { throw new NotImplementedException(); }
}
