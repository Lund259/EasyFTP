using EasyFTPClient.Application.Acquaintance.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Foundation.Utilities.Interfaces
{
    public interface IFTPFileInfoParser
    {
        IList<IFTPFileInfo> ParseStringData(IEnumerable<string> dataListings);
    }
}
