using Xunit;

// Lambda Captures and Closure Classes
//
// Capturing a variable in a lambda → compiler creates a heap-allocated display class
// with the variable as a field. The lambda IS a method on that class.
// Late-binding bug: all lambdas in a for loop share one 'i' field (one closure).
// Fix: create a new local each iteration so each lambda gets its own closure.
// foreach in C# 6+ does NOT have this bug (loop var is fresh each iteration).
//
// Implement:
//   public static class LambdaDemos {
//       public static Func<int,int> MakeMultiplier(int factor);
//           // return x => x * factor;
//       public static List<Func<int>> LateBuggy();
//           // for(int i=0;i<3;i++) fns.Add(()=>i); — all return 3
//       public static List<Func<int>> LateFixed();
//           // for(int i=0;i<3;i++){ int c=i; fns.Add(()=>c); } — return 0,1,2
//       public static Func<int> MakeCounter(int start=0);
//           // int count=start; return ()=>++count;
//       public static Func<int,int> Compose(Func<int,int> f, Func<int,int> g);
//           // return x=>f(g(x));
//   }

// Write your implementation below.
