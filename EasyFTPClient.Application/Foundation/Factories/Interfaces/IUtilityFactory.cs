using EasyFTPClient.Application.Foundation.Utilities.Interfaces;

namespace EasyFTPClient.Application.Foundation.Factories.Interfaces
{
    public interface IUtilityFactory
    {
        IRequestHandler CreateRequestHandler();
    }
}