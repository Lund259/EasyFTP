using EasyFTPClient.Application.Acquaintance.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Fascade.Interfaces
{
    public interface IContentFascade
    {
        IList<IContentFileInfo> GetContentFileInfo(string path);
    }
}
