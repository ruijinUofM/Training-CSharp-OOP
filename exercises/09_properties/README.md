# 09. Properties

## Feature

Auto-properties, computed properties, backing fields with validation in setters, `private set`, `init`.

## Case study

A `BankAccount` with an `Owner` (read-only), a `Balance` (validated — no negative balance), `Deposit`, and `Withdraw`. The setter is private; external code can only change balance through the public methods.

## Required class and behavior

- **BankAccount**:
  - `Owner` (string) — read-only; set at construction, never changes.
  - `Balance` (decimal) — readable from outside; only changeable from within the class (not via external assignment).
  - `BankAccount(string owner, decimal initialBalance)` — throws `ArgumentException` if initialBalance < 0.
  - `Deposit(decimal amount)` — increases Balance; throws `ArgumentException` if amount ≤ 0.
  - `Withdraw(decimal amount)` — decreases Balance; throws `ArgumentException` if amount ≤ 0; throws `InvalidOperationException` if amount > Balance.

## Things to watch for

- `public decimal Balance { get; private set; }` — public getter, private setter. The value can only be changed from within the class.
- Validation in the constructor is the right place to enforce invariants at creation time.
- `ArgumentException` for bad arguments (negative deposit); `InvalidOperationException` for invalid state transitions (overdraft).
- `init` accessors (C# 9+) allow a property to be set at construction time but become read-only afterward: `public string Owner { get; init; }`. Use `{ get; }` (getter-only with constructor assignment) for this exercise.
- Computed properties (no backing field needed): `public decimal Fee => Balance * 0.01m;`.
