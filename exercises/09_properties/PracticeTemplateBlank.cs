// Properties -- BankAccount, written from scratch.
//
// Required API:
//
//   class BankAccount
//   {
//       public string Owner { get; }              // read-only
//       public decimal Balance { get; private set; }  // writable only inside class
//
//       public BankAccount(string owner, decimal initialBalance)
//           // throws ArgumentException if initialBalance < 0
//
//       public void Deposit(decimal amount)
//           // throws ArgumentException if amount <= 0
//
//       public void Withdraw(decimal amount)
//           // throws ArgumentException if amount <= 0
//           // throws InvalidOperationException if amount > Balance
//   }

namespace Kata;

// Write your implementation below.
