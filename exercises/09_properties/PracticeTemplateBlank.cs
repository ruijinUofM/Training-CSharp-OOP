// Properties -- BankAccount, written from scratch.
//
// Required class and behavior:
//
//   BankAccount:
//       Owner (string) — read-only; set at construction, never changes.
//       Balance (decimal) — readable from outside; only changeable from
//           within the class (not via external assignment).
//
//       BankAccount(string owner, decimal initialBalance) — constructor;
//           throws ArgumentException if initialBalance < 0.
//
//       Deposit(decimal amount) — increases Balance;
//           throws ArgumentException if amount <= 0.
//
//       Withdraw(decimal amount) — decreases Balance;
//           throws ArgumentException if amount <= 0;
//           throws InvalidOperationException if amount > Balance.

namespace Kata;

// Write your implementation below.
