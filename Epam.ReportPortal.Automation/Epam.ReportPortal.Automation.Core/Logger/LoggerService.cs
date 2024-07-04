namespace Epam.ReportPortal.Automation.Core.Logger
{
    public class LoggerService : ILoggerService
    {
        private readonly log4net.ILog _log;

        public LoggerService(Type type)
        {
            _log = log4net.LogManager.GetLogger(type);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Warn(string message)
        {
            _log.Warn(message);
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Fatal(string message)
        {
            _log.Fatal(message);
        }
    }
}
