using EasyFTPClient.Application.Bll.Utilities.Interfaces;

namespace EasyFTPClient.Application.Bll.Factories.Interfaces
{
    public interface IUtilityFactory
    {
        IContentFileInfoParser CreateContentFileInfoParser();
    }
}