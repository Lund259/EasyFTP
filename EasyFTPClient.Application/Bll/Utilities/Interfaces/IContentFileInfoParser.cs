using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Foundation.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Bll.Utilities.Interfaces
{
    public interface IContentFileInfoParser
    {
        DataFormat GetDataFormat(string dataListing);
        IContentFileInfo ParseDosString(string dataListing);
        IContentFileInfo ParseNixString(string dataListing);
        IList<IContentFileInfo> ParseStringData(IEnumerable<string> dataListings);
    }
}
