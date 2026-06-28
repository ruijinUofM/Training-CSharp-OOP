using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void ValidForm_NoErrors()
    {
        var form = new UserForm { Name = "Alice", Email = "alice@example.com" };
        Assert.Empty(FormValidator.Validate(form));
    }

    [Fact]
    public void ShortName_ReturnsError()
    {
        var form = new UserForm { Name = "A", Email = "alice@example.com" };
        var errors = FormValidator.Validate(form);
        Assert.Contains(errors, e => e.Contains("Name") && e.Contains("short"));
    }

    [Fact]
    public void NullName_ReturnsError()
    {
        var form = new UserForm { Name = null, Email = "alice@example.com" };
        var errors = FormValidator.Validate(form);
        Assert.Contains(errors, e => e.Contains("Name"));
    }

    [Fact]
    public void LongEmail_ReturnsError()
    {
        var form = new UserForm { Name = "Alice", Email = new string('x', 101) };
        var errors = FormValidator.Validate(form);
        Assert.Contains(errors, e => e.Contains("Email") && e.Contains("long"));
    }

    [Fact]
    public void MultipleErrors_Collected()
    {
        var form = new UserForm { Name = "A", Email = "hi" };
        var errors = FormValidator.Validate(form);
        Assert.Equal(2, errors.Count);
    }

    [Fact]
    public void ValidateAttribute_IsSealed_False()
    {
        // Attribute itself doesn't need to be sealed
        Assert.False(typeof(ValidateAttribute).IsSealed);
    }

    [Fact]
    public void ValidateAttribute_MinMaxLength_IsCorrect()
    {
        var attr = new ValidateAttribute(3, 10);
        Assert.Equal(3, attr.MinLength);
        Assert.Equal(10, attr.MaxLength);
    }
}
