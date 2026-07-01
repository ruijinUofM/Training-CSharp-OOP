using Xunit;

// Lambda Captures and Closure Classes
//
// Implement (all in static class LambdaDemos):
//   MakeMultiplier(int factor) → (int → int) — returns a function that multiplies
//       its argument by factor; closes over factor.
//   LateBuggy() → list of (() → int) — 3 lambdas capturing the same for-loop counter;
//       all return 3 after the loop ends (demonstrates the classic capture bug).
//   LateFixed() → list of (() → int) — 3 lambdas each capturing their own copy of the
//       loop variable; return 0, 1, 2 respectively.
//   MakeCounter(int start = 0) → (() → int) — each invocation increments and returns a
//       shared counter starting at start (closes over a mutable local).
//   Compose(f, g) → (int → int) — returns a new function that applies g then f: x → f(g(x)).

// Write your implementation below.
