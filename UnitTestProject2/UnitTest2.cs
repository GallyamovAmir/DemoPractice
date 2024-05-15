using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void testauth()
        {
            bool auth = true;
            
                Assert.IsTrue(auth, "Данный isNumber отсутсвует в бд");
        }

        public void testauthUncorrect()
        {
            bool auth = false;

            Assert.IsFalse(auth, "Данный isNumber отсутсвует в бд");
        }

        public void testauthXd()
        {
            int userID = 123;
            int password = 123;

            Assert.AreEqual(password, userID, "Z V");
        }
    }
}
