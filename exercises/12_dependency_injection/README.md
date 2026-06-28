# 12. Dependency Injection

## Feature

Constructor injection, interface-based dependencies, test doubles (fakes).

## Case study

`NotificationService` receives an `IEmailSender` via its constructor. `FakeEmailSender` captures messages for testing. `ConsoleEmailSender` writes to stdout for real use.

## Required API

```csharp
interface IEmailSender
{
    void Send(string to, string subject, string body);
}

class FakeEmailSender : IEmailSender
{
    public List<(string To, string Subject, string Body)> Sent { get; } = new();
    public void Send(string to, string subject, string body)
    // appends (to, subject, body) to Sent
}

class ConsoleEmailSender : IEmailSender
{
    public void Send(string to, string subject, string body)
    // Console.WriteLine($"To: {to} | {subject}")
}

class NotificationService
{
    private readonly IEmailSender _sender;
    public NotificationService(IEmailSender sender)

    public void NotifyUser(string email, string eventName)
    // Subject = $"Notification: {eventName}"
    // Body    = $"You have a new event: {eventName}"
}
```

## Things to watch for

- `NotificationService` does NOT create an `IEmailSender` internally. The caller decides which implementation to use — this is dependency injection.
- In a real app (ASP.NET Core), you'd register `IEmailSender → SmtpEmailSender` in the DI container and let the framework inject it automatically.
- The test uses `FakeEmailSender` — same interface, different behavior. No real emails, no network.
- `readonly` on the field prevents accidental reassignment after construction.
- Tuple syntax `(string To, string Subject, string Body)` is a named tuple — `item.To`, `item.Subject`, `item.Body` work without a separate class.
