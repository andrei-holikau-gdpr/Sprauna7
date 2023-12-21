using CoreBusiness;
using Plugins.DataStore.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCasesSp.UseCaseInterfaces;

namespace UseCasesSp.DirectorySpUseCases
{
    public class AddDirectorySpUseCase : IAddDirectorySpUseCase
    {
        private readonly IDirectorySpRepository directorySpRepository;

        public AddDirectorySpUseCase(IDirectorySpRepository directorySpRepository)
        {
            this.directorySpRepository = directorySpRepository;
        }
        public void Execute(DirectorySp directorySp)
        {
            directorySpRepository.AddDirectorySp(directorySp);
        }
    }
}
