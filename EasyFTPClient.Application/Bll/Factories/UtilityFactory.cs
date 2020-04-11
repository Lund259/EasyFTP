using EasyFTPClient.Application.Bll.Factories.Interfaces;
using EasyFTPClient.Application.Bll.Utilities.Interfaces;
using EasyFTPClient.Bll.Foundation.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Bll.Factories
{
    public class UtilityFactory : IUtilityFactory
    {
        public IContentFileInfoParser CreateContentFileInfoParser()
        {
            return new ContentFileInfoParser();
        }
    }
}
