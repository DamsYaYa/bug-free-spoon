using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveContact : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            applicationManager.Contacts.RemoveContact();           
        }
    }
}