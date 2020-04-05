using EasyFTPClient.Application.Acquaintance.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EasyFTPClient.Application.Acquaintance
{
    public class Connection : IConnectionProvider
    {
        public Uri Url { get; }

        public ICredentials Credential { get; }

        public Connection(Uri url, string username, string password)
        {
            Url = url;
            Credential = new NetworkCredential(username, password);
        }

        public Connection(Uri url, NetworkCredential networkCredential)
        {
            Url = url;
            Credential = networkCredential;
        }
    }
}
