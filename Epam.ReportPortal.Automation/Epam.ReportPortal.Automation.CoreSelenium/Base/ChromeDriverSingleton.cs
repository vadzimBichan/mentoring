using OpenQA.Selenium.Chrome;

namespace Epam.ReportPortal.Automation.CoreSelenium.Base
{
    public class ChromeDriverSingleton
    {
        private static ChromeDriver instace = null;
        private static readonly object lockObj = new object();

        private ChromeDriverSingleton() { }

        public static ChromeDriver Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instace == null)
                    {
                        instace = new ChromeDriver();
                        instace.Manage().Window.Maximize();
                    }

                    return instace;
                }
            }
        }
    }
}
