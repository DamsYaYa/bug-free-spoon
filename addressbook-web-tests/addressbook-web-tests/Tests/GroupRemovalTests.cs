﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveGroup : TestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Groups.RemoveGroup(1);
        }
    }
}