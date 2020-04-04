using EasyFTPClient.Application.Foundation.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EasyFTPClient.Application.Foundation.Entity
{
    public class FtpWebRequestWrapper : IRequest
    {
        private readonly FtpWebRequest ftpWebRequest;

        public Uri RequestUri => ftpWebRequest?.RequestUri;
        public string Method => ftpWebRequest?.Method;
        public ICredentials Credentials => ftpWebRequest?.Credentials;

        public FtpWebRequestWrapper(FtpWebRequest ftpWebRequest)
        {
            this.ftpWebRequest = ftpWebRequest;
        }

        public IResponse GetResponse()
        {
            return new FtpWebResponseWrapper((FtpWebResponse)ftpWebRequest?.GetResponse());
        }
    }
}
