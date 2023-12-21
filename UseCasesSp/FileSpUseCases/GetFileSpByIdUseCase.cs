using CoreBusiness;
using Plugins.DataStore.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCasesSp.UseCaseInterfaces;

namespace UseCasesSp.FileSpUseCases
{
    public class GetFileSpByIdUseCase : IGetFileSpByIdUseCase
    {
        private readonly IFileSpRepository fileSpRepository;

        public GetFileSpByIdUseCase(IFileSpRepository fileSpRepository)
        {
            this.fileSpRepository = fileSpRepository;
        }
        public FileSp? Execute(int id)
        {
            return fileSpRepository.GetFileSpById(id);
        }
    }
}
