using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Foundation.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Foundation.Utilities.Interfaces
{
    public interface IFtpFileInfoParser
    {
        DataFormat GetDataFormat(string dataListing);
        IFtpFileInfo ParseDosString(string dataListing);
        IFtpFileInfo ParseNixString(string dataListing);
        IList<IFtpFileInfo> ParseStringData(IEnumerable<string> dataListings);
    }
}
