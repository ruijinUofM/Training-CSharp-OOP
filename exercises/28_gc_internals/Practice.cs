using Xunit;

public static class GcDemos
{
    // Get the GC generation of an object (0, 1, or 2)
    public static int GetGeneration(object obj)
    {
        throw new NotImplementedException();
    }

    // Force a full collection and wait for finalizers
    public static void CollectAll()
    {
        throw new NotImplementedException();
    }

    // Get total managed memory (optionally forcing a collection first)
    public static long TotalMemory(bool collect)
    {
        throw new NotImplementedException();
    }

    // Return true if the weak reference target is still alive
    public static bool IsAlive<T>(WeakReference<T> wr) where T : class
    {
        throw new NotImplementedException();
    }

    // Create a weak reference to obj
    public static WeakReference<T> MakeWeak<T>(T obj) where T : class
    {
        throw new NotImplementedException();
    }

    // Objects >= this size go to the Large Object Heap
    public static int LohThresholdBytes => 85_000;
}
