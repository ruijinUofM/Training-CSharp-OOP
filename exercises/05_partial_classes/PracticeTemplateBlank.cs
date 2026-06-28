// Partial Classes -- CustomerOrder hand-written half, written from scratch.
//
// GeneratedPart.cs already declares:
//   public partial class CustomerOrder
//   {
//       public int OrderId { get; set; }
//       public string CustomerName { get; set; } = "";
//       public DateTimeOffset CreatedAt { get; init; }
//   }
//
// You add to the other partial in Practice.cs:
//   public partial class CustomerOrder
//   {
//       public List<string> Items { get; } = new();
//       public decimal Total => Items.Count * 9.99m;
//       public string Summary()
//           // "Order #{OrderId} for {CustomerName}: {Items.Count} item(s)"
//   }
//
// Notes:
//   - Both partials must be in namespace Kata; and be public partial class CustomerOrder.
//   - You can use OrderId/CustomerName in Practice.cs — they're on the same merged class.

namespace Kata;

// Write your implementation below.
