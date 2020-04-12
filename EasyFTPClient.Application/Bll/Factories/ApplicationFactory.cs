using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Bll.Application;
using EasyFTPClient.Application.Bll.Application.Interfaces;
using EasyFTPClient.Application.Bll.Factories.Interfaces;
using EasyFTPClient.Application.Foundation.Factories;
using EasyFTPClient.Application.Foundation.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using IUtilityFactory = EasyFTPClient.Application.Bll.Factories.Interfaces.IUtilityFactory;

namespace EasyFTPClient.Application.Bll.Factories
{
    public class ApplicationFactory : IApplicationFactory
    {
        readonly IServiceFactory serviceFactory = new ServiceFactory();
        readonly IUtilityFactory utilityFactory = new UtilityFactory();

        public IContentController CreateFtpContentController(IConnectionProvider connectionProvider)
        {
            return new ContentController(serviceFactory.CreateFtpService(connectionProvider), utilityFactory.CreateContentFileInfoParser());
        }
    }
}
