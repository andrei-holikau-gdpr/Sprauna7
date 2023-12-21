using CoreBusiness;
using Plugins.DataStore.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.InMemory
{
    public class DirectorySpInMemoryRepository : IDirectorySpRepository
    {
        public void AddDirectorySp(DirectorySp directorySp)
        {
            throw new NotImplementedException();
        }

        public DirectorySp? GetDirectorySpById(int directorySpId)
        {
            throw new NotImplementedException();
        }

        public DirectorySp? GetDirectorySpByUserId(string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
