using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp2;

namespace UnitTestProject1
{
     [TestClass]
    public class AuthorizationTest
    {
        [TestMethod]
        public void TestSuccessfulAuthorization()
        {
            // Arrange
            int userId = 1;
            string password = "Eh23iV8Ls3";

            // Act
            bool isAuthorized = Authorization.PerformAuthorization(userId, password);

            // Assert
            Assert.IsTrue(isAuthorized, "Пользователь был успешно авторизован.");
        }
    }
}
