using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Foundation.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EasyFTPClient.Application.Foundation.Utilities.Interfaces
{
    public interface IRequestHandler
    {
        IRequest CreateFTPWebRequest(IConnectionProvider connectionProvider, string path, string requestMethod);
        IList<string> GetResponseStrings(IRequest request);
    }
}
