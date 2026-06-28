using Xunit;

public class StructVsClassTests
{
    [Fact]
    public void Structs_AreCopied_OnAssignment()
    {
        Assert.True(Demos.StructsAreCopied());
    }

    [Fact]
    public void Classes_AreShared_ByReference()
    {
        Assert.True(Demos.ClassesAreShared());
    }

    [Fact]
    public void Point_IsValueType()
    {
        Assert.True(Demos.IsValueType(typeof(Point)));
    }

    [Fact]
    public void Box_IsReferenceType()
    {
        Assert.True(Demos.IsReferenceType(typeof(Box)));
    }

    [Fact]
    public void Int_IsValueType()
    {
        Assert.True(Demos.IsValueType(typeof(int)));
    }

    [Fact]
    public void String_IsReferenceType()
    {
        Assert.True(Demos.IsReferenceType(typeof(string)));
    }
}
