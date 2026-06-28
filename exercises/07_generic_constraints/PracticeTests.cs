using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void Max_Int_ReturnsLarger()
    {
        Assert.Equal(5, Algorithms.Max(3, 5));
    }

    [Fact]
    public void Max_String_ReturnsLarger()
    {
        Assert.Equal("banana", Algorithms.Max("apple", "banana"));
    }

    [Fact]
    public void Max_EqualValues_ReturnsValue()
    {
        Assert.Equal(7, Algorithms.Max(7, 7));
    }

    [Fact]
    public void AreEqual_SameInts_ReturnsTrue()
    {
        Assert.True(Algorithms.AreEqual(42, 42));
    }

    [Fact]
    public void AreEqual_DifferentInts_ReturnsFalse()
    {
        Assert.False(Algorithms.AreEqual(1, 2));
    }

    [Fact]
    public void Repository_Create_ReturnsInstance()
    {
        var repo = new Repository<List<int>>();
        var item = repo.Create();
        Assert.NotNull(item);
    }

    [Fact]
    public void Repository_Add_And_FindAll()
    {
        var repo = new Repository<List<int>>();
        var list = new List<int> { 1, 2 };
        repo.Add(list);
        Assert.Single(repo.FindAll());
    }

    [Fact]
    public void Repository_Count_IsCorrect()
    {
        var repo = new Repository<List<int>>();
        repo.Add(new List<int>());
        repo.Add(new List<int>());
        Assert.Equal(2, repo.Count);
    }
}
