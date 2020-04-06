using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Acquaintance.Interfaces
{
    public interface IFtpFileInfo
    {
        bool IsDirectory { get; }
        long FileSize { get; }
        DateTime LastModifiedDate { get; }
        string FileName { get; }
    }
}
