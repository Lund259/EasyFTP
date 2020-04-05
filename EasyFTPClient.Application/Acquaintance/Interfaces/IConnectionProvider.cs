using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EasyFTPClient.Application.Acquaintance.Interfaces
{
    public interface IConnectionProvider
    {
        Uri Url { get; }
        ICredentials Credential { get; }
    }
}
