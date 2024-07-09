using NUnit.Framework;

namespace Epam.ReportPortal.Automation.ApiBusinessLayer.ApiSteps
{
    public abstract class BaseApiSteps
    {
        protected BaseApiSteps()
        {
            // TODO: for example init rest with user/password
        }

        public void ValidateResponseIsOk()
        {
            Assert.Fail("TODO: Not implemented");
        }
    }
}
