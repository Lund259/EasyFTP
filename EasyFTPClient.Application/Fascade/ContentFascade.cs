using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Bll.Application.Interfaces;
using EasyFTPClient.Application.Fascade.Entity;
using EasyFTPClient.Application.Fascade.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Fascade
{
    public class ContentFascade : IContentFascade
    {
        private readonly IContentController contentController;

        public ContentFascade(IContentController contentController)
        {
            this.contentController = contentController;
        }

        public IList<IContentFileInfo> GetContentFileInfo(string path)
        {
            return contentController.GetContentInfo(path);
        }
    }
}
