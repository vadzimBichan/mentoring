namespace Epam.ReportPortal.Automation.Core.Logger
{
    public interface ILoggerService
    {
        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);
        void Fatal(string message);
    }
}
