# 12. Dependency Injection

## Feature

Constructor injection, interface-based dependencies, test doubles (fakes).

## When to use it / When to avoid it

Dependency injection exists so a class depends on *what* it needs (an interface) rather than *how* that need is fulfilled (a concrete implementation) — the caller decides, which is what makes swapping in a fake for tests, or a different real implementation, possible without touching the class.

- **Use it when**: a class depends on something with side effects, I/O, or more than one plausible implementation — email senders, repositories, clocks, HTTP clients.
- **Avoid it when**: the dependency is a pure, stateless, deterministic helper that will realistically never vary or need faking (e.g. `Math` functions, string formatting) — injecting it adds constructor ceremony with no real flexibility gained.

## Case study

`NotificationService` receives an `IEmailSender` via its constructor. `FakeEmailSender` captures messages for testing. `ConsoleEmailSender` writes to stdout for real use.

## Required classes and behavior

- **IEmailSender** — contract: `Send(string to, string subject, string body)`.

- **FakeEmailSender** — fulfills IEmailSender for testing.
  - `Sent` — a list of `(To, Subject, Body)` tuples capturing every call to Send.
  - `Send(...)` — appends to Sent (no real email sent).

- **ConsoleEmailSender** — fulfills IEmailSender for real use.
  - `Send(...)` — writes to stdout (e.g., `"To: {to} | {subject}"`).

- **NotificationService** — uses IEmailSender without knowing which implementation.
  - Constructor receives an IEmailSender (injected by the caller, not created here).
  - The sender field cannot be reassigned after construction.
  - `NotifyUser(string email, string eventName)` — delegates to Send with:
    - Subject = `"Notification: {eventName}"`
    - Body = `"You have a new event: {eventName}"`

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
interface IThingDoer
{
    void DoThing(string input);
}

class FakeThingDoer : IThingDoer
{
    // named-tuple list — capture calls without a dedicated class
    public List<(string Input, DateTime When)> Calls { get; } = new();

    public void DoThing(string input) => Calls.Add((input, DateTime.Now));
}

class RealThingDoer : IThingDoer
{
    public void DoThing(string input) => Console.WriteLine($"doing: {input}");
}

class ConsumerService
{
    // "readonly" — assigned once via constructor, never reassigned after
    private readonly IThingDoer _doer;

    // constructor injection: caller decides which implementation to pass in
    public ConsumerService(IThingDoer doer) { _doer = doer; }

    public void Run(string input) => _doer.DoThing(input);
}

// caller picks the implementation — the class itself never "new"s one up
var service = new ConsumerService(new FakeThingDoer());
```

</details>

## Things to watch for

- `NotificationService` does NOT create an `IEmailSender` internally. The caller decides which implementation to use — this is dependency injection.
- In a real app (ASP.NET Core), you'd register `IEmailSender → SmtpEmailSender` in the DI container and let the framework inject it automatically.
- The test uses `FakeEmailSender` — same interface, different behavior. No real emails, no network.
- Think about how to prevent the injected sender field from being reassigned after construction — C# has a field modifier for this.
- Tuple syntax `(string To, string Subject, string Body)` is a named tuple — `item.To`, `item.Subject`, `item.Body` work without a separate class.
