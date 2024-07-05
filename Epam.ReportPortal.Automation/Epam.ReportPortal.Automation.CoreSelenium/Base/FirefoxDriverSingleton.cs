using OpenQA.Selenium.Firefox;

namespace Epam.ReportPortal.Automation.CoreSelenium.Base
{
    public class FirefoxDriverSingleton
    {
        private static FirefoxDriver instace = null;
        private static readonly object lockObj = new object();

        private FirefoxDriverSingleton() { }

        public static FirefoxDriver Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instace == null)
                    {
                        instace = new FirefoxDriver();
                        instace.Manage().Window.Maximize();
                    }

                    return instace;
                }
            }
        }
    }
}