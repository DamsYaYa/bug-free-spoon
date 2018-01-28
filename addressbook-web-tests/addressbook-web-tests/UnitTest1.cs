using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(8);
            Square s2 = new Square(12);
            Square s3 = s1;

            Assert.AreEqual(s1.Size, 8);
            Assert.AreEqual(s2.Size, 12);
            Assert.AreEqual(s3.Size, 8);

            s3.Size = 23;

            Assert.AreEqual(s1.Size, 23);

            s2.Colored = true;
        }

        [TestMethod]
        public void TestMethodCircle()
        {
            Circle s1 = new Circle(8);
            Circle s2 = new Circle(12);
            Circle s3 = s1;

            Assert.AreEqual(s1.Radius, 8);
            Assert.AreEqual(s2.Radius, 12);
            Assert.AreEqual(s3.Radius, 8);

            s3.Radius = 23;

            Assert.AreEqual(s1.Radius, 23);

            s2.Colored = true;
        }

    }
}
