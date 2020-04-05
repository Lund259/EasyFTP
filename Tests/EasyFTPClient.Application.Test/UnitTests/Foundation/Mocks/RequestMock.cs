using EasyFTPClient.Application.Foundation.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EasyFTPClient.Application.Test.UnitTests.Foundation.Mocks
{
    class RequestMock : IRequest
    {
        private readonly IResponse responseToReturn;

        public Uri RequestUri => throw new NotImplementedException();

        public string Method => throw new NotImplementedException();

        public ICredentials Credentials => throw new NotImplementedException();

        public RequestMock(IResponse responseToReturn)
        {
            this.responseToReturn = responseToReturn;
        }

        public IResponse GetResponse()
        {
            return responseToReturn;
        }
    }
}
