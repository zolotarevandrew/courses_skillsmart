using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Infrastructure.Kingdoms;

namespace KingdomStrategy.UseCases;

public interface IUseCase
{
    string Name { get; }
    int Command { get; }
    Task Run(string[] args);
}

public interface ILogWriter
{
    void Write(string str);
}

public class LogWriter : ILogWriter
{
    public void Write(string str)
    {
        Console.WriteLine(str);
    }
}

public abstract class ConsoleUseCase : IUseCase
{
    protected readonly ILogWriter LogWriter;

    protected ConsoleUseCase(ILogWriter logWriter)
    {
        LogWriter = logWriter;
    }
    public abstract string Name { get; }
    public abstract int Command { get; }
    public async Task Run(string[] args)
    {
        await InternalRun(args);
    }

    protected abstract Task InternalRun(string[] args);
}

public abstract class ByKingdomUseCase : ConsoleUseCase
{
    private readonly KingdomLoader _loader;
    public ByKingdomUseCase(KingdomLoader loader, ILogWriter logWriter) : base(logWriter)
    {
        _loader = loader;
    }
    protected override async Task InternalRun(string[] args)
    {
        var id = args[0];
        var kingdom = await _loader.GetByRef(new KingdomRef(id, ""));
        if (kingdom == null)
        {
            LogWriter.Write("Kingdom was not found");
            return;
        }
        await RunCase(kingdom);
    }
    
    protected abstract Task RunCase(Kingdom kingdom);
}

public abstract class KingdomUseCase
{
    protected abstract Task RunCase(Kingdom kingdom);

    protected async Task<Kingdom> GetOtherKingdom()
    {
        return null;
    }
    
    private async Task<Kingdom> GetKingdom()
    {
        throw new NotImplementedException();
    }
}