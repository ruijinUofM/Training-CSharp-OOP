using Xunit;

namespace Kata;

public class PracticeTests
{
    [Fact]
    public void FileLogger_IsSealed()
    {
        Assert.True(typeof(FileLogger).IsSealed);
    }

    [Fact]
    public void ConsoleLogger_IsNotSealed()
    {
        Assert.False(typeof(ConsoleLogger).IsSealed);
    }

    [Fact]
    public void FileLogger_Log_SetsLastMessage()
    {
        var logger = new FileLogger("/tmp/test.log");
        logger.Log("hello");
        Assert.Equal("hello", logger.LastMessage);
    }

    [Fact]
    public void ConsoleLogger_Log_SetsLastMessage()
    {
        var logger = new ConsoleLogger();
        logger.Log("world");
        Assert.Equal("world", logger.LastMessage);
    }

    [Fact]
    public void FileLogger_FilePath_IsSet()
    {
        var logger = new FileLogger("/var/log/app.log");
        Assert.Equal("/var/log/app.log", logger.FilePath);
    }

    [Fact]
    public void Logger_IsAbstract()
    {
        Assert.True(typeof(Logger).IsAbstract);
    }
}
