using log4net;
using System.Reflection;

namespace Epam.ReportPortal.Automation.Configuration.Logger
{
    public class LogConfiguration
    {
        public static void Setup()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            log4net.Config.XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
    }
}
