using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void IsPalindrome_Racecar_True()
    {
        Assert.True("racecar".IsPalindrome());
    }

    [Fact]
    public void IsPalindrome_CaseInsensitive()
    {
        Assert.True("Racecar".IsPalindrome());
    }

    [Fact]
    public void IsPalindrome_WithSpaces()
    {
        Assert.True("race car".IsPalindrome());
    }

    [Fact]
    public void IsPalindrome_Hello_False()
    {
        Assert.False("hello".IsPalindrome());
    }

    [Fact]
    public void Truncate_LongString_AddsEllipsis()
    {
        Assert.Equal("Hello...", "Hello World".Truncate(5));
    }

    [Fact]
    public void Truncate_ShortString_Unchanged()
    {
        Assert.Equal("Hi", "Hi".Truncate(10));
    }

    [Fact]
    public void WordCount_TwoWords()
    {
        Assert.Equal(2, "hello world".WordCount());
    }

    [Fact]
    public void WordCount_EmptyString_Zero()
    {
        Assert.Equal(0, "".WordCount());
    }

    [Fact]
    public void IsEven_Four_True()
    {
        Assert.True(4.IsEven());
    }

    [Fact]
    public void IsEven_Five_False()
    {
        Assert.False(5.IsEven());
    }

    [Fact]
    public void Times_Three_YieldsZeroOneTwo()
    {
        Assert.Equal(new[] { 0, 1, 2 }, 3.Times().ToArray());
    }
}
