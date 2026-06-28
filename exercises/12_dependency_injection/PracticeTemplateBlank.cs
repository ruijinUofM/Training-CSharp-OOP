// Dependency Injection -- NotificationService + FakeEmailSender, written from scratch.
//
// Required API:
//
//   interface IEmailSender { void Send(string to, string subject, string body); }
//
//   class FakeEmailSender : IEmailSender
//   {
//       public List<(string To, string Subject, string Body)> Sent { get; } = new();
//       public void Send(...)  // appends to Sent
//   }
//
//   class ConsoleEmailSender : IEmailSender
//   {
//       public void Send(...)  // Console.WriteLine to stdout
//   }
//
//   class NotificationService
//   {
//       public NotificationService(IEmailSender sender)
//       public void NotifyUser(string email, string eventName)
//           // Subject = "Notification: {eventName}"
//           // Body    = "You have a new event: {eventName}"
//   }
//
// Key principle: NotificationService does NOT create a sender internally.

namespace Kata;

// Write your implementation below.
