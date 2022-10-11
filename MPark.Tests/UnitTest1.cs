using static System.Net.WebRequestMethods;

namespace MPark.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BaseAddressURIStartsWith_IsNotHTTPLocalhost()
        {
            //Arrange
            string BaseURI = APIClientSettings.BaseAddressURI;
            string httpString = "http://localhost";
            int httpStrLength = httpString.Length;
            //Act
            //Assert
            Assert.AreNotEqual(httpString, BaseURI.Length >= httpStrLength ? BaseURI.Substring(0, httpStrLength) : BaseURI);
        }

        [TestMethod]
        public void BaseAddressURIStartsWith_IsNotHTTPSLocalhost()
        {
            //Arrange
            string BaseURI = APIClientSettings.BaseAddressURI;
            string httpsString = "https://localhost";
            int httpsStrLength = httpsString.Length;
            //Act
            //Assert
            Assert.AreNotEqual(httpsString, BaseURI.Length >= httpsStrLength ? BaseURI.Substring(0, httpsStrLength) : BaseURI);
        }
    }
}