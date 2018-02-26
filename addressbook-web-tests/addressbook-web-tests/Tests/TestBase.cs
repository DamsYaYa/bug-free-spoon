using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        public ApplicationManager applicationManager;

        [SetUp]
        public void SetupApplicationManager()
        {
            applicationManager = ApplicationManager.GetInstance();
        }
    }
}
