# 09. Properties

## Feature

Properties — auto-properties, computed properties, backing fields with validation in setters, and limiting write access to within the class or at construction time.

## Case study

A `BankAccount` with an `Owner` (read-only), a `Balance` (validated — no negative balance), `Deposit`, and `Withdraw`. The balance setter is private; external code can only change the balance through the public methods.

## Required class and behavior

- **BankAccount**:
  - `Owner` (string) — read-only; set at construction, never changes.
  - `Balance` (decimal) — readable from outside; only changeable from within the class (not via external assignment).
  - `BankAccount(string owner, decimal initialBalance)` — throws `ArgumentException` if initialBalance < 0.
  - `Deposit(decimal amount)` — increases Balance; throws `ArgumentException` if amount ≤ 0.
  - `Withdraw(decimal amount)` — decreases Balance; throws `ArgumentException` if amount ≤ 0; throws `InvalidOperationException` if amount > Balance.

## Things to watch for

- C# lets you mix access modifiers on a property's getter and setter — think about how to make `Balance` publicly readable but only changeable from within the class.
- Validation in the constructor is the right place to enforce invariants at creation time.
- `ArgumentException` for bad arguments (negative deposit); `InvalidOperationException` for invalid state transitions (overdraft).
- C# 9 introduced an accessor that allows a property to be set at construction time but become read-only afterward. For this exercise, use a getter-only property with assignment in the constructor instead.
- Computed properties (no backing field needed): `public decimal Fee => Balance * 0.01m;`.
