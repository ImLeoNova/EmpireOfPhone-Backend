using EP.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace EP.Application.Services;

public class LoggerService(
    ILogger<LoggerService> logger
    ) : ILoggerService
{
    private string GetTime => DateTime.Now.ToString("yyyy-M-d H:mm:ss");
    
    public void Info(string name, string message)
    {
        logger.LogInformation($"[INFO]{name} : {message} at {GetTime}");
    }

    public void Warn(string name, string message)
    {
        logger.LogInformation($"[WARN]{name} : {message} at {GetTime}");
    }

    public void Error(string name, string message)
    {
        logger.LogInformation($"[ERROR]{name} : {message} at {GetTime}");
    }

    public void Success(string name, string message)
    {
        logger.LogInformation($"[ERROR]{name} : {message} at {GetTime}");
    }
}