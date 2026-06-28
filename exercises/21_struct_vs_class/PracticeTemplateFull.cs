using Xunit;

// Value type: copied on assignment; stored inline / on stack for locals
public struct Point
{
    public int X;
    public int Y;
    public Point(int x, int y) { X = x; Y = y; }
}

// Reference type: heap-allocated; variable holds a reference (pointer)
public class Box
{
    public int Value { get; set; }
    public Box(int value) { Value = value; }
}

public static class Demos
{
    // Demonstrate that structs are copied on assignment
    public static bool StructsAreCopied()
    {
        throw new NotImplementedException();
        // Point a = new Point(1, 2);
        // Point b = a;     // copy
        // b.X = 99;
        // return a.X == 1; // true: a was NOT modified
    }

    // Demonstrate that class instances are shared via references
    public static bool ClassesAreShared()
    {
        throw new NotImplementedException();
        // Box a = new Box(1);
        // Box b = a;       // same object
        // b.Value = 99;
        // return a.Value == 99; // true: a WAS modified through b
    }

    public static bool IsValueType(Type t) => throw new NotImplementedException();
    public static bool IsReferenceType(Type t) => throw new NotImplementedException();
}
