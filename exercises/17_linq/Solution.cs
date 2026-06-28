namespace Kata;

record Product(string Name, string Category, decimal Price, int Stock);

static class ProductQueries
{
    public static IEnumerable<Product> InStock(IEnumerable<Product> products)
        => products.Where(p => p.Stock > 0);

    public static IEnumerable<Product> ByCategory(IEnumerable<Product> products, string category)
        => products.Where(p => p.Category == category);

    public static IEnumerable<Product> CheaperThan(IEnumerable<Product> products, decimal maxPrice)
        => products.Where(p => p.Price < maxPrice);

    public static IEnumerable<string> Names(IEnumerable<Product> products)
        => products.Select(p => p.Name);

    public static decimal TotalValue(IEnumerable<Product> products)
        => products.Sum(p => p.Price * p.Stock);

    public static Dictionary<string, List<Product>> GroupByCategory(IEnumerable<Product> products)
        => products.GroupBy(p => p.Category)
                   .ToDictionary(g => g.Key, g => g.ToList());

    public static IEnumerable<Product> TopNByPrice(IEnumerable<Product> products, int n)
        => products.OrderByDescending(p => p.Price).Take(n);
}
