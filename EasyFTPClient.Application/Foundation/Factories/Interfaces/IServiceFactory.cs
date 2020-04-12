using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Foundation.Services.Interfaces;

namespace EasyFTPClient.Application.Foundation.Factories.Interfaces
{
    public interface IServiceFactory
    {
        IContentService CreateFtpService(IConnectionProvider connectionProvider);
    }
}