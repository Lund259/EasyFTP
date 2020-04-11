using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Bll.Application.Interfaces;
using EasyFTPClient.Application.Bll.Utilities.Interfaces;
using EasyFTPClient.Application.Foundation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Bll.Application
{
    public class ContentController : IContentController
    {
        private readonly IContentService contentService;
        private readonly IContentFileInfoParser contentFileInfoParser;

        public ContentController(IContentService contentService, IContentFileInfoParser contentFileInfoParser)
        {
            this.contentService = contentService;
            this.contentFileInfoParser = contentFileInfoParser;
        }

        public IList<IContentFileInfo> GetContentInfo(string path)
        {
            var directoryDataListings = contentService.GetDirectoryDataListings(path);
            var directoryContent = contentFileInfoParser.ParseStringData(directoryDataListings);

            return directoryContent;
        }
    }
}
