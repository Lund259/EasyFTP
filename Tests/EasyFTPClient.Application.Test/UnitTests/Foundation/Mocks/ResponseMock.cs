using EasyFTPClient.Application.Foundation.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasyFTPClient.Application.Test.UnitTests.Foundation.Mocks
{
    class ResponseMock : IResponse
    {
        private readonly Stream streamToReturn;

        public string StatusDescription => throw new NotImplementedException();

        public bool CloseWasCalled { get; private set; }
        public bool DisposeWasCalled { get; private set; }

        public ResponseMock(Stream streamToReturn)
        {
            this.streamToReturn = streamToReturn;
        }

        public void Close()
        {
            CloseWasCalled = true;
        }

        public void Dispose()
        {
            DisposeWasCalled = true;
            streamToReturn.Close();
            streamToReturn.Dispose();
        }

        public Stream GetResponseStream()
        {
            return streamToReturn;
        }
    }
}
