using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Acquaintance.Interfaces
{
    public interface IFTPFileInfo
    {
        bool IsDirectory { get; }
        long FileSize { get; }
        DateTime LastModifiedDate { get; }
        string FileName { get; }
    }
}
