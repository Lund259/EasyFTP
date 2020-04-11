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
    public class FtpService : IContentService
    {
        private readonly IRequestHandler requestHandler;
        private readonly IConnectionProvider connectionProvider;

        public FtpService(IRequestHandler requestHandler, IConnectionProvider connectionProvider)
        {
            this.requestHandler = requestHandler;
            this.connectionProvider = connectionProvider;
        }

        public IList<string> GetDirectoryDataListings(string path)
        {
            var requestMethod = WebRequestMethods.Ftp.ListDirectoryDetails;
            var request = requestHandler.CreateFtpWebRequest(connectionProvider, path, requestMethod);

            var directoryDataListings = requestHandler.GetResponseStrings(request);

            return directoryDataListings;
        }
    }
}
