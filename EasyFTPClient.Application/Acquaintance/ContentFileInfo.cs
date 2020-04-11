using EasyFTPClient.Application.Acquaintance.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Acquaintance
{
    public class ContentFileInfo : IContentFileInfo
    {
        public bool IsDirectory { get; }
        public long FileSize { get; }
        public DateTime LastModifiedDate { get; }
        public string FileName { get; }

        public ContentFileInfo(bool isDirectory, long fileSize, DateTime lastModifiedDate, string fileName)
        {
            IsDirectory = isDirectory;
            FileSize = fileSize;
            LastModifiedDate = lastModifiedDate;
            FileName = fileName;
        }
    }
}
