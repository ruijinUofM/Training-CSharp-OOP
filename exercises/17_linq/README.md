# 17. LINQ

## Feature

LINQ method syntax: `Where`, `Select`, `OrderBy`/`OrderByDescending`, `GroupBy`, `First`/`FirstOrDefault`, `Any`/`All`, `Sum`/`Average`, `Take`, `ToList`, `ToDictionary`.

## When to use it / When to avoid it

LINQ exists to let you describe *what* transformation you want over a collection (filter, project, group, aggregate) instead of *how* to loop and accumulate it by hand — and the same query syntax works whether the source is in-memory or translated to SQL (EF Core).

- **Use it when**: filtering/mapping/aggregating in-memory collections, or building composable queries against a data source that translates the expression tree (like EF Core).
- **Avoid it when**: you're in an extremely hot, allocation-sensitive loop where the iterator and lambda overhead actually shows up in profiling — a plain `for` loop can be meaningfully faster there. Also avoid chaining so many operators that the query becomes harder to read than the explicit loop it replaced.

## Case study

`Product` record with Name, Category, Price, Stock. `ProductQueries` static class with methods that each perform a LINQ query.

## Required types and behavior

- **Product** — an immutable data type with four fields: Name (string), Category (string), Price (decimal), Stock (int). Uses value equality. (Look up the C# syntax for declaring this concisely with auto-generated equality and deconstruction.)

- **ProductQueries** — static class with LINQ-based query methods:
  - `InStock(products)` — products where Stock > 0.
  - `ByCategory(products, cat)` — products where Category == cat.
  - `CheaperThan(products, max)` — products where Price < max.
  - `Names(products)` → sequence of strings — product names.
  - `TotalValue(products)` → decimal — sum of Price * Stock across all products.
  - `GroupByCategory(products)` → `Dictionary<string, List<Product>>` — maps each category to its products.
  - `TopNByPrice(products, n)` — top N products by price (highest first).

## Syntax hint

<details>
<summary>Click to reveal C# syntax</summary>

```csharp
record Item(string Name, string Category, decimal Price, int Stock);

static class ItemQueries
{
    public static IEnumerable<Item> InStock(IEnumerable<Item> items)
        => items.Where(i => i.Stock > 0);

    public static IEnumerable<string> Names(IEnumerable<Item> items)
        => items.Select(i => i.Name);

    public static decimal TotalValue(IEnumerable<Item> items)
        => items.Sum(i => i.Price * i.Stock);

    // GroupBy → each group has a Key and is itself enumerable
    public static Dictionary<string, List<Item>> GroupByCategory(IEnumerable<Item> items)
        => items.GroupBy(i => i.Category)
                .ToDictionary(g => g.Key, g => g.ToList());

    public static IEnumerable<Item> TopNByPrice(IEnumerable<Item> items, int n)
        => items.OrderByDescending(i => i.Price).Take(n);
}

// method syntax chains left-to-right; LINQ is lazy until enumerated (.ToList(), foreach, etc.)
var cheapNames = items.Where(i => i.Price < 10).Select(i => i.Name).ToList();
```

</details>

## Things to watch for

- LINQ is lazy — `Where(...)` doesn't execute until you enumerate (call `ToList()`, `foreach`, etc.).
- `First()` throws if empty; `FirstOrDefault()` returns null for reference types.
- `GroupBy` returns `IEnumerable<IGrouping<TKey, TElement>>`. Each group has a `Key` and is itself enumerable.
- `Sum(p => p.Price * p.Stock)` works on `decimal` without casting.
- Method syntax (`.Where(...)`) and query syntax (`from p in products where ...`) produce the same result; method syntax is more common in modern C#.
- `ToDictionary` requires unique keys; `GroupBy` + `ToDictionary` is the pattern for multi-value groupings.
