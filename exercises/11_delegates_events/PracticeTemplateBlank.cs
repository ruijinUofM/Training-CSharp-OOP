// Delegates and Events -- Button + Counter, written from scratch.
//
// Required API:
//
//   class Button
//   {
//       public event EventHandler? Clicked;
//       public void Click()   // Clicked?.Invoke(this, EventArgs.Empty)
//   }
//
//   class Counter
//   {
//       public int Count { get; private set; }
//       public event Action<int>? CountChanged;
//       public void Increment()   // Count++, then CountChanged?.Invoke(Count)
//   }
//
// Behavior notes:
//   - EventHandler is delegate void(object sender, EventArgs e)
//   - Use += to subscribe, -= to unsubscribe
//   - CountChanged fires with the NEW count value

namespace Kata;

// Write your implementation below.
