using EasyFTPClient.Application.Foundation.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace EasyFTPClient.Application.Foundation.Entity
{
    public class FtpWebResponseWrapper : IResponse
    {
        private FtpWebResponse ftpWebResponse;

        public string StatusDescription => ftpWebResponse?.StatusDescription;

        public FtpWebResponseWrapper(FtpWebResponse ftpWebResponse)
        {
            this.ftpWebResponse = ftpWebResponse;
        }


        public Stream GetResponseStream() => ftpWebResponse.GetResponseStream();

        public void Dispose()
        {
            ftpWebResponse.Dispose();
            ftpWebResponse = null;
        }

        public void Close() => ftpWebResponse.Close();
    }
}
