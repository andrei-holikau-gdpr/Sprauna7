using CoreBusiness;

namespace Plugins.DataStore.SQL
{
    public interface IDirectorySpRepository
    {
        void AddDirectorySp(DirectorySp directorySp);
        DirectorySp? GetDirectorySpById(int directorySpId);
        DirectorySp? GetDirectorySpByUserId(string UserId);
    }
}