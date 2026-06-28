namespace Kata;

interface IEmailSender
{
    void Send(string to, string subject, string body);
}

class FakeEmailSender : IEmailSender
{
    public List<(string To, string Subject, string Body)> Sent { get; } = new();
    public void Send(string to, string subject, string body) { throw new NotImplementedException(); }
}

class ConsoleEmailSender : IEmailSender
{
    public void Send(string to, string subject, string body) { throw new NotImplementedException(); }
}

class NotificationService
{
    private readonly IEmailSender _sender;
    public NotificationService(IEmailSender sender) { throw new NotImplementedException(); }
    public void NotifyUser(string email, string eventName) { throw new NotImplementedException(); }
}
