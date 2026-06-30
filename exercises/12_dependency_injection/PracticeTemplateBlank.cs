// Dependency Injection -- NotificationService + FakeEmailSender, written from scratch.
//
// Required classes and behavior:
//
//   IEmailSender — contract: Send(string to, string subject, string body).
//
//   FakeEmailSender — fulfills IEmailSender for testing.
//       Sent — a list of (To, Subject, Body) tuples capturing every call to Send.
//       Send(...) — appends to Sent (no real email is sent).
//
//   ConsoleEmailSender — fulfills IEmailSender for real use.
//       Send(...) — writes to stdout (e.g., "To: {to} | {subject}").
//
//   NotificationService — uses IEmailSender without knowing which implementation.
//       Constructor receives an IEmailSender (injected by the caller, not created here).
//       The sender is stored and cannot be reassigned after construction.
//       NotifyUser(string email, string eventName) — calls Send with:
//           Subject = "Notification: {eventName}"
//           Body    = "You have a new event: {eventName}"
//
// Key principle: NotificationService does NOT create a sender internally.

namespace Kata;

// Write your implementation below.
