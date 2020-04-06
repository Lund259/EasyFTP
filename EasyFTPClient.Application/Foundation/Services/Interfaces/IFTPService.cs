using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Foundation.Services.Interfaces
{
    public interface IFtpService
    {
        IList<string> GetDirectoryDataListings(string path);
    }
}
