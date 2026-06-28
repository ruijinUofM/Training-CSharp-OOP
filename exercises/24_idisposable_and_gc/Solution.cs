using Xunit;

public class DisposableLog : IDisposable
{
    public bool IsDisposed { get; private set; }
    public static List<string> Log { get; } = new();
    public string Name { get; }

    public DisposableLog(string name)
    {
        Name = name;
    }

    public void Dispose()
    {
        IsDisposed = true;
        Log.Add($"disposed:{Name}");
        GC.SuppressFinalize(this);
    }

    public static void ResetLog() => Log.Clear();
}

public static class DisposeDemos
{
    public static void UseWithUsing(string name)
    {
        using (var r = new DisposableLog(name))
        {
            // resource is in scope here
        }
        // Dispose() was called automatically on block exit
    }

    public static bool IsDisposedAfterUsing(string name)
    {
        DisposableLog r;
        using (r = new DisposableLog(name))
        {
            // inside block: not yet disposed
        }
        return r.IsDisposed; // true
    }
}
