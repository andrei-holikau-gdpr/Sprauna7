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
    public class GetDirectorySpByUserIdUseCase : IGetDirectorySpByUserIdUseCase
    {
        private readonly IDirectorySpRepository directorySpRepository;

        public GetDirectorySpByUserIdUseCase(IDirectorySpRepository directorySpRepository)
        {
            this.directorySpRepository = directorySpRepository;
        }
        public DirectorySp? Execute(string id)
        {
            return directorySpRepository.GetDirectorySpByUserId(id);
        }
    }
}
