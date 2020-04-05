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
        private readonly IFTPFileInfoParser fTPFileInfoParser;

        public FTPService(IRequestHandler requestHandler, IConnectionProvider connectionProvider, IFTPFileInfoParser fTPFileInfoParser)
        {
            this.requestHandler = requestHandler;
            this.connectionProvider = connectionProvider;
            this.fTPFileInfoParser = fTPFileInfoParser;
        }

        public IList<string> GetDirectoryDataListings(string path)
        {
            var requestMethod = WebRequestMethods.Ftp.ListDirectoryDetails;
            var request = requestHandler.CreateFTPWebRequest(connectionProvider, path, requestMethod);

            var directoryDataListings = requestHandler.GetResponseStrings(request);

            return directoryDataListings;
        }

        public IList<IFTPFileInfo> GetDirectoryContents(string path)
        {
            var directoryDataListings = GetDirectoryDataListings(path);
            var directoryContent = fTPFileInfoParser.ParseStringData(directoryDataListings);

            return directoryContent;
        }
    }
}
