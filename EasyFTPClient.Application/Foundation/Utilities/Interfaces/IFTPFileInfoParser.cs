using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Foundation.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Foundation.Utilities.Interfaces
{
    public interface IFTPFileInfoParser
    {
        DataFormat GetDataFormat(string dataListing);
        IFTPFileInfo ParseDosString(string dataListing);
        IFTPFileInfo ParseNixString(string dataListing);
        IList<IFTPFileInfo> ParseStringData(IEnumerable<string> dataListings);
    }
}
