using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Bll.Factories;
using EasyFTPClient.Application.Bll.Factories.Interfaces;
using EasyFTPClient.Application.Fascade.Entity;
using EasyFTPClient.Application.Fascade.Factories.Interfaces;
using EasyFTPClient.Application.Fascade.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFTPClient.Application.Fascade.Factories
{
    public class FascadeFactory : IFascadeFactory
    {
        readonly IApplicationFactory applicationFactory = new ApplicationFactory();

        public IContentFascade CreateContentFascade(ConnectionType connectionType, IConnectionProvider connectionProvider)
        {
            var contentController = connectionType switch
            {
                ConnectionType.Ftp => applicationFactory.CreateFtpContentController(connectionProvider),
                _ => throw new NotImplementedException($"{connectionType} has not yet been implemented in Application.Fascade.Factiries.FascadeFactory.CreateContentFascade")
            };

            return new ContentFascade(contentController);
        }
    }
}
