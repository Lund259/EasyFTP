using EasyFTPClient.Application.Acquaintance.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Acquaintance
{
    public class FTPFileInfo : IFTPFileInfo
    {
        public bool IsDirectory { get; }
        public long FileSize { get; }
        public DateTime LastModifiedDate { get; }
        public string FileName { get; }

        public FTPFileInfo(bool isDirectory, long fileSize, DateTime lastModifiedDate, string fileName)
        {
            IsDirectory = isDirectory;
            FileSize = fileSize;
            LastModifiedDate = lastModifiedDate;
            FileName = fileName;
        }
    }
}
