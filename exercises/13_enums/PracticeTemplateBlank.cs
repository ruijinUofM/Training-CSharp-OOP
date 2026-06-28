// Enums -- OrderStatus + Permission, written from scratch.
//
// Required API:
//
//   enum OrderStatus { Pending, Processing, Shipped, Delivered, Cancelled }
//
//   static class OrderStatusExtensions
//   {
//       public static bool IsTerminal(this OrderStatus s)
//           // true for Delivered and Cancelled
//
//       public static bool CanTransitionTo(this OrderStatus current, OrderStatus next)
//           // Pending->Processing, Processing->Shipped, Shipped->Delivered
//           // anything (not already terminal) -> Cancelled
//           // terminal states cannot transition anywhere
//   }
//
//   [Flags]
//   enum Permission { None = 0, Read = 1, Write = 2, Execute = 4 }

namespace Kata;

// Write your implementation below.
