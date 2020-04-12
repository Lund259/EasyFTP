using EasyFTPClient.Application.Acquaintance.Interfaces;
using EasyFTPClient.Application.Fascade.Entity;
using EasyFTPClient.Application.Fascade.Interfaces;

namespace EasyFTPClient.Application.Fascade.Factories.Interfaces
{
    public interface IFascadeFactory
    {
        IContentFascade CreateContentFascade(ConnectionType connectionType, IConnectionProvider connectionProvider);
    }
}