namespace Kata;

abstract class Logger
{
    public abstract void Log(string message);
    public string LastMessage { get; protected set; } = "";
}

class ConsoleLogger : Logger
{
    public override void Log(string message)
    {
        LastMessage = message;
        Console.WriteLine($"[Console] {message}");
    }
}

sealed class FileLogger : Logger
{
    public string FilePath { get; }
    public FileLogger(string filePath) { FilePath = filePath; }

    public override void Log(string message)
    {
        LastMessage = message;
        // In production this would write to FilePath
    }
}
