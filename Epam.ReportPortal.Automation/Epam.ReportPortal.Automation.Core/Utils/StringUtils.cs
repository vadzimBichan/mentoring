namespace Epam.ReportPortal.Automation.Core.Utils;

public class StringUtils
{
    public static string GenerateRandomString(int targetLength)
    {
        var result = string.Empty;

        while (result.Length < targetLength)
        {
            result += Guid.NewGuid().ToString("N");
        }

        if (result.Length > targetLength)
        {
            result = result.Substring(0, targetLength);
        }

        return result;
    }
}