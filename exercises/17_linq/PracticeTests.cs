using Xunit;

namespace Kata;

public class PracticeTests
{
    private static List<Product> SampleProducts() => new()
    {
        new("Widget", "Hardware", 9.99m, 100),
        new("Gadget", "Electronics", 49.99m, 5),
        new("Doohickey", "Hardware", 4.99m, 0),
        new("Thingamajig", "Electronics", 99.99m, 20),
        new("Gizmo", "Software", 19.99m, 50),
    };

    [Fact]
    public void InStock_ExcludesZeroStock()
    {
        var result = ProductQueries.InStock(SampleProducts()).ToList();
        Assert.Equal(4, result.Count);
        Assert.DoesNotContain(result, p => p.Name == "Doohickey");
    }

    [Fact]
    public void ByCategory_FiltersCorrectly()
    {
        var result = ProductQueries.ByCategory(SampleProducts(), "Electronics").ToList();
        Assert.Equal(2, result.Count);
        Assert.All(result, p => Assert.Equal("Electronics", p.Category));
    }

    [Fact]
    public void CheaperThan_FiltersCorrectly()
    {
        var result = ProductQueries.CheaperThan(SampleProducts(), 20m).ToList();
        Assert.All(result, p => Assert.True(p.Price < 20m));
    }

    [Fact]
    public void Names_ReturnsAllNames()
    {
        var names = ProductQueries.Names(SampleProducts()).ToList();
        Assert.Equal(5, names.Count);
        Assert.Contains("Widget", names);
    }

    [Fact]
    public void TotalValue_IsCorrect()
    {
        // Widget: 9.99*100=999, Gadget: 49.99*5=249.95, Doohickey: 0, Thingamajig: 99.99*20=1999.8, Gizmo: 19.99*50=999.5
        var expected = 9.99m * 100 + 49.99m * 5 + 99.99m * 20 + 19.99m * 50;
        Assert.Equal(expected, ProductQueries.TotalValue(SampleProducts()));
    }

    [Fact]
    public void GroupByCategory_HasThreeGroups()
    {
        var groups = ProductQueries.GroupByCategory(SampleProducts());
        Assert.Equal(3, groups.Count);
        Assert.True(groups.ContainsKey("Hardware"));
        Assert.Equal(2, groups["Hardware"].Count);
    }

    [Fact]
    public void TopNByPrice_ReturnsNHighestPriced()
    {
        var top2 = ProductQueries.TopNByPrice(SampleProducts(), 2).ToList();
        Assert.Equal(2, top2.Count);
        Assert.Equal("Thingamajig", top2[0].Name);
    }
}
