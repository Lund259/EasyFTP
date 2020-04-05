using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Foundation.Entity.Interfaces;
using EasyFTPClient.Application.Foundation.Services.Interfaces;
using EasyFTPClient.Application.Foundation.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EasyFTPClient.Application.Foundation.Services
{
    public class FTPService : IFTPService
    {
        private readonly IRequestHandler requestHandler;
        private readonly IConnectionProvider connectionProvider;

        public FTPService(IRequestHandler requestHandler, IConnectionProvider connectionProvider)
        {
            this.requestHandler = requestHandler;
            this.connectionProvider = connectionProvider;
        }

        public IList<string> GetDirectoryDataListings(string path)
        {
            var requestMethod = WebRequestMethods.Ftp.ListDirectoryDetails;
            var request = requestHandler.CreateFTPWebRequest(connectionProvider, path, requestMethod);

            var directoryContent = requestHandler.GetResponseStrings(request);

            return directoryContent;
        }
    }
}
