using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.SQL
{
    public class DirectorySpRepository : IDirectorySpRepository
    {
        private readonly SpraunaContext db;

        public DirectorySpRepository(SpraunaContext db)
        {
            this.db = db;
        }
        public void AddDirectorySp(DirectorySp directorySp)
        {
            db.DirectorySps.Add(directorySp);
            db.SaveChanges();
        }

        #pragma warning disable CS8766
        // ToDo: pragma warning disable CS8766
        public DirectorySp? GetDirectorySpById(int directorySpId)
        {
            return db.DirectorySps.Find(directorySpId);
        }

        public DirectorySp GetDirectorySpByUserId(string UserId)
        {
            return db.DirectorySps.First(x => x.CurrentUserId == UserId);
        }
        #pragma warning restore CS8766
    }
}
