# 17. LINQ

## Feature

LINQ method syntax: `Where`, `Select`, `OrderBy`/`OrderByDescending`, `GroupBy`, `First`/`FirstOrDefault`, `Any`/`All`, `Sum`/`Average`, `Take`, `ToList`, `ToDictionary`.

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

## Things to watch for

- LINQ is lazy — `Where(...)` doesn't execute until you enumerate (call `ToList()`, `foreach`, etc.).
- `First()` throws if empty; `FirstOrDefault()` returns null for reference types.
- `GroupBy` returns `IEnumerable<IGrouping<TKey, TElement>>`. Each group has a `Key` and is itself enumerable.
- `Sum(p => p.Price * p.Stock)` works on `decimal` without casting.
- Method syntax (`.Where(...)`) and query syntax (`from p in products where ...`) produce the same result; method syntax is more common in modern C#.
- `ToDictionary` requires unique keys; `GroupBy` + `ToDictionary` is the pattern for multi-value groupings.
