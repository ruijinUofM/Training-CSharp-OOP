# 12. Dependency Injection

## Feature

Constructor injection, interface-based dependencies, test doubles (fakes).

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

## Things to watch for

- `NotificationService` does NOT create an `IEmailSender` internally. The caller decides which implementation to use — this is dependency injection.
- In a real app (ASP.NET Core), you'd register `IEmailSender → SmtpEmailSender` in the DI container and let the framework inject it automatically.
- The test uses `FakeEmailSender` — same interface, different behavior. No real emails, no network.
- `readonly` on the field prevents accidental reassignment after construction.
- Tuple syntax `(string To, string Subject, string Body)` is a named tuple — `item.To`, `item.Subject`, `item.Body` work without a separate class.
