// Enums -- OrderStatus + Permission, written from scratch.
//
// Required types and behavior:
//
//   OrderStatus — a named, discrete set of states: Pending, Processing, Shipped,
//       Delivered, Cancelled.
//       (C# has a specific keyword for declaring a type that represents a set of named constants.)
//
//   OrderStatusExtensions — methods callable directly on OrderStatus values.
//       IsTerminal(OrderStatus) → bool — called as s.IsTerminal(); true for
//           Delivered and Cancelled.
//       CanTransitionTo(OrderStatus current, OrderStatus next) → bool — called as
//           current.CanTransitionTo(next); valid transitions:
//           Pending → Processing, Processing → Shipped, Shipped → Delivered,
//           anything (non-terminal) → Cancelled; terminal states: no valid transitions.
//
//   Permission — a set of bit-flag values that can be combined with bitwise OR.
//       Values: None=0, Read=1, Write=2, Execute=4.
//       Requires a specific attribute on the type to enable bitwise combination semantics.

namespace Kata;

// Write your implementation below.
