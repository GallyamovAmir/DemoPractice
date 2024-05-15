using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp2;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Сводное описание для GenerationIdTest
        /// </summary>
        [TestClass]
        public class GenerationIdTest
        {
            [TestMethod]
            public void TestGenerateUniqueId()
            {
                using (lastprakEntities1 db = new lastprakEntities1()) ;
            }
        }
    }
}
