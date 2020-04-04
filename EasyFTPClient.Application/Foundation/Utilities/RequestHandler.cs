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
    public class RequestHandler : IRequestHandler
    {
        public IRequest CreateFTPWebRequest(IConnectionProvider connectionProvider, string path, string requestMethod)
        {
            var url = $"{connectionProvider.Url.AbsoluteUri}/{path}";

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = requestMethod;
            request.Credentials = connectionProvider.Credential;

            return new FtpWebRequestWrapper(request);
        }

        public string GetResponseString(IRequest request)
        {
            using var response = request.GetResponse();
            using var responseStream = response.GetResponseStream();
            using var reader = new StreamReader(responseStream);

            var responseString = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return responseString;
        }
    }
}
