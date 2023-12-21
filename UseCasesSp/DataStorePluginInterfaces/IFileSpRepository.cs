using CoreBusiness;

namespace Plugins.DataStore.SQL
{
    public interface IFileSpRepository
    {
        int? AddFileSp(FileSp fileSp);
        FileSp? GetFileSpById(int fileSpId);
    }
}