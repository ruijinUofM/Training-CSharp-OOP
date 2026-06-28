namespace Kata;

interface IEmailSender
{
    void Send(string to, string subject, string body);
}

class FakeEmailSender : IEmailSender
{
    public List<(string To, string Subject, string Body)> Sent { get; } = new();
    public void Send(string to, string subject, string body)
        => Sent.Add((to, subject, body));
}

class ConsoleEmailSender : IEmailSender
{
    public void Send(string to, string subject, string body)
        => Console.WriteLine($"To: {to} | {subject}");
}

class NotificationService
{
    private readonly IEmailSender _sender;
    public NotificationService(IEmailSender sender) { _sender = sender; }

    public void NotifyUser(string email, string eventName)
        => _sender.Send(email, $"Notification: {eventName}", $"You have a new event: {eventName}");
}
