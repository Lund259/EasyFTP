using EasyFTPClient.Application.Acquaintance;
using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Foundation.Entity;
using EasyFTPClient.Application.Foundation.Entity.Interfaces;
using EasyFTPClient.Application.Foundation.Factories;
using EasyFTPClient.Application.Foundation.Utilities.Interfaces;
using EasyFTPClient.Application.Test.UnitTests.Foundation.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
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
        public void CreateFtpWebRequest_Success()
        {
            //Arrange
            var path = "folder1/folder2";
            var requestMethod = WebRequestMethods.Ftp.ListDirectoryDetails;
            var connection = dummyConnection;

            //AbsoluteUri includes / at the end
            var expectedRequestUrl = $"{connection.Url.AbsoluteUri}{path}";
            var expectedRequestMethod = requestMethod;

            //Act
            var request = requestHandler.CreateFtpWebRequest(connection, path, requestMethod);

            //Assert
            Assert.NotNull(request);
            Assert.AreEqual(expectedRequestUrl, request.RequestUri.AbsoluteUri);
            Assert.AreEqual(expectedRequestMethod, request.Method);
            Assert.AreEqual(connection.Credential, request.Credentials);
        }

        [TestCase("testFolder", "", true)]
        [TestCase("TestFolder", WebRequestMethods.Ftp.ListDirectoryDetails, false)]
        [TestCase("testFolder", null, true)]
        public void CreateFtpWebRequest_InvalidArgument_ThrowException(string path, string requestMethod, bool validConnection)
        {
            //Arrange
            var connection = validConnection ? dummyConnection : null;

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => requestHandler.CreateFtpWebRequest(connection, path, requestMethod));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateFtpWebRequest_EmptyOrNullPath_DoesNotThrowException(string path)
        {
            //Arrange
            var connection = dummyConnection;
            var requestMethod = WebRequestMethods.Ftp.ListDirectoryDetails;

            //Act

            //Assert
            Assert.DoesNotThrow(() => requestHandler.CreateFtpWebRequest(connection, path, requestMethod));
        }

        [Test]
        public void GetResponseString_NullRequest_ThrowException()
        {
            //Arrange
            IRequest request = null;

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => requestHandler.GetResponseStrings(request));
        }

        [Test]
        public void GetResponseString_Success()
        {
            //Arrange
            string[] expected = new string[]
            {
                "d--x--x--x    2 ftp      ftp          4096 Mar 07  2002 bin",
                "-rw-r--r--    1 ftp      ftp        659450 Jun 15 05:07 TEST.TXT",
                "-rw-r--r--    1 ftp      ftp      101786380 Sep 08  2008 TEST03-05.TXT"
            };

            //Simulate a responseStream from an FTP server
            Stream responseStream = new MemoryStream();
            StreamWriter sw = new StreamWriter(responseStream);

            foreach(var line in expected)
            {
                sw.WriteLine(line);
                sw.Flush();
            }
            responseStream.Seek(0, SeekOrigin.Begin);

            ResponseMock responseMock = new ResponseMock(responseStream);
            IRequest request = new RequestMock(responseMock);

            //Act
            var actual = requestHandler.GetResponseStrings(request);

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(responseMock.CloseWasCalled);
            Assert.IsTrue(responseMock.DisposeWasCalled);
        }
    }
}
