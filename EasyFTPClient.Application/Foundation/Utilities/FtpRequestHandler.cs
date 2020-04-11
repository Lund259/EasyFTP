using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Foundation.Entity;
using EasyFTPClient.Application.Foundation.Entity.Interfaces;
using EasyFTPClient.Application.Foundation.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace EasyFTPClient.Application.Foundation.Utilities
{
    public class FtpRequestHandler : IRequestHandler
    {
        public IRequest CreateFtpWebRequest(IConnectionProvider connectionProvider, string path, string requestMethod)
        {
            if (connectionProvider is null)
            {
                throw new ArgumentException("connectionProvider cannot be null", nameof(connectionProvider));
            }

            if(connectionProvider.Url is null)
            {
                throw new ArgumentException("connectionProvider must contain a valid Url", nameof(connectionProvider));
            }

            if (string.IsNullOrWhiteSpace(requestMethod))
            {
                throw new ArgumentException("a valid requestMethod must be provided", nameof(requestMethod));
            }

            //AbsoluteUri includes / at the end
            var url = $"{connectionProvider.Url.AbsoluteUri}{path}";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = requestMethod;
            request.Credentials = connectionProvider.Credential;

            return new FtpWebRequestWrapper(request);
        }

        public IList<string> GetResponseStrings(IRequest request)
        {
            List<string> dataListings = new List<string>();

            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using var response = request.GetResponse();
            using var responseStream = response.GetResponseStream();
            using var reader = new StreamReader(responseStream);

            while (!reader.EndOfStream)
            {
                var dataListing = reader.ReadLine();
                dataListings.Add(dataListing);
            }

            reader.Close();
            response.Close();

            return dataListings;
        }
    }
}
