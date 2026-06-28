namespace Kata;

record Product(string Name, string Category, decimal Price, int Stock);

static class ProductQueries
{
    public static IEnumerable<Product> InStock(IEnumerable<Product> products) { throw new NotImplementedException(); }
    public static IEnumerable<Product> ByCategory(IEnumerable<Product> products, string category) { throw new NotImplementedException(); }
    public static IEnumerable<Product> CheaperThan(IEnumerable<Product> products, decimal maxPrice) { throw new NotImplementedException(); }
    public static IEnumerable<string> Names(IEnumerable<Product> products) { throw new NotImplementedException(); }
    public static decimal TotalValue(IEnumerable<Product> products) { throw new NotImplementedException(); }
    public static Dictionary<string, List<Product>> GroupByCategory(IEnumerable<Product> products) { throw new NotImplementedException(); }
    public static IEnumerable<Product> TopNByPrice(IEnumerable<Product> products, int n) { throw new NotImplementedException(); }
}
