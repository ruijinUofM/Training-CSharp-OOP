namespace Kata;

abstract class Logger
{
    public abstract void Log(string message);
    public string LastMessage { get; protected set; } = "";
}

class ConsoleLogger : Logger
{
    public override void Log(string message) { throw new NotImplementedException(); }
}

sealed class FileLogger : Logger
{
    public string FilePath { get; }
    public FileLogger(string filePath) { throw new NotImplementedException(); }
    public override void Log(string message) { throw new NotImplementedException(); }
}
