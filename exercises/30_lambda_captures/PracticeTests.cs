using Xunit;

public class LambdaCapturesTests
{
    [Fact]
    public void MakeMultiplier_MultipliesCorrectly()
    {
        var triple = LambdaDemos.MakeMultiplier(3);
        Assert.Equal(15, triple(5));
    }

    [Fact]
    public void LateBuggy_AllReturnFinalValue()
    {
        var fns = LambdaDemos.LateBuggy();
        // After the loop, i == 3; all closures share the same field
        var results = fns.Select(f => f()).ToList();
        Assert.All(results, r => Assert.Equal(3, r));
    }

    [Fact]
    public void LateFixed_ReturnDistinctValues()
    {
        var fns = LambdaDemos.LateFixed();
        Assert.Equal(0, fns[0]());
        Assert.Equal(1, fns[1]());
        Assert.Equal(2, fns[2]());
    }

    [Fact]
    public void MakeCounter_Increments()
    {
        var counter = LambdaDemos.MakeCounter();
        Assert.Equal(1, counter());
        Assert.Equal(2, counter());
        Assert.Equal(3, counter());
    }

    [Fact]
    public void MakeCounter_WithStart()
    {
        var counter = LambdaDemos.MakeCounter(10);
        Assert.Equal(11, counter());
    }

    [Fact]
    public void TwoCounters_AreIndependent()
    {
        var a = LambdaDemos.MakeCounter();
        var b = LambdaDemos.MakeCounter(5);
        a(); a();
        Assert.Equal(6, b()); // b is independent
    }

    [Fact]
    public void Compose_AppliesInOrder()
    {
        Func<int, int> addOne = x => x + 1;
        Func<int, int> double_ = x => x * 2;
        var addOneThenDouble = LambdaDemos.Compose(double_, addOne); // double(addOne(x))
        Assert.Equal(8, addOneThenDouble(3)); // (3+1)*2
    }
}
