# 09. Properties

## Feature

Properties — auto-properties, computed properties, backing fields with validation in setters, and limiting write access to within the class or at construction time.

## When to use it / When to avoid it

Properties exist so that any public state on a class can be validated, computed, or access-restricted later without changing the call-site syntax (`obj.Balance` looks the same whether it's a raw field or a computed value) — that's why C# strongly prefers properties over public fields at any API boundary.

- **Use it when**: exposing state publicly from a class — always prefer a property over a public field, even a trivial auto-property, because you can add validation/logic later without a breaking change; also use them for cheap, side-effect-free computed values.
- **Avoid it when**: the "getter" logic is actually expensive or has side effects — a property looks like free field access to callers, so anything surprising (I/O, heavy computation, mutation) belongs in a named method instead, where the cost is visible at the call site.

## Case study

A `BankAccount` with an `Owner` (read-only), a `Balance` (validated — no negative balance), `Deposit`, and `Withdraw`. The balance setter is private; external code can only change the balance through the public methods.

## Required class and behavior

- **BankAccount**:
  - `Owner` (string) — read-only; set at construction, never changes.
  - `Balance` (decimal) — readable from outside; only changeable from within the class (not via external assignment).
  - `BankAccount(string owner, decimal initialBalance)` — throws `ArgumentException` if initialBalance < 0.
  - `Deposit(decimal amount)` — increases Balance; throws `ArgumentException` if amount ≤ 0.
  - `Withdraw(decimal amount)` — decreases Balance; throws `ArgumentException` if amount ≤ 0; throws `InvalidOperationException` if amount > Balance.

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
class Account
{
    // read-only from outside; only settable in the constructor
    public string Owner { get; }

    // publicly readable, but the setter is only callable from inside this class
    public decimal Balance { get; private set; }

    public Account(string owner, decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new ArgumentException("cannot be negative");

        Owner = owner;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("must be positive");
        Balance += amount;   // allowed: private setter, same class
    }

    // computed property — no backing field, no setter at all
    public decimal Fee => Balance * 0.01m;

    // "protected set" — only this class and subclasses can assign
    public string LastAction { get; protected set; } = "";
}

// var acct = new Account("Alice", 100m);
// acct.Balance = 999m;   // <- compile error: setter is private
```

</details>

## Things to watch for

- C# lets you mix access modifiers on a property's getter and setter — think about how to make `Balance` publicly readable but only changeable from within the class.
- Validation in the constructor is the right place to enforce invariants at creation time.
- `ArgumentException` for bad arguments (negative deposit); `InvalidOperationException` for invalid state transitions (overdraft).
- C# 9 introduced an accessor that allows a property to be set at construction time but become read-only afterward. For this exercise, use a getter-only property with assignment in the constructor instead.
- Computed properties (no backing field needed): `public decimal Fee => Balance * 0.01m;`.
