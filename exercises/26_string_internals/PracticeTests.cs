using Xunit;

public class StringInternalsTests
{
    [Fact]
    public void ContentEqual_SameContent_True()
    {
        Assert.True(StringInternals.ContentEqual("hello", "hello"));
    }

    [Fact]
    public void ContentEqual_DifferentContent_False()
    {
        Assert.False(StringInternals.ContentEqual("hello", "world"));
    }

    [Fact]
    public void ReferenceEqual_SameLiteral_True()
    {
        string a = "interned";
        string b = "interned";
        Assert.True(StringInternals.ReferenceEqual(a, b));
    }

    [Fact]
    public void ReferenceEqual_NewString_False()
    {
        string a = "hello";
        string b = new string("hello".ToCharArray());
        Assert.False(StringInternals.ReferenceEqual(a, b));
    }

    [Fact]
    public void InternString_MakesSameReference()
    {
        string a = "hello";
        string b = new string("hello".ToCharArray());
        string interned = StringInternals.InternString(b);
        Assert.True(ReferenceEquals(a, interned));
    }

    [Fact]
    public void IsInterned_LiteralIsInterned()
    {
        Assert.True(StringInternals.IsInterned("hello"));
    }

    [Fact]
    public void ConcatWithPlus_MatchesBuilder()
    {
        Assert.Equal(
            StringInternals.ConcatWithPlus(10),
            StringInternals.ConcatWithBuilder(10));
    }
}
