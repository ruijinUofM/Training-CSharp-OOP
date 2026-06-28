using Xunit;

public class DisposableLog : IDisposable
{
    public bool IsDisposed { get; private set; }
    public static List<string> Log { get; } = new();
    public string Name { get; }

    public DisposableLog(string name)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
        // set IsDisposed = true
        // Log.Add($"disposed:{Name}");
    }

    public static void ResetLog() => Log.Clear();
}

public static class DisposeDemos
{
    // Create DisposableLog inside a using block, demonstrating deterministic cleanup
    public static void UseWithUsing(string name)
    {
        throw new NotImplementedException();
    }

    // Demonstrates that the resource is disposed after the using block
    public static bool IsDisposedAfterUsing(string name)
    {
        throw new NotImplementedException();
    }
}
