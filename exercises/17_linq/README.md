# 17. LINQ

## Feature

LINQ method syntax: `Where`, `Select`, `OrderBy`/`OrderByDescending`, `GroupBy`, `First`/`FirstOrDefault`, `Any`/`All`, `Sum`/`Average`, `Take`, `ToList`, `ToDictionary`.

## Case study

`Product` record with Name, Category, Price, Stock. `ProductQueries` static class with methods that each perform a LINQ query.

## Required API

```csharp
record Product(string Name, string Category, decimal Price, int Stock);

static class ProductQueries
{
    public static IEnumerable<Product> InStock(IEnumerable<Product> products)
    // Where(p => p.Stock > 0)

    public static IEnumerable<Product> ByCategory(IEnumerable<Product> products, string category)
    // Where(p => p.Category == category)

    public static IEnumerable<Product> CheaperThan(IEnumerable<Product> products, decimal maxPrice)
    // Where(p => p.Price < maxPrice)

    public static IEnumerable<string> Names(IEnumerable<Product> products)
    // Select(p => p.Name)

    public static decimal TotalValue(IEnumerable<Product> products)
    // Sum(p => p.Price * p.Stock)

    public static Dictionary<string, List<Product>> GroupByCategory(IEnumerable<Product> products)
    // GroupBy then ToDictionary

    public static IEnumerable<Product> TopNByPrice(IEnumerable<Product> products, int n)
    // OrderByDescending(p => p.Price).Take(n)
}
```

## Things to watch for

- LINQ is lazy — `Where(...)` doesn't execute until you enumerate (call `ToList()`, `foreach`, etc.).
- `First()` throws if empty; `FirstOrDefault()` returns null for reference types.
- `GroupBy` returns `IEnumerable<IGrouping<TKey, TElement>>`. Each group has a `Key` and is itself enumerable.
- `Sum(p => p.Price * p.Stock)` works on `decimal` without casting.
- Method syntax (`.Where(...)`) and query syntax (`from p in products where ...`) produce the same result; method syntax is more common in modern C#.
- `ToDictionary` requires unique keys; `GroupBy` + `ToDictionary` is the pattern for multi-value groupings.
