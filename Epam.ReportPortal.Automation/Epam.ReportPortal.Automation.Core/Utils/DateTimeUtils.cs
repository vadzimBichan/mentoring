namespace Epam.ReportPortal.Automation.Core.Utils;

public class DateTimeUtils
{
    public const int SECOND = 1000;
    public const int MINUTE = 60 * SECOND;

    public static string GetDateTimeString()
    {
        return $"{DateTime.Now:yy_MM-dd_hh-mm-ss-fff}";
    }
}