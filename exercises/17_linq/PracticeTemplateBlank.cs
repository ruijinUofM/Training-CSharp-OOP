// LINQ -- ProductQueries, written from scratch.
//
// Required types and behavior:
//
//   Product — an immutable data type with four fields: Name (string), Category (string),
//       Price (decimal), Stock (int). Uses value equality. (Look up the C# syntax that
//       lets you declare this concisely with auto-generated equality and deconstruction.)
//
//   ProductQueries — static class with LINQ-based query methods:
//       InStock(products) — products where Stock > 0.
//       ByCategory(products, cat) — products where Category == cat.
//       CheaperThan(products, max) — products where Price < max.
//       Names(products) — sequence of product names (strings).
//       TotalValue(products) → decimal — sum of Price * Stock across all products.
//       GroupByCategory(products) → Dictionary<string, List<Product>> — maps
//           each category to the list of products in it.
//       TopNByPrice(products, n) — top N products by price (highest first).

namespace Kata;

// Write your implementation below.
