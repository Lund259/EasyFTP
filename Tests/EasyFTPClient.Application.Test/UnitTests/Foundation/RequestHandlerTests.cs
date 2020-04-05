using EasyFTPClient.Application.Acquaintance;
using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Foundation.Entity;
using EasyFTPClient.Application.Foundation.Entity.Interfaces;
using EasyFTPClient.Application.Foundation.Factories;
using EasyFTPClient.Application.Foundation.Utilities.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EasyFTPClient.Application.Test.UnitTests.Foundation
{
    [TestFixture]
    public class RequestHandlerTests
    {
        IRequestHandler requestHandler;
        IConnectionProvider dummyConnection;

        [SetUp]
        public void Setup()
        {
            requestHandler = new UtilityFactory().CreateRequestHandler();
            dummyConnection = new Connection(new Uri("ftp://testWebsite.com"), "user", "pass");
        }

        [Test]
        public void CreateFTPWebRequest_Success()
        {
            //Arrange
            var path = "folder1/folder2";
            var requestMethod = WebRequestMethods.Ftp.ListDirectoryDetails;
            var connection = dummyConnection;

            //AbsoluteUri includes / at the end
            var expectedRequestUrl = $"{connection.Url.AbsoluteUri}{path}";
            var expectedRequestMethod = requestMethod;

            //Act
            var request = requestHandler.CreateFTPWebRequest(connection, path, requestMethod);

            //Assert
            Assert.NotNull(request);
            Assert.AreEqual(expectedRequestUrl, request.RequestUri.AbsoluteUri);
            Assert.AreEqual(expectedRequestMethod, request.Method);
            Assert.AreEqual(connection.Credential, request.Credentials);
        }

        [TestCase("testFolder", "", true)]
        [TestCase("TestFolder", WebRequestMethods.Ftp.ListDirectoryDetails, false)]
        [TestCase("testFolder", null, true)]
        public void CreateFTPWebRequest_InvalidArgument_ThrowException(string path, string requestMethod, bool validConnection)
        {
            //Arrange
            var connection = validConnection ? dummyConnection : null;

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => requestHandler.CreateFTPWebRequest(connection, path, requestMethod));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateFTPWebRequest_EmptyOrNullPath_DoesNotThrowException(string path)
        {
            //Arrange
            var connection = dummyConnection;
            var requestMethod = WebRequestMethods.Ftp.ListDirectoryDetails;

            //Act

            //Assert
            Assert.DoesNotThrow(() => requestHandler.CreateFTPWebRequest(connection, path, requestMethod));
        }
    }
}
