using EasyFTPClient.Application.Bll.Factories.Interfaces;
using EasyFTPClient.Application.Foundation.Utilities;
using EasyFTPClient.Application.Foundation.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Foundation.Factories
{
    public class UtilityFactory : IUtilityFactory
    {
        public IRequestHandler CreateRequestHandler()
        {
            return new FtpRequestHandler();
        }

    }
}
