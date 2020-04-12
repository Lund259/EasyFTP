using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Bll.Application.Interfaces;

namespace EasyFTPClient.Application.Bll.Factories.Interfaces
{
    public interface IApplicationFactory
    {
        IContentController CreateFtpContentController(IConnectionProvider connectionProvider);
    }
}