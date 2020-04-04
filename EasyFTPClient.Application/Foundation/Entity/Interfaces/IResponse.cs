using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasyFTPClient.Application.Foundation.Entity.Interfaces
{
    public interface IResponse : IDisposable
    {
        string StatusDescription { get; }

        Stream GetResponseStream();
        void Close();
    }
}
