using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void GetDisplayName_ReturnsName()
    {
        var u = new UserProfile { Name = "Alice" };
        Assert.Equal("Alice", u.GetDisplayName());
    }

    [Fact]
    public void GetBio_WithBio_ReturnsBio()
    {
        var u = new UserProfile { Name = "Bob", Bio = "I write code." };
        Assert.Equal("I write code.", u.GetBio());
    }

    [Fact]
    public void GetBio_NullBio_ReturnsDefault()
    {
        var u = new UserProfile { Name = "Carol" };
        Assert.Equal("No bio provided", u.GetBio());
    }

    [Fact]
    public void GetBioLength_NullBio_ReturnsZero()
    {
        var u = new UserProfile { Name = "Dave" };
        Assert.Equal(0, u.GetBioLength());
    }

    [Fact]
    public void GetBioLength_WithBio_ReturnsLength()
    {
        var u = new UserProfile { Name = "Eve", Bio = "Hello" };
        Assert.Equal(5, u.GetBioLength());
    }

    [Fact]
    public void FindUser_Found()
    {
        var users = new List<UserProfile> { new() { Name = "Alice" }, new() { Name = "Bob" } };
        var result = UserHelpers.FindUser(users, "Bob");
        Assert.NotNull(result);
        Assert.Equal("Bob", result.Name);
    }

    [Fact]
    public void FindUser_NotFound_ReturnsNull()
    {
        var users = new List<UserProfile> { new() { Name = "Alice" } };
        Assert.Null(UserHelpers.FindUser(users, "Charlie"));
    }

    [Fact]
    public void GetUpperName_NullProfile_ReturnsUnknown()
    {
        Assert.Equal("UNKNOWN", UserHelpers.GetUpperName(null));
    }

    [Fact]
    public void GetUpperName_ValidProfile_ReturnsUpperName()
    {
        var u = new UserProfile { Name = "alice" };
        Assert.Equal("ALICE", UserHelpers.GetUpperName(u));
    }
}
