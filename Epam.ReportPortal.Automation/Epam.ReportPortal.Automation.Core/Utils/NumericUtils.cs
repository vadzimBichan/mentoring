namespace Epam.ReportPortal.Automation.Core.Utils;

public class NumericUtils
{
    public const int KB = 1024;
    public const int MB = KB * 1024;
    public const int GB = MB * 1024;

    public static int GetRandomInt(int min = 0, int max = Int32.MaxValue)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
}