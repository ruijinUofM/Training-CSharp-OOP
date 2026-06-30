// Partial Classes -- CustomerOrder hand-written half, written from scratch.
//
// GeneratedPart.cs already declares half of CustomerOrder with:
//   OrderId (int), CustomerName (string), CreatedAt (DateTimeOffset).
//
// You write the second half of CustomerOrder in Practice.cs:
//   - Declare it as the other half of the same class that lives in GeneratedPart.cs.
//   - Items (List<string>) — a list of item names; the reference is read-only;
//       starts empty.
//   - Total (decimal, computed) — Items.Count * 9.99m.
//   - Summary() → string — "Order #{OrderId} for {CustomerName}: {Items.Count} item(s)";
//       you can reference OrderId and CustomerName from the other half.
//
// Notes:
//   - Both halves must share the same class name and be in namespace Kata.
//   - The compiler merges both halves into one class at compile time.

namespace Kata;

// Write your implementation below.
