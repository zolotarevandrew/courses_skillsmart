using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace h_work.lesson13.example2;

public interface IOnboardingContext
{
    Guid Id { get; }
}
public class Before
{
    private readonly ILogger<Before> _logger;

    public Before(ILogger<Before> logger)
    {
        _logger = logger;
    }
    public async Task Log(IOnboardingContext context, string message)
    {
        Exception? e = null;
        var watch = Stopwatch.StartNew();
        try
        {
            //some operation
        }
        catch (Exception ex)
        {
            e = ex;
        }
        finally
        {
            watch.Stop();
            LogMessage(context, e, watch, message);
        }
    }
    
    void LogMessage(IOnboardingContext context, Exception? ex, Stopwatch watch, string message)
    {
        if (ex != null)
        {
            _logger.LogError(ex, "{message} Error while processing onboarding {Id} {Elapsed}", message, context.Id, watch.ElapsedMilliseconds);
            return;
        }
        
        _logger.LogInformation(ex, "{message} while processing onboarding {Id} {Elapsed}", message, context.Id, watch.ElapsedMilliseconds);
    }
}