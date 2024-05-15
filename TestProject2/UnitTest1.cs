namespace TestProject2
{
    [TestClass]
    public class UnitTest1
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
            Assert.IsTrue(isAuthorized, "ѕользователь был успешно авторизован.");
        }
    }
}