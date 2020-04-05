using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace EasyFTPClient.Application.Foundation.Entity.Interfaces
{
    public interface IRequest
    {
        Uri RequestUri { get; }
        string Method { get; }
        ICredentials Credentials { get; }

        IResponse GetResponse();
    }
}
