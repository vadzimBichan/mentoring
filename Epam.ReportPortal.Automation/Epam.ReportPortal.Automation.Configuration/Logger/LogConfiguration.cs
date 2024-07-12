using System.Reflection;
using log4net;
using log4net.Config;

namespace Epam.ReportPortal.Automation.Configuration.Logger;

public class LogConfiguration
{
    public static void Setup()
    {
        var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
    }
}