using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void NotifyUser_SendsEmail()
    {
        var fake = new FakeEmailSender();
        var svc = new NotificationService(fake);
        svc.NotifyUser("alice@example.com", "login");
        Assert.Single(fake.Sent);
    }

    [Fact]
    public void NotifyUser_SubjectContainsEvent()
    {
        var fake = new FakeEmailSender();
        new NotificationService(fake).NotifyUser("x@y.com", "purchase");
        Assert.Contains("purchase", fake.Sent[0].Subject);
    }

    [Fact]
    public void NotifyUser_BodyContainsEvent()
    {
        var fake = new FakeEmailSender();
        new NotificationService(fake).NotifyUser("x@y.com", "signup");
        Assert.Contains("signup", fake.Sent[0].Body);
    }

    [Fact]
    public void NotifyUser_ToAddressIsCorrect()
    {
        var fake = new FakeEmailSender();
        new NotificationService(fake).NotifyUser("bob@example.com", "e");
        Assert.Equal("bob@example.com", fake.Sent[0].To);
    }

    [Fact]
    public void FakeEmailSender_StartsEmpty()
    {
        Assert.Empty(new FakeEmailSender().Sent);
    }

    [Fact]
    public void ConsoleEmailSender_DoesNotThrow()
    {
        var svc = new NotificationService(new ConsoleEmailSender());
        var ex = Record.Exception(() => svc.NotifyUser("t@t.com", "test"));
        Assert.Null(ex);
    }
}
