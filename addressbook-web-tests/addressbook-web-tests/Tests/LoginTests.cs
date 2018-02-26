using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]

        public void LoginWithValidCredentials()
        {
            applicationManager.Auth.Logout();

            AccountData account = new AccountData("admin", "secret");
            applicationManager.Auth.Login(account);
            Assert.IsTrue(applicationManager.Auth.IsLoggedIn(account));
        }

        [Test]

        public void LoginWithInvalidCredentials()
        {
            applicationManager.Auth.Logout();

            AccountData account = new AccountData("admin", "cvndfkl");
            applicationManager.Auth.Login(account);
            Assert.IsFalse(applicationManager.Auth.IsLoggedIn(account));
        }
    }
}
