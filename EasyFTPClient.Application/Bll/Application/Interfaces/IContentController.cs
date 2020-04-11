using EasyFTPClient.Application.Acquaintance.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Bll.Application.Interfaces
{
    public interface IContentController
    {
        IList<IContentFileInfo> GetContentInfo(string path);
    }
}
