using Xunit;

public static class GcDemos
{
    public static int GetGeneration(object obj) => GC.GetGeneration(obj);

    public static void CollectAll()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }

    public static long TotalMemory(bool collect) => GC.GetTotalMemory(collect);

    public static bool IsAlive<T>(WeakReference<T> wr) where T : class
        => wr.TryGetTarget(out _);

    public static WeakReference<T> MakeWeak<T>(T obj) where T : class
        => new WeakReference<T>(obj);

    public static int LohThresholdBytes => 85_000;
}
