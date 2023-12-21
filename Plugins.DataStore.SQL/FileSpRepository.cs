using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.SQL
{
    public class FileSpRepository : IFileSpRepository
    {
        private readonly SpraunaContext db;

        public FileSpRepository(SpraunaContext db)
        {
            this.db = db;
        }
        public int? AddFileSp(FileSp fileSp)
        {
            db.FileSps.Add(fileSp);
            db.SaveChanges();

            return fileSp.FileSpId;
        }
#pragma warning disable CS8766
        // ToDo: CS8766
        public FileSp? GetFileSpById(int fileSpId)
        {
            return db.FileSps.Find(fileSpId);
        }
#pragma warning restore CS8766
    }
}
