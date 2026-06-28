// LINQ -- ProductQueries, written from scratch.
//
// Required API:
//
//   record Product(string Name, string Category, decimal Price, int Stock);
//
//   static class ProductQueries
//   {
//       InStock(products)              // Stock > 0
//       ByCategory(products, cat)      // Category == cat
//       CheaperThan(products, max)     // Price < max
//       Names(products)                // Select Name
//       TotalValue(products)           // Sum of Price * Stock
//       GroupByCategory(products)      // Dictionary<string, List<Product>>
//       TopNByPrice(products, n)       // OrderByDescending Price, Take n
//   }

namespace Kata;

// Write your implementation below.
