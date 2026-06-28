using Xunit;
using System.Text;

public static class StringInternals
{
    // Value equality: same characters
    public static bool ContentEqual(string a, string b)
    {
        throw new NotImplementedException();
    }

    // Reference equality: same object in memory
    public static bool ReferenceEqual(string a, string b)
    {
        throw new NotImplementedException();
    }

    // Explicitly add a string to the intern pool and return the canonical copy
    public static string InternString(string s)
    {
        throw new NotImplementedException();
    }

    // Returns true if the string is already in the intern pool
    public static bool IsInterned(string s)
    {
        throw new NotImplementedException();
    }

    // Concatenate 0..n-1 using + operator (creates n new string objects)
    public static string ConcatWithPlus(int n)
    {
        throw new NotImplementedException();
    }

    // Concatenate 0..n-1 using StringBuilder (single allocation)
    public static string ConcatWithBuilder(int n)
    {
        throw new NotImplementedException();
    }
}
