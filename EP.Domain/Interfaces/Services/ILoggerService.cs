namespace EP.Domain.Interfaces.Services;

public interface ILoggerService
{

    public void Info(string name, string message);
    
    public void Warn(string name, string message);
    
    public void Error(string name, string message);
    
    public void Success(string name, string message);
}