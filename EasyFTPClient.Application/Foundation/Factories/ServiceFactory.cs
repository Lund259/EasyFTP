using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Foundation.Entity.Interfaces;
using EasyFTPClient.Application.Foundation.Services;
using EasyFTPClient.Application.Foundation.Services.Interfaces;
using EasyFTPClient.Application.Foundation.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Foundation.Factories
{
    public class ServiceFactory
    {
        UtilityFactory utilityFactory = new UtilityFactory();

        public IFTPService CreateFTPService(IConnectionProvider connectionProvider)
        {
            return new FTPService(utilityFactory.CreateRequestHandler(), connectionProvider);
        }
    }
}
