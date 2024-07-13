using Domain.Ports;
using NLog;

namespace LogNLog;

public class NLogLogger : Domain.Ports.ILogger
{
    private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();
    static NLogLogger()
    {
        // Certifique-se de que o NLog leia a configuração do arquivo nlog.config
        LogManager.LoadConfiguration("nlog.config");
    }

    public void LogInfo(string message)
    {
        logger.Info(message);
    }

    public void LogError(string message, Exception ex)
    {
        logger.Error(ex, message);
    }
}
