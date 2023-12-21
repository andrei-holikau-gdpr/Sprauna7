using CoreBusiness;
using Plugins.DataStore.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.DataStore.InMemory
{
    public class FileSpInMemoryRepository : IFileSpRepository
    {
        public int? AddFileSp(FileSp fileSp)
        {
            return 1;
        }

        public FileSp? GetFileSpById(int fileSpId)
        {
            return new FileSp()
            {
                FileSpId = 1,
                FileName = "example.jpeg",
                FileNameForFileStorage = "n4h2siez.fjv",
                FilePath = @"D:\\VisualStudioProjects\\Sprauna7\\Sprauna7Publish\\unsafe_uploads\\",
                CreationDate= DateTime.Now,
                CurrentUserId = "123"
            };
        }
    }
}
