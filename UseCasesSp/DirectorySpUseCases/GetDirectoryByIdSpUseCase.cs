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
    public class GetDirectorySpByIdUseCase : IGetDirectorySpByIdUseCase
    {
        private readonly IDirectorySpRepository directorySpRepository;

        public GetDirectorySpByIdUseCase(IDirectorySpRepository directorySpRepository)
        {
            this.directorySpRepository = directorySpRepository;
        }
        public DirectorySp? Execute(int id)
        {
            return directorySpRepository.GetDirectorySpById(id);
        }
    }
}
